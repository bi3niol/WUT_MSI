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

                return current / FuzzyProps.Instance.MaxDensity;
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
                return country.CountOfMonuments / FuzzyProps.Instance.MaxMonuments;
            }
        }

        public class DevelopementFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.GINI > 40 && country.GINI <= 55)
                    return 0.7;

                if (country.GINI > 20 && country.GINI <= 40)
                    return 0.4;

                if (country.GINI <= 20)
                    return 0.2;

                return 0.2;
            }
        }

        public class MedicineFuzzy
        {
            public static double Invoke(ICountry country)
            {

                if (country.GINI > 40 && country.GINI <= 55)
                    return 0.9;

                if (country.GINI > 20 && country.GINI <= 40)
                    return 0.6;

                if (country.GINI <= 20)
                    return 0.25;

                return 0.25;
            }
        }

        public class SafetyFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.GINI > 40 && country.GINI <= 55)
                    return 0.8;

                if (country.GINI > 20 && country.GINI <= 40)
                    return 0.55;

                if (country.GINI <= 20)
                    return 0.3;

                return 0.3;
            }
        }

        public class VuclansFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.Climate == ClimateEnum.Tropical || country.Climate == ClimateEnum.Subtropical)
                    return 1;

                return 0;
            }
        }

        public class IslandFuzzy
        {
            public static double Invoke(ICountry country)
            {
                if (country.Climate == ClimateEnum.Tropical || country.Climate == ClimateEnum.Subtropical)
                    return 1;

                return 0;
            }
        }
    }
}
