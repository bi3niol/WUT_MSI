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
        protected double Center { get; }
        protected double Range { get; }

        public Answer(double bottomLimit, double topLimit, string dispalyLabel)
        {
            DisplayLabel = dispalyLabel;
            BottomLimit = bottomLimit;
            TopLimit = topLimit;
            Center = (TopLimit + BottomLimit) / 2;
            Range = TopLimit - BottomLimit;
        }

        public bool MatchToAnswer(TParam parameter, Func<TParam, double> FuzzyFunction)
        {
            double currentResult = FuzzyFunction(parameter);
            bool isMatch = BottomLimit <= currentResult && TopLimit >= currentResult;

            if (isMatch)
            {
                parameter.CumSum += (1 - 2 * Math.Abs(Center - currentResult) / Range);
                parameter.QuestionsNum++;
                parameter.Result = (int)(parameter.CumSum / parameter.QuestionsNum * 100);
            }

            return isMatch;
        }

        public List<TParam> CutSet(ICollection<TParam> set, Func<TParam, double> FuzzyFunction)
        {
            return set.Where(p => MatchToAnswer(p, FuzzyFunction)).ToList();
        }
    }
}
