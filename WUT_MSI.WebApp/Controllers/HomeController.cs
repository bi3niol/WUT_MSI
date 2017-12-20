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
            DbTablesInterface database = new DbTablesInterface();
            DbAttribute[] dbAttributes = database.GetAttributes(a => true);

            AttributeManager attributesManager = new AttributeManager(DataHelper.GetDataModelsFromDb());
            List<Attribute> attributes = attributesManager.CalculateReducts();

            List<List<string>> values = new List<List<string>>();

            foreach (Attribute attribute in attributes)
            {
                List<string> names = new List<string>();

                foreach (int name in attribute.Names)
                    names.Add(dbAttributes[name].Name);
                names.Sort();
                values.Add(names);
            }

            return View(values);
        }

        public ActionResult GetMinimalRules()
        {
            MinimalRuleManager minimalRuleManager = new MinimalRuleManager();
            List<MinimalRule> minimalRules = minimalRuleManager.GenerateRules();

            List<MinimalRuleVM> minimalRulesVM = new List<MinimalRuleVM>();

            foreach (MinimalRule rule in minimalRules)
                if(IsEmptyCollection(rule.Function))
                    minimalRulesVM.Add(new MinimalRuleVM(AnswearHelper.GetCountryName(rule.Name), MinimalRuleLookConverter.Convert(rule.Function)));

            return View(minimalRulesVM);
        }

        private bool IsEmptyCollection(List<string> function)
        {
            if (function.Count == 0)
                return false;

            foreach (var element in function)
                if (!string.IsNullOrWhiteSpace(element))
                    return true;
            return false;
        }
    }
}
