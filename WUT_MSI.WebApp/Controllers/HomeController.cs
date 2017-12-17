using System.Collections.Generic;
using System.Web.Mvc;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetReducts()
        {
            AttributeManager attributesManager = new Reducts.AttributeManager(DataHelper.GetDataModelsFromDb());
            List<Attribute> attributes = attributesManager.CalculateReducts();

            return View(attributes);
        }
    }
}