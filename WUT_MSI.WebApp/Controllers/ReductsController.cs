using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.MinimalRules;
using WUT_MSI.WebApp.MinimalRules.Helpers;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.Controllers
{
    public class ReductsController : Controller
    {
        public ActionResult GetReducts()
        {
            DbTablesInterface database = new DbTablesInterface();
            DbAttribute[] dbAttributes = database.GetAttributes(a => true);

            AttributeManager attributesManager = new AttributeManager(DataHelper.GetDataModelsFromDb());
            List<Reducts.Attribute> attributes = attributesManager.CalculateReducts();

            List<List<string>> values = new List<List<string>>();

            foreach (Reducts.Attribute attribute in attributes)
            {
                List<string> names = new List<string>();

                foreach (int name in attribute.Names)
                    names.Add(dbAttributes[name].Name);
                names.Sort();
                values.Add(names);
            }

            return View(values.OrderBy(v => v.Count).ToList().GetRange(0, 1));
        }

        public ActionResult GetMinimalRules()
        {
            MinimalRuleManager minimalRuleManager = new MinimalRuleManager();
            List<MinimalRule> minimalRules = minimalRuleManager.GenerateRules();

            List<MinimalRuleVM> minimalRulesVM = new List<MinimalRuleVM>();

            foreach (MinimalRule rule in minimalRules)
                minimalRulesVM.Add(new MinimalRuleVM(AnswearHelper.GetCountryName(rule.Name), MinimalRuleLookConverter.Convert(rule.Function)));

            return View(minimalRulesVM);
        }
    }
}
