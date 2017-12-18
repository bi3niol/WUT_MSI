using System.Linq;
using System.Collections.Generic;

namespace WUT_MSI.WebApp.Reducts
{
    public class Attribute
    {
        public List<int> Names { get; private set; }

        private Dictionary<string, List<string>> values;

        public Attribute(List<int> names)
        {
            Names = names;
            values = new Dictionary<string, List<string>>();
        }

        public void AddPair(string key, string value)
        {
            if (values.ContainsKey(key)) values[key].Add(value);
            else values.Add(key, new List<string>() { value });
        }

        public bool CheckIfIsNeeded(Attribute other)
        {
            if (values.Count != other.values.Count)
                return true;

            var thisValues = values.Values.ToList();
            var otherValues = other.values.Values.ToList();

            for (int i = 0; i < thisValues.Count; i++)
            {
                if (thisValues[i].Count != otherValues[i].Count)
                    return true;

                if (thisValues[i].Except(otherValues[i]).Any())
                    return true;

                if (otherValues[i].Except(thisValues[i]).Any())
                    return true;
            }

            return false;
        }
    }
}
