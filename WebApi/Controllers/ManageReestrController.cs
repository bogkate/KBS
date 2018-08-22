using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class ManageReestrController : Controller
    {
        [HttpGet]
        public ActionResult Urls()
        {
            return this.ExecuteSecurityAction(client =>
            {
                var result = client.GetCardsAsPagedList(pageNumber, PageSize);

                if (result.Status == ApiResultStatus.Success)
                {
                    ViewBag.SelectedCardNumber = selectedCardNumber;

                    return View(new PagedListEx<CardTableDataContract>(result.Data));
                }

                throw new Exception("Can't call api server!");
            });
        }
    }
}