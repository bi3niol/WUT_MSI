using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.ModelsLib.classes
{
    public class Monument
    {
        public string country { get; set; }
        public string lang { get; set; }
        public string project { get; set; }
        public string id { get; set; }
        public string adm0 { get; set; }
        public string adm1 { get; set; }
        public string adm2 { get; set; }
        public string adm3 { get; set; }
        public string adm4 { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string municipality { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string image { get; set; }
        public string commonscat { get; set; }
        public string source { get; set; }
        public string monument_article { get; set; }
        public object wd_item { get; set; }
        public string registrant_url { get; set; }
        public string changed { get; set; }
    }
    public class TotalMonuments
    {
        public string country { get; set; }
        public string municipality { get; set; }
        public string st_total { get; set; }
    }
    public class Continue
    {
        public string srcontinue { get; set; }
    }

    public class RootObject
    {
        public List<Monument> monuments { get; set; }
        public Continue @continue { get; set; }
    }
}
