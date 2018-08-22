using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiClient;

namespace MVC.Controllers
{
    using DataContracts;

    public class ReestrController : Controller
    {
        private string webApiUrl = "";
        // GET: Reestr
        public ActionResult Index()
        {
            var client = new Client(webApiUrl);

            var result = client.GetUrls();

            if (result.Status == ResponseStatus.Success)
            {
                return View(result.Data);
            }

            throw new Exception("Can't call api server!");
        }
    }
}