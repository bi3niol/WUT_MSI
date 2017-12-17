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

        public bool CheckIfIsNeeded(Attribute other)
        {
            if (values.Count != other.values.Count)
            { IsNeeded = false; return false; }

            if (this.values.Keys.Except(other.values.Keys).Any())
            { IsNeeded = false; return false; }

            if (other.values.Keys.Except(this.values.Keys).Any())
            { IsNeeded = false; return false; }

            foreach (var p in this.values)
            {
                List<string> thisValueList = p.Value;
                List<string> otherValueList = other.values[p.Key];

                if (thisValueList.Except(otherValueList).Any())
                { IsNeeded = false; return false; }

                if(otherValueList.Except(thisValueList).Any())
                { IsNeeded = false; return false; }
            }

            IsNeeded = true;

            return true;
        }
    }
}