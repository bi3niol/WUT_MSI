using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.WebApp.Models;

namespace WUT_MSI.WebApp.Helpers
{
    public static class DataHelper
    {
        private static DbTablesInterface db;

        static DataHelper()
        {
            db = new DbTablesInterface();
        }

        public static DataModel[] GetDataModelsFromDb()
        {
            var result = new List<DataModel>();

            foreach (var element in db.GetCountryAttributes(item => true))
                result.Add(new DataModel
                {
                    CountryId = element.Country.Id,
                    CountryName = element.Country.Name,
                    Attributes = new AttributeModel[]
                    {
                        MapToAttributeModel(AttributeType.Distance, element.DistanceAttributeValue),
                        MapToAttributeModel(AttributeType.Climate, element.ClimateAttributeValue),
                        MapToAttributeModel(AttributeType.Area, element.AreaAttributeValue),
                        MapToAttributeModel(AttributeType.Development, element.DevelopmentAttributeValue),
                        MapToAttributeModel(AttributeType.Rains, element.RainsAttributeValue),
                        MapToAttributeModel(AttributeType.Safety, element.SafetyAttributeValue),
                        MapToAttributeModel(AttributeType.Medicine, element.MedicineAttributeValue),
                        MapToAttributeModel(AttributeType.Population, element.PopulationAttributeValue),
                        MapToAttributeModel(AttributeType.Density, element.DensityAttributeValue),
                        MapToAttributeModel(AttributeType.Jet, element.JetAttributeValue),
                        MapToAttributeModel(AttributeType.Sea, element.SeaAttributeValue),
                        MapToAttributeModel(AttributeType.Mountain, element.MountainAttributeValue),
                    },
                });

            return result.ToArray();
        }

        private static AttributeModel MapToAttributeModel(AttributeType type, DbAttributeValue value)
        {
            return new AttributeModel(AttributeType.Mountain, value.Id, value.Value);
        }
    }
}