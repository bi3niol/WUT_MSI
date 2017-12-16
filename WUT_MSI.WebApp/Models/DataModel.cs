using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Models
{
    public class DataModel
    {
        public long CountryId { get; set; }
        public AttributeModel[] Attributes { get; set; }
    }
}