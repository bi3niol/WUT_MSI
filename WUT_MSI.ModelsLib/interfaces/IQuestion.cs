﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models.interfaces
{
    public interface IQuestion<TParam>
    {
        IAnswer<TParam> this[int i] { get; }
        string DisplayQuestion { get; }
        List<IAnswer<TParam>> Answers { get; }
        Func<TParam, double> FuzzyFunction { get; }
    }
}
