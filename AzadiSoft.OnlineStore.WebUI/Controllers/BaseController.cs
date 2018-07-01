using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        public ActionResult SuccessResult()
        {
            return Json(new {success = true}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ErrorResult(string errorMsg)
        {
            return Json(new { success = false, errorMsg}, JsonRequestBehavior.AllowGet);
        }

    }
}