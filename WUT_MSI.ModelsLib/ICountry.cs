using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models
{
    public interface ICountry : IFuzzy
    {
        string DisplayName { get; }
        uint Area { get; }
        double Distance { get; }
        float GINI { get; }
        ClimateEnum Climate { get; }
        ulong CountOfMonuments { get; }
        int Population { get; }
        int TimeZone { get; }
        double PKB { get; }
        double Medicine { get; }
        double Safety { get; }
        bool Sea { get; }
        bool Mountain { get; }
    }
}
