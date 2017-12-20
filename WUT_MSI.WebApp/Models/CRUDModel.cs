using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Kraj")]
        public int Country_Id { get; set; }
        public IEnumerable<SelectListItem> CountryId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Distance)]
        public int DistanceAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DistanceAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Climate)]
        public int ClimateAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> ClimateAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Area)]
        public int AreaAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> AreaAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Development)]
        public int DevelopmentAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DevelopmentAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Rains)]
        public int RainsAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> RainsAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Safety)]
        public int SafetyAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> SafetyAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Medicine)]
        public int MedicineAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> MedicineAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Population)]
        public int PopulationAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> PopulationAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Density)]
        public int DensityAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> DensityAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Jet)]
        public int JetAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> JetAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Sea)]
        public int SeaAttribute_Id { get; set; }
        public IEnumerable<SelectListItem> SeaAttributeId { get; set; }
        [Required]
        [DisplayName(QuestionStrings.Mountain)]
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
                res = db.GetCountryAttributes(Id);
            }

            res.JetAttributeValue = db.GetAttributeValue(JetAttribute_Id);
            res.MedicineAttributeValue = db.GetAttributeValue(MedicineAttribute_Id);
            res.MountainAttributeValue = db.GetAttributeValue(MountainAttribute_Id);
            res.PopulationAttributeValue = db.GetAttributeValue(PopulationAttribute_Id);
            res.RainsAttributeValue = db.GetAttributeValue(RainsAttribute_Id);
            res.SafetyAttributeValue = db.GetAttributeValue(SafetyAttribute_Id);
            res.SeaAttributeValue = db.GetAttributeValue(SeaAttribute_Id);
            res.AreaAttributeValue = db.GetAttributeValue(AreaAttribute_Id);
            res.ClimateAttributeValue = db.GetAttributeValue(ClimateAttribute_Id);
            res.Country = db.GetCountry(Country_Id);
            res.DensityAttributeValue = db.GetAttributeValue(DensityAttribute_Id);
            res.DevelopmentAttributeValue = db.GetAttributeValue(DevelopmentAttribute_Id);
            res.DistanceAttributeValue = db.GetAttributeValue(DistanceAttribute_Id);

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