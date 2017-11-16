using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models
{
    public interface ICountry
    {
        string DisplayName { get; }
        uint Area { get; }
        uint Distance { get; }
        float LevelOfModern { get; }
        string Climate { get; }
        int CountOfMonuments { get; }
    }
}
