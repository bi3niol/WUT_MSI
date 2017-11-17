using System;
using WUT_MSI.Models.classes.helpers;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib;
using WUT_MSI.ModelsLib.apis;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models.classes
{
    public class Country : ICountry
    {
        public string DisplayName { get; set; }
        public string Capital { get; set; }
        public uint Area { get; set; }
        public double Distance { get; set; }
        public float GINI { get; set; }
        public ClimateEnum Climate { get; set; }
        public ulong CountOfMonuments { get; set; }
        public int Population { get; set; }
        public int TimeZone { get; set; }
        public double Result { get; set; } = 1.0;

        public Country() { Result = 1; }

        public Country(ApiCountry apiCountry)
        {
            Result = 1;
            DisplayName = apiCountry.name;
            Capital = apiCountry.capital;
            Area = (uint)apiCountry.area;
            Population = apiCountry.population;
            TimeZone = TimeZoneHelper.GetTimeZome(apiCountry.timezones);
            Climate = GeneralHelper.GetClimate(apiCountry.latlng[0]);
            Distance = DistanceCalculator.GetDistance(Convert.ToDouble(Resource.WawGeoWidth), Convert.ToDouble(Resource.WawGeoLength), apiCountry.latlng[0], apiCountry.latlng[1]);
            CountOfMonuments = MonumentsAPi.GetMonumentsCount(apiCountry.alpha2Code);
            GINI = apiCountry.gini.HasValue? (float)apiCountry.gini:0;

            FuzzyProps.SetGINI(GINI);
            FuzzyProps.SetArea(Area);
            FuzzyProps.SetDistance(Distance);
            FuzzyProps.SetPopulation(Population);
            FuzzyProps.SetDendity(Population, Area);
        }
    }
}
