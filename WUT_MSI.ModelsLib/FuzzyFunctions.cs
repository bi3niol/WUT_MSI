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
                return (FuzzyProps.Instance.MaxDistance + country.Distance) / 2 / FuzzyProps.Instance.MaxDistance;
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
                return (FuzzyProps.Instance.MaxPopulation + country.Population) / 2 / FuzzyProps.Instance.MaxPopulation;
            }
        }

        public class DensityFuzzy
        {
            public static double Invoke(ICountry country)
            {
                double current = country.Population / country.Area;

                return (FuzzyProps.Instance.MaxDensity + current) / 2 / FuzzyProps.Instance.MaxDensity;
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
                        return 0.4;
                    default:
                        return 0;
                }
            }
        }

        public class MonumentsFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return (FuzzyProps.Instance.MaxMonuments + country.CountOfMonuments) / 2 / FuzzyProps.Instance.MaxMonuments;
            }
        }

        public class DevelopementFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.GINI > 40 && country.GINI <= 55)
                    return Math.Pow(0.9 * PopulationFuzzy.Invoke(country), 2);

                if (country.GINI > 20 && country.GINI <= 70)
                    return Math.Pow(0.6 * PopulationFuzzy.Invoke(country), 2);

                return Math.Pow(0.25 * PopulationFuzzy.Invoke(country), 2);
            }
        }

        public class MedicineFuzzy
        {
            public static double Invoke(ICountry country)
            {
                return (FuzzyProps.Instance.MaxGINI - country.GINI) / FuzzyProps.Instance.MaxGINI * (Math.Sin(Math.Pow(PopulationFuzzy.Invoke(country), 2)));
            }
        }

        public class SafetyFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.GINI > 40 && country.GINI <= 45)
                    return 0.8;

                if (country.GINI > 20 && country.GINI <= 70)
                    return 0.55;

                return 0.3;
            }
        }
    }
}
