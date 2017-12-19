using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            for (int i = 0; i < matrix.GetLength(0); i++)
                minimalRules.Add(new MinimalRule(i.ToString(), matrix.CalculateValueFor(i)));

            return minimalRules;
        }
    }
}
