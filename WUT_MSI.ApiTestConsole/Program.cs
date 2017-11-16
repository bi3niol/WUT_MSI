using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.apis;
using WUT_MSI.ModelsLib.classes.helpers;
using static WUT_MSI.Models.FuzzyFunctions;

namespace WUT_MSI.ApiTestConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(FuzzyProps.Instance.MaxArea);
            Console.WriteLine("Rozpoczynam przygotowanie...");
            var countries = PrepareCountries();
            Console.WriteLine("Przygotowanie Zakończone...\n liczba wczynach panstw {0}\n Pozdrawiam MB",countries.Count);
            SerializationManager sm = new SerializationManager();
            sm.Serialize<List<Country>>(Environment.CurrentDirectory + "/Countries.xml", countries);
            Thread.Sleep(10000);
        }
        private static List<Country> PrepareCountries()
        {
            List<Country> countries = new List<Country>();
            var countriesApi = CountriesApi.GetCountries();
            foreach (var apiC in countriesApi)
            {
                try
                {
                    Console.WriteLine("Przetwarzanie {0}",apiC.name);
                    var tmpC = new Country(apiC);
                    countries.Add(tmpC);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Polecial Exception: {0}", e.Message);
                }
            }
            return countries;
        }
    }
}
