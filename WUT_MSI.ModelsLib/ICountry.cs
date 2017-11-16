using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models
{
    public interface ICountry
    {
        string DisplayName { get; }
        uint Area { get; }
        double Distance { get; }
        float GINI { get; }
        string Climate { get; }
        ulong CountOfMonuments { get; }
        int Population { get; }
    }
}
