using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.Models
{
    public static class FuzzyFunctions
    {
        
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
