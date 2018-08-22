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

    [RoutePrefix("api/Crower")]
    public class CrowerController : ApiController, ICrower
    {
        [HttpGet]
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
