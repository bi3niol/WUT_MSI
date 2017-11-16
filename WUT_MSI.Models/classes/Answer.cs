using System;
using System.Collections.Generic;
using System.Text;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.Models.classes
{
    public class Answer<TParam> : IAnswer<TParam>
    {
        public string DisplayLabel { get; }

        protected double BottomLimit { get; set; }

        protected double TopLimit { get; set; }
        
        public Answer(double bottomLimit, double topLimit, string dispalyLabel)
        {
            DisplayLabel = dispalyLabel;
            BottomLimit = bottomLimit;
            TopLimit = TopLimit;
        }

        public bool MatchToAnswer(TParam parameter, Func<TParam, double> FuzzyFunction)
        {
            return BottomLimit<= FuzzyFunction(parameter) && TopLimit>= FuzzyFunction(parameter);
        }
    }
}
