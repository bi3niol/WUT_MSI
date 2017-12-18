using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.WebApp.Models
{
    public class CRUDModel
    {
        public long Id { get; set; }
        [Required]
        public int Country_Id { get; set; }
        public IEnumerable<SelectListItem> CountryId { get; set; }
        [Required]
        public int DistanceAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DistanceAttributeId { get; set; }
        [Required]
        public int ClimateAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> ClimateAttributeId { get; set; }
        [Required]
        public int AreaAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> AreaAttributeId { get; set; }
        [Required]
        public int DevelopmentAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DevelopmentAttributeId { get; set; }
        [Required]
        public int RainsAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> RainsAttributeId { get; set; }
        [Required]
        public int SafetyAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> SafetyAttributeId { get; set; }
        [Required]
        public int MedicineAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> MedicineAttributeId { get; set; }
        [Required]
        public int PopulationAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> PopulationAttributeId { get; set; }
        [Required]
        public int DensityAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DensityAttributeId { get; set; }
        [Required]
        public int JetAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> JetAttributeId { get; set; }
        [Required]
        public int SeaAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> SeaAttributeId { get; set; }
        [Required]
        public int MountainAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> MountainAttributeId { get; set; }

        public DbCountryAttributes UpdateOrCreateCountryAttributes(DbTablesInterface db,bool isNew=false)
        {
            DbCountryAttributes res;
            if (isNew)
            {
                res = new DbCountryAttributes();
            }
            else
            {
                res = null;
            }


            if (isNew)
                res = db.AddCountryAttributes(res);
            else
                db.Apply();           

            return res;
        }

        public static CRUDModel GedModel(DbCountryAttributes dbCountry)
        {
            return new CRUDModel()
            {
                AreaAttribute_Id = dbCountry.AreaAttributeValue.Id,
                Id = dbCountry.Id,
                ClimateAttribute_Id = dbCountry.ClimateAttributeValue.Id,
                Country_Id = dbCountry.Country.Id,
                DensityAttribute_Id = dbCountry.DensityAttributeValue.Id,
                DevelopmentAttribute_Id = dbCountry.DevelopmentAttributeValue.Id,
                DistanceAttribute_Id = dbCountry.DistanceAttributeValue.Id,
                JetAttribute_Id = dbCountry.JetAttributeValue.Id,
                MedicineAttribute_Id = dbCountry.MedicineAttributeValue.Id,
                MountainAttribute_Id = dbCountry.MountainAttributeValue.Id,
                PopulationAttribute_Id=dbCountry.PopulationAttributeValue.Id,
                RainsAttribute_Id=dbCountry.RainsAttributeValue.Id,
                SafetyAttribute_Id=dbCountry.SafetyAttributeValue.Id,
                SeaAttribute_Id=dbCountry.SeaAttributeValue.Id                
            };
        }
    }
}