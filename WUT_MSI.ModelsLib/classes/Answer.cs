using System;
using System.Collections.Generic;
using System.Linq;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.Models.classes
{
    public class Answer<TParam> : IAnswer<TParam> where TParam : IFuzzy
    {
        public string DisplayLabel { get; }

        protected double BottomLimit { get; set; }

        protected double TopLimit { get; set; }

        public Answer(double bottomLimit, double topLimit, string dispalyLabel)
        {
            DisplayLabel = dispalyLabel;
            BottomLimit = bottomLimit;
            TopLimit = topLimit;
        }

        public bool MatchToAnswer(TParam parameter, Func<TParam, double> FuzzyFunction)
        {
            double currentResult = FuzzyFunction(parameter);
            bool isMatch = BottomLimit <= currentResult && TopLimit >= currentResult;

            if (isMatch)
                parameter.Result *= (currentResult + 1) / 2;

            return isMatch;
        }

        public List<TParam> CutSet(ICollection<TParam> set, Func<TParam, double> FuzzyFunction)
        {
            return set.Where(p => MatchToAnswer(p, FuzzyFunction)).ToList();
        }
    }
}
