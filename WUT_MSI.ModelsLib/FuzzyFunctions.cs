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
                return country.Distance / (FuzzyProps.Instance.MaxDistance - FuzzyProps.Instance.MinDistance);
            }
        }

        public class AreaFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return (FuzzyProps.Instance.MaxArea + country.Area) / 2 / FuzzyProps.Instance.MaxArea;
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
                        return 0.7;
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
                return (FuzzyProps.Instance.MaxArea + country.Area) / 2 * MedicineFuzzy.Invoke(country) / Math.Pow(DevelopementFuzzy.Invoke(country), 2);
            }
        }

        public class PopulationFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Population / ( FuzzyProps.Instance.MaxPopulation - FuzzyProps.Instance.MinPopulation);
            }
        }

        public class DensityFuzzy
        {
            public static double Invoke(ICountry country)
            {
                double current;
                if (country.Area == 0)
                {
                    Random r = new Random();
                    current = (r.NextDouble() + 0.3) * 100/2;
                }
                else
                 current = country.Population / country.Area;

                return current / (FuzzyProps.Instance.MaxDensity - FuzzyProps.Instance.MinDensity);
            }
        }

        public class JetFuzzy
        {
            public static double Invoke(ICountry country)
            {
                double polishTimeZone = 1;
                double maxTimeZones = 12;

                return Math.Abs(polishTimeZone - (double)country.TimeZone) / (maxTimeZones + polishTimeZone);
            }
        }

        public class RainsFuzzy
        {
            public static double Invoke(ICountry country)
            {
                switch (country.Climate)
                {
                    case ClimateEnum.Tropical:
                        return 0.2;
                    case ClimateEnum.Subtropical:
                        return 0.35;
                    case ClimateEnum.Temperate:
                        return 0.7;
                    case ClimateEnum.Cold:
                        return 0.2;
                    default:
                        return 0;
                }
            }
        }

        public class MonumentsFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return  country.CountOfMonuments / FuzzyProps.Instance.MaxMonuments * AreaFuzzy.Invoke(country);
            }
        }

        public class DevelopementFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return (country.Population == 0 ? 0 : country.PKB / country.Population) / (FuzzyProps.Instance.MaxPKBPerPerson - FuzzyProps.Instance.MinPKBPerPerson);
            }
        }

        public class MedicineFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Medicine;
            }
        }

        public class SafetyFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return country.Safety;
            }
        }
    }
}
