﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models
{
    public static class FuzzyFunctions
    {
        public class FuzzyProps
        {
            private static FuzzyProps instance;
            public static FuzzyProps Instance
            {
                get
                {
                    if (instance == null)
                        instance = GetFuzzyProps();
                    return instance;
                }
            }
            private static FuzzyProps GetFuzzyProps()
            {
                SerializationManager m = new SerializationManager();
                FuzzyProps res = null;
                try
                {
                    res = m.Deserialize<FuzzyProps>(Environment.CurrentDirectory + "/FuzzyProps.xml");
                }
                catch (Exception e)
                {
                    res = new FuzzyProps();
                }
                return res;
            }
            static FuzzyProps()
            {
                if (!File.Exists(Environment.CurrentDirectory + "/FuzzyProps.xml"))
                {
                    SerializationManager m = new SerializationManager();
                    m.Serialize<FuzzyProps>(Environment.CurrentDirectory + "/FuzzyProps.xml", new FuzzyProps());
                }
            }
            private static void SaveFuzzyProps()
            {
                SerializationManager m = new SerializationManager();
                m.Serialize<FuzzyProps>(Environment.CurrentDirectory + "/FuzzyProps.xml", Instance);
            }
            public double MaxDistance { get; set; } = double.MinValue;
            public double MinDistance { get; set; } = double.MaxValue;

            public double MaxTemp { get; set; } = double.MinValue;
            public double MinTemp { get; set; } = double.MaxValue;

            public double MaxArea { get; set; } = double.MinValue;
            public double MinArea { get; set; } = double.MaxValue;

            public double MaxMonuments { get; set; } = double.MinValue;
            public double MinMonuments { get; set; } = double.MaxValue;

            public static void SetMonument(double Monument)
            {
                if (Instance.MaxMonuments < Monument)
                    Instance.MaxMonuments = Monument;
                if (Instance.MinMonuments > Monument)
                    Instance.MinMonuments = Monument;

                SaveFuzzyProps();
            }

            public static void SetDistance(double dist)
            {
                if (Instance.MaxDistance < dist)
                    Instance.MaxDistance = dist;
                if (Instance.MinDistance > dist)
                    Instance.MinDistance = dist;

                SaveFuzzyProps();
            }

            public static void SetTemp(double Temp)
            {
                if (Instance.MaxTemp < Temp)
                    Instance.MaxTemp = Temp;
                if (Instance.MinTemp > Temp)
                    Instance.MinTemp = Temp;

                SaveFuzzyProps();
            }

            public static void SetArea(double Area)
            {
                if (Instance.MaxArea < Area)
                    Instance.MaxArea = Area;
                if (Instance.MinArea > Area)
                    Instance.MinArea = Area;

                SaveFuzzyProps();
            }
        }
        public class DistanceFuzzy
        {
            public double Invoke(ICountry country)
            {
                return country.Distance / FuzzyProps.Instance.MaxDistance;
            }
        }
        public class AreaFuzzy
        {
            public double Invoke(ICountry country)
            {
                return country.Area / FuzzyProps.Instance.MaxArea;
            }
        }
    }
}
