using System;
using WUT_MSI.ModelsLib;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models
{
    public static class FuzzyFunctions
    {
        public class DistanceFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Distance / FuzzyProps.Instance.MaxDistance;
            }
        }

        public class AreaFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Area / FuzzyProps.Instance.MaxArea;
            }
        }

        public class ClimeteFuzzy
        {
            public static double Invoke(ICountry country)
            {
                switch (country.Climate)
                {
                    case ClimateEnum.Tropical:
                        return 0.9;
                    case ClimateEnum.Subtropical:
                        return 0.65;
                    case ClimateEnum.Temperate:
                        return 0.4;
                    case ClimateEnum.Cold:
                        return 0.2;
                    default:
                        return 0;
                }
            }
        }

        public class CostFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Area / FuzzyProps.Instance.MaxArea;
            }
        }

        public class PopulationFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Population / FuzzyProps.Instance.MaxPopulation;
            }
        }

        public class DensityFuzzy
        {
            public static double Invoke(ICountry country)
            {
                double current = country.Population / country.Area;
                double max = FuzzyProps.Instance.MaxPopulation / FuzzyProps.Instance.MinArea;

                return current / max;
            }
        }

        public class JetFuzzy
        {
            public static double Invoke(ICountry country)
            {
                int polishTimeZone = 1;
                int maxTimeZones = 12;

                return Math.Abs(polishTimeZone - country.TimeZone) / (maxTimeZones + polishTimeZone);
            }
        }
    }
}
