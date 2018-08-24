using DataContracts;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiClient;

namespace MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly string webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client(webApiUrl);
                var result = client.Search(model.Text);

                if (result.Status == ResponseStatus.Success)
                {
                    return View("Search", result.Data);
                }

                if (result.Status == ResponseStatus.NotFound)
                {
                    ViewBag.Text = "NotFound";
                    return View("Index");
                }
            }

            throw new Exception("Can't search model");
        }
    }
}