using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.ModelsLib.classes;

namespace WUT_MSI.ModelsLib.apis
{
    public static class MonumentsAPi
    {
        public static ulong GetMonumentsCount(string countryCode)
        {
            List<TotalMonuments> res = new List<TotalMonuments>();
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string path = $"https://tools.wmflabs.org/heritage/api/api.php?action=statistics&stcountry={countryCode}&format=json&limit=0&stitem=total";
                string json = client.DownloadString(path);
                json = json.Replace("{\"monuments\":", "");
                if (json.Length > 2)
                    json = json.Substring(0, json.Length - 1);
                res = JsonConvert.DeserializeObject<List<TotalMonuments>>(json);
            }
            return (ulong)res.Sum(tm => double.Parse(tm.st_total));
        }
    }
}
