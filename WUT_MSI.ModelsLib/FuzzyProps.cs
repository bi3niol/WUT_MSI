using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.ModelsLib
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

        public double MaxPopulation { get; set; } = double.MinValue;
        public double MinPopulation { get; set; } = double.MaxValue;

        public double MaxDensity { get; set; } = double.MinValue;
        public double MinDensity { get; set; } = double.MaxValue;

        public float MaxGINI { get; set; } = float.MinValue;
        public float MinGINI { get; set; } = float.MaxValue;

        public static void SetGINI(float giny)
        {
            if (Instance.MaxGINI < giny)
                Instance.MaxGINI = giny;
            if (Instance.MinGINI > giny)
                Instance.MinGINI = giny;

            SaveFuzzyProps();
        }

        public static void SetDendity(int Population, double Area)
        {
            double Density = Population / (Area + 1);

            if (Instance.MaxDensity < Density)
                Instance.MaxDensity = Density;
            if (Instance.MinDensity > Density)
                Instance.MinDensity = Density;

            SaveFuzzyProps();
        }

        public static void SetPopulation(int Population)
        {
            if (Instance.MaxPopulation < Population)
                Instance.MaxPopulation = Population;
            if (Instance.MinPopulation > Population)
                Instance.MinPopulation = Population;

            SaveFuzzyProps();
        }

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
}
