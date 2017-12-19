using System.Collections.Generic;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class MinimalRule
    {
        public string Name { get; set; }
        public List<string> Function { get; set; }

        public MinimalRule(string name, List<string> function)
        {
            this.Name = name;
            this.Function = function;
        }
    }
}
