using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WUT_MSI.Models.classes;
using System.Net;

/// <summary>
/// Api Url
/// https://restcountries.eu/rest/v2
/// </summary>
namespace WUT_MSI.ModelsLib.apis
{
    public class CountriesApi
    {
        public static List<ApiCountry> GetCountries()
        {
            List<ApiCountry> res = new List<ApiCountry>();
            using(var client = new WebClient())
            {
                string json = client.DownloadString("https://restcountries.eu/rest/v2/all");
                res = JsonConvert.DeserializeObject<List<ApiCountry>>(json);
            }
            return res;
        }
    }
}
