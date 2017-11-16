using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models.interfaces
{
    public interface IQuestrion<TParam>
    {
        string Question { get; }
        List<IAnswer<TParam>> Answers { get; }
        Func<TParam, double> FuzzyFunction { get; }
    }
}
