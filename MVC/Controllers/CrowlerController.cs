using DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiClient;

namespace MVC.Controllers
{
    public class CrowlerController : Controller
    {
        private string webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
        // GET: Crower
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Execute()
        {
            var client = new Client(webApiUrl);
            
            var result = client.ExecuteIndexing();

            if (result.Status == ResponseStatus.Success)
            {
                return View(result.Data);
            }

            throw new Exception("Can't start indexing!");
        }
    }
}