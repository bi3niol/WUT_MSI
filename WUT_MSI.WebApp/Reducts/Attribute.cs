using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Reducts
{
    public class Attribute
    {
        public bool IsNeeded { get; private set; }

        private List<int> names;
        private Dictionary<string, List<string>> values;

        public Attribute(List<int> _names)
        {
            names = _names;
            values = new Dictionary<string, List<string>>();
        }

        public void AddPair(string key, string value)
            => values[key].Add(value);

        public void CheckIfIsNeeded(Attribute other)
        {
            if (values.Count != other.values.Count)
            { IsNeeded = false; return; }
        }
    }
}