using System;
using System.Collections.Generic;
using System.Text;
using WUT_MSI.Models.classes;

namespace WUT_MSI.Models
{
    public static class FuzzyFunctions
    {
        public static class FuzzyProps
        {
            public static double MaxDistance { get; set; } = double.MinValue;
            public static double MaxTemp { get; set; } = double.MinValue;
            public static double MaxArea { get; set; } = double.MinValue;
        }
        public class DistanceFuzzy
        {
            public double Invoke(ICountry country)
            {
                return country.Distance / FuzzyProps.MaxDistance;
            }
        }
        public class AreaFuzzy
        {
            public double Invoke(ICountry country)
            {
                return country.Area / FuzzyProps.MaxArea;
            }
        }
    }
}
