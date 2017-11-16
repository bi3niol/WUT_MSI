using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WUT_MSI.ModelsLib.apis;

namespace WUT_MSI.ApiTestConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var res = CountriesApi.GetCountries();
            var res2 = MonumentsAPi.GetMonumentsCount("pl");
            if (true)
            {
               // Console.WriteLine(res.Count);
                Console.WriteLine(MonumentsAPi.GetMonumentsCount("ru"));
                Console.WriteLine(MonumentsAPi.GetMonumentsCount("LK"));
            }
            else
                Console.WriteLine("cos nei pykllo");
            Thread.Sleep(5000);
        }
    }
}
