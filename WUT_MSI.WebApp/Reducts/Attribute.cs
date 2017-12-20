using System.Linq;
using System.Collections.Generic;
using System;

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

        internal bool AreInSameSet(string first, string second)
        {
            //foreach (List<string> set in Values.Values)
            //    if (set.Contains(first) && set.Contains(second))
            //        return true;

            //return false;
            return first.Equals(second);
        }

        public string GetKeyDiffrenceFromValue(string first, string second)
        {
            string firstKey = null;
            string secondKey = null;

            foreach (var pair in Values)
            {
                if (pair.Value.Contains(first))
                    firstKey = pair.Key;

                if (pair.Value.Contains(second))
                    secondKey = pair.Key;
            }

            string[] keyValueFirst = firstKey.Split('_');
            string[] keyValueSecond = secondKey.Split('_');

            List<string> result = keyValueFirst.Except(keyValueSecond).ToList();
            
            return result.Count == 0 ? null : result.Aggregate((s1, s2) => $"{s1}_{s2}");
        }
    }
}
