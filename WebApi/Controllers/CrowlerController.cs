using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using DataContracts;
    using DataContracts.Crower;
    using DataContracts.Interfaces;
    using KBSDb;
    using HtmlAgilityPack;

    public class CrowlerController : ApiController, ICrower
    {
        [HttpPost]
        [ActionName("Execute")]
        public Response<IEnumerable<CrowerData>> ExecuteIndexing()
        {
            var result = new Response<IEnumerable<CrowerData>> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    var urls = storage.Reestr.OrderBy(s => s.Priority).ToList();
                    foreach (var url in urls)
                    {
                        try
                        {
                            if (storage.Crower.FirstOrDefault(s => s.Reestr.ReeestrId == url.ReeestrId && s.Status) != null)
                            {
                                continue;
                            }
                            var web = new HtmlWeb();
                            var doc = web.Load(url.Url);
                            var words = new Dictionary<string, int>();
                            foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
                            {
                                var href = link.Attributes["href"].Value;
                                if (href.Contains(web.ResponseUri.AbsoluteUri))
                                {
                                    href = href.Replace(web.ResponseUri.AbsoluteUri, "");
                                }
                                if (href.Where(s=>s=='/').Count()==url.Depth)
                                {
                                    try
                                    {
                                        var subDoc = web.Load(web.ResponseUri.AbsoluteUri + href);
                                        IndexPage(subDoc,words);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            IndexPage(doc, words);

                            storage.Crower.Add(new Crower
                            {
                                Reestr = url,
                                CountIndex = words.Count(),
                                Status = true,
                            });
                            foreach (var word in words)
                            {
                                storage.Index.Add(new Index
                                {
                                    Reestr = url,
                                    Text = word.Key,
                                    Count = word.Value,
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            storage.Crower.Add(new Crower
                            {
                                Reestr = url,
                                Status = false,
                            });
                        }

                    }
                    storage.SaveChanges();
                    result.Status = ResponseStatus.Success;
                    result.Data = storage.Crower.ToList().Select(s => new CrowerData
                    {
                        Url=s.Reestr.Url,
                        CountIndex=s.CountIndex,
                        Status=s.Status
                    });
                }
            }
            catch (Exception e)
            {
            }

            return result;
        }

        private void IndexPage(HtmlDocument subDoc,Dictionary<string,int> words)
        {
            var root = subDoc.DocumentNode;

            foreach (var node in subDoc.DocumentNode.SelectNodes("//text()"))
            {
                if (string.IsNullOrEmpty(node.InnerText) || string.IsNullOrWhiteSpace(node.InnerText))
                    continue;
                if (words.ContainsKey(node.InnerText))
                {
                    words[node.InnerText]++;
                }
                else
                {
                    words.Add(node.InnerText, 1);
                }
            }
        }

        
    }
}
