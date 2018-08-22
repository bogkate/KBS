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

    public class CrowerController : ApiController, ICrower
    {
        [HttpPost]
        [ActionName("Execute")]
        public  Response<IEnumerable<CrowerData>> ExecuteIndexing()
        {
            var result = new Response<IEnumerable<CrowerData>> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage = new Storage())
                {
                    var urls = storage.Reestr.OrderBy(s=>s.Priority).ToList();
                    foreach(var url in urls)
                    {
                        var httpClient = new HttpClient { BaseAddress = new Uri(url.Url) };
                        using (var responseTask = httpClient.GetAsync(httpClient.BaseAddress.AbsoluteUri))
                        {
                            using (var response = responseTask.Result)
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    using (var contentTask = response.Content.ReadAsStringAsync())
                                    {
                                        var content = contentTask.Result;

                                      
                                        var words = content.Split().GroupBy(s =>s).ToDictionary(group => group.Key, group => group.Count());
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
                                                Reestr=url,
                                                Text=word.Key,
                                                Count=word.Value,
                                            });
                                        }
                                    }
                                }
                                else
                                {
                                    storage.Crower.Add(new Crower
                                    {
                                        Reestr = url,
                                        Status = true,
                                    });
                                }
                                storage.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            return result;
        }
    }
}
