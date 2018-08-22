using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiClient;

namespace MVC.Controllers
{
    public class CrowerController : Controller
    {
        private string webApiUrl = "http://localhost:5493/";
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
                return RedirectToAction("Index", "Reestr");
            }

            throw new Exception("Can't remove url!");
        }
    }
}