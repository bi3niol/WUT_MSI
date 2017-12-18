using System.Linq;
using System.Collections.Generic;

namespace WUT_MSI.WebApp.Reducts
{
    public class Attribute
    {
        public List<int> Names { get; private set; }
        public Dictionary<string, List<string>> Values;

        public Attribute(List<int> names)
        {
            Names = names;
            Values = new Dictionary<string, List<string>>();
        }

        public void AddPair(string key, string value)
        {
            if (Values.ContainsKey(key)) Values[key].Add(value);
            else Values.Add(key, new List<string>() { value });
        }

        public bool CheckIfIsNeeded(Attribute other)
        {
            if (Values.Count != other.Values.Count)
                return true;

            var thisValues = Values.Values.ToList();
            var otherValues = other.Values.Values.ToList();

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
