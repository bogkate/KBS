using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    using DataContracts;
    using DataContracts.Interfaces;
    using DataContracts.Search;
    using KBSDb;

    [RoutePrefix("api/Search")]
    public class SearchController : ApiController, ISearch
    {
        [HttpGet]
        public Response<IEnumerable<SearchData>> Search([FromUri]string text)
        {
            var result = new Response<IEnumerable<SearchData>> { Status = ResponseStatus.UnknownError };

            try
            {
                using (var storage= new Storage())
                {
                    var searchResults = storage.Index.Where(i => i.Text.Contains(text)).ToList();
                    if (searchResults.Any())
                    {
                        result.Data = searchResults.Select(i => new SearchData
                        {
                            Url = i.Reestr.Url,
                            Count = i.Count
                        });

                        result.Status = ResponseStatus.Success;
                    }
                    else
                    {
                        result.Status = ResponseStatus.NotFound;
                    }
                }
            }
            catch (Exception exception)
            {

            }

            return result;
        }
    }
}
