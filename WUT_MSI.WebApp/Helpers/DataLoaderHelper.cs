using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.WebApp.Helpers
{
    public static class DataLoaderHelper
    {
        public static DataModel[] GetDataModelsFromDb()
        {
            var table = new TablesInterface();
            var result = new List<DataModel>();

            var countries = table.GetCountries(c => true);

            foreach(var country in countries)
            {
                var attribute = table.GetCountryAttributes(country)
                    .OrderBy(item=>item.Attribute.Id)
                    .Select(item=>new AttributeModel(item.Attribute.Id,item.Value.Id))
                    .ToArray();
                result.Add(new DataModel { CountryId = country.Id, Attributes = attribute });
            }

            return result.ToArray();
        }
    }
}