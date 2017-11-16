using System;
using System.Collections.Generic;
using System.Text;
using WUT_MSI.Models.classes.helpers;
using WUT_MSI.ModelsLib;
using WUT_MSI.ModelsLib.apis;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models.classes
{
    public class Country : ICountry
    {
        public string DisplayName { get; }
        public uint Area { get; }
        public double Distance { get; }
        public float LevelOfModern { get; }
        public string Climate { get; }
        public ulong CountOfMonuments { get; }
        public int Population { get; }

        public Country(ApiCountry apiCountry)
        {
            Area = (uint)apiCountry.area;
            Population = apiCountry.population;
            Climate = GeneralHelper.GetClimate(apiCountry.latlng[0]);
            Distance = DistanceCalculator.GetDistance(double.Parse(Resource.WawGeoWidth), double.Parse(Resource.WawGeoWidth), apiCountry.latlng[0], apiCountry.latlng[1]);
            CountOfMonuments = MonumentsAPi.GetMonumentsCount(apiCountry.alpha2Code);
            LevelOfModern = (float)apiCountry.gini;

            FuzzyFunctions.FuzzyProps.SetArea(Area);
            FuzzyFunctions.FuzzyProps.SetDistance(Distance);
        }
    }
}
