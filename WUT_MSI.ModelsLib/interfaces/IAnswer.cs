using System;

namespace WUT_MSI.Models.interfaces
{
    public interface IAnswer<TParam>
    {
        string DisplayLabel { get; }
        bool MatchToAnswer(TParam parameter, Func<TParam, double> FuzzyFunction);
    }
}