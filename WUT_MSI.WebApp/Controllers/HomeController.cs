using System.Collections.Generic;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.MinimalRules;
using WUT_MSI.WebApp.MinimalRules.Helpers;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartFindCountry()
        {
            return RedirectToAction("Index", "CountryFinder");
        }
    }
}
