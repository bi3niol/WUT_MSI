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
        public static DataModel[] GetDataModelsFromDb()
        {
            var table = new DbTablesInterface();
            var result = new List<DataModel>();

            foreach (var element in table.GetCountryAttributes(item => true))
                result.Add(new DataModel
                {
                    CountryId = element.Country.Id,
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

        public static void AddDataModel(DataModel model)
        {

        }
        public static void UpdateDataModel(DataModel model)
        {

        }
        public static void RemoveDataModel(long id)
        {

        }
    }
}