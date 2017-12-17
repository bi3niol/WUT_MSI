using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbCountryAttributes: Entity<long>
    {
        //[ForeignKey("Country")]
        [Required]
        public int Country_Id { get; set; }
        public virtual DbCountry Country { get; set; }

        //[ForeignKey("DistanceAttributeValue")]
        [Required]
        public int DistanceAttribute_Id { get; set; }
        public virtual DbAttributeValue DistanceAttributeValue { get; set; }

        //[ForeignKey("ClimateAttributeValue")]
        [Required]
        public int ClimateAttribute_Id { get; set; }
        public virtual DbAttributeValue ClimateAttributeValue { get; set; }

        //[ForeignKey("AreaAttributeValue")]
        [Required]
        public int AreaAttribute_Id { get; set; }
        public virtual DbAttributeValue AreaAttributeValue { get; set; }

        //[ForeignKey("DevelopmentAttributeValue")]
        [Required]
        public int DevelopmentAttribute_Id { get; set; }
        public virtual DbAttributeValue DevelopmentAttributeValue { get; set; }

        //[ForeignKey("RainsAttributeValue")]
        [Required]
        public int RainsAttribute_Id { get; set; }
        public virtual DbAttributeValue RainsAttributeValue { get; set; }

        //[ForeignKey("SafetyAttributeValue")]
        [Required]
        public int SafetyAttribute_Id { get; set; }
        public virtual DbAttributeValue SafetyAttributeValue { get; set; }

        //[ForeignKey("MedicineAttributeValue")]
        [Required]
        public int MedicineAttribute_Id { get; set; }
        public virtual DbAttributeValue MedicineAttributeValue { get; set; }

        //[ForeignKey("PopulationAttributeValue")]
        [Required]
        public int PopulationAttribute_Id { get; set; }
        public virtual DbAttributeValue PopulationAttributeValue { get; set; }

        //[ForeignKey("DensityAttributeValue")]
        [Required]
        public int DensityAttribute_Id { get; set; }
        public virtual DbAttributeValue DensityAttributeValue { get; set; }

        //[ForeignKey("JetAttributeValue")]
        [Required]
        public int JetAttribute_Id { get; set; }
        public virtual DbAttributeValue JetAttributeValue { get; set; }

        //[ForeignKey("SeaAttributeValue")]
        [Required]
        public int SeaAttribute_Id { get; set; }
        public virtual DbAttributeValue SeaAttributeValue { get; set; }

        //[ForeignKey("MountainAttributeValue")]
        [Required]
        public int MountainAttribute_Id { get; set; }
        public virtual DbAttributeValue MountainAttributeValue { get; set; }
    }
}
