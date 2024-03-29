﻿using System;
using System.Collections.Generic;

namespace WUT_MSI.Models.interfaces
{
    public interface IAnswer<TParam> where TParam : IFuzzy
    { 
        string DisplayLabel { get; }
        bool MatchToAnswer(TParam parameter, Func<TParam, double> FuzzyFunction,bool isChecking);
        List<TParam> CutSet(ICollection<TParam> set, Func<TParam, double> FuzzyFunction);
    }
}