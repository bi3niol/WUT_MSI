using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.MinimalRules.Helpers
{
    public class MinimalRuleVM
    {
        public string Name { get; set; }
        public string Function { get; set; }

        public MinimalRuleVM(string name, string function)
        {
            this.Name = name;
            this.Function = function;
        }
    }
}
