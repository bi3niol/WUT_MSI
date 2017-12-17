using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Models
{
    public class DataModel
    {
        public long Id { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public AttributeModel[] Attributes { get; set; }
    }
}