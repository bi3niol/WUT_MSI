using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WUT_MSI.WebApp.MinimalRules.Helpers
{
    public class MinimalRuleLookConverter
    {
        public static string Convert(List<string> minimalRules)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string s in minimalRules)
            {
                if (string.IsNullOrEmpty(s)) break;

                builder.Append("( ");
                builder.Append(s.Replace('_', '|'));
                builder.Append(" ) ^ ");
            }

            if (string.IsNullOrEmpty(builder.ToString()))
                return null;

            return builder.Remove(builder.Length - 2, 2).ToString();
        }
    }
}
