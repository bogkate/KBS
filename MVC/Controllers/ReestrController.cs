using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiClient;

namespace MVC.Controllers
{
    using DataContracts;
    using DataContracts.Reestr;
    using Models;
    using System.Configuration;

    public class ReestrController : Controller
    {
        private string webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddReestrModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client(webApiUrl);
                var result = client.AddUrl(new ReestrData { Depth = model.Depth, Url = model.Url });

                if (result.Status == ResponseStatus.Success)
                {
                    return RedirectToAction("Index", "Reestr");
                }
            }

            throw new Exception("Can't add url!");
        }

        [HttpGet]
        public ActionResult Edit(long reestrId)
        {
            var client = new Client(webApiUrl);

            var result = client.GetUrl(reestrId);

            if (result.Status == ResponseStatus.Success)
            {
                return View(new ReestrModel
                {
                    ReestrId = result.Data.ReestrId,
                    Url = result.Data.Url,
                    Depth = result.Data.Depth
                });
            }

            throw new Exception("Can't edit url!");
        }

        [HttpPost]
        public ActionResult Edit(ReestrModel model)
        {
            var client = new Client(webApiUrl);

            if (ModelState.IsValid)
            {
                var result = client.EditUrl(new ReestrData
                {
                    ReestrId = model.ReestrId,
                    Url =model.Url,
                    Depth= model.Depth
                });

                if (result.Status == ResponseStatus.Success)
                {
                    return RedirectToAction("Index", "Reestr");
                }
            }

            throw new Exception("Can't edit url!");
        }

        [HttpGet]
        public ActionResult Delete(long reestrId)
        {
            var client = new Client(webApiUrl);

            var result = client.GetUrl(reestrId);

            if (result.Status == ResponseStatus.Success)
            {
                return View(new ReestrModel
                {
                    ReestrId = result.Data.ReestrId,
                    Url = result.Data.Url,
                    Depth = result.Data.Depth
                });
            }

            throw new Exception("Can't remove url!");
        }

        [HttpPost]
        public ActionResult Delete(ReestrModel model)
        {
            var client = new Client(webApiUrl);

            if (ModelState.IsValid)
            {
                var result = client.DeleteUrl(model.ReestrId);

                if (result.Status == ResponseStatus.Success)
                {
                    return RedirectToAction("Index", "Reestr");
                }
            }

            throw new Exception("Can't remove url!");
        }
    }
}