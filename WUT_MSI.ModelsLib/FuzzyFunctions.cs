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
            public static double MinDistance { get; set; } = double.MaxValue;

            public static double MaxTemp { get; set; } = double.MinValue;
            public static double MinTemp { get; set; } = double.MaxValue;

            public static double MaxArea { get; set; } = double.MinValue;
            public static double MinArea { get; set; } = double.MaxValue;

            public static double MaxMonuments { get; set; } = double.MinValue;
            public static double MinMonuments { get; set; } = double.MaxValue;

            public static void SetMonument(double Monument)
            {
                if (MaxMonuments < Monument)
                    MaxMonuments = Monument;
                if (MinMonuments > Monument)
                    MinMonuments = Monument;
            }

            public static void SetDistance(double dist)
            {
                if (MaxDistance < dist)
                    MaxDistance = dist;
                if (MinDistance > dist)
                    MinDistance = dist;
            }

            public static void SetTemp(double Temp)
            {
                if (MaxTemp < Temp)
                    MaxTemp = Temp;
                if (MinTemp > Temp)
                    MinTemp = Temp;
            }

            public static void SetArea(double Area)
            {
                if (MaxArea < Area)
                    MaxArea = Area;
                if (MinArea > Area)
                    MinArea = Area;
            }
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
