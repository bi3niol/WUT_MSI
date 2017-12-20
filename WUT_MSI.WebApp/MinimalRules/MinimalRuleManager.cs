using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class MinimalRuleManager
    {
        private DiscernabilityMatrix matrix;
        private List<MinimalRule> minimalRules;

        public MinimalRuleManager()
        {
            matrix = new DiscernabilityMatrix();
            minimalRules = new List<MinimalRule>();
        }

        public List<MinimalRule> GenerateRules()
        {
            DataModel[] dataModel = DataHelper.GetDataModelsFromDb();

            for (int i = 0; i < matrix.GetLength(0); i++)
                minimalRules.Add(new MinimalRule(dataModel[i].Id.ToString(), matrix.CalculateValueFor(i)));

            return minimalRules;
        }
    }
}
