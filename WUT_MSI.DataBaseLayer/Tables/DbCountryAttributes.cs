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
        [NotMapped]
        public int Country_Id { get; set; }
        public virtual DbCountry Country { get; set; }

        //[ForeignKey("DistanceAttributeValue")]
        [Required]
        [NotMapped]
        public int DistanceAttribute_Id { get; set; }
        public virtual DbAttributeValue DistanceAttributeValue { get; set; }

        //[ForeignKey("ClimateAttributeValue")]
        [Required]
        [NotMapped]
        public int ClimateAttribute_Id { get; set; }
        public virtual DbAttributeValue ClimateAttributeValue { get; set; }

        //[ForeignKey("AreaAttributeValue")]
        [Required]
        [NotMapped]
        public int AreaAttribute_Id { get; set; }
        public virtual DbAttributeValue AreaAttributeValue { get; set; }

        //[ForeignKey("DevelopmentAttributeValue")]
        [Required]
        [NotMapped]
        public int DevelopmentAttribute_Id { get; set; }
        public virtual DbAttributeValue DevelopmentAttributeValue { get; set; }

        //[ForeignKey("RainsAttributeValue")]
        [Required]
        [NotMapped]
        public int RainsAttribute_Id { get; set; }
        public virtual DbAttributeValue RainsAttributeValue { get; set; }

        //[ForeignKey("SafetyAttributeValue")]
        [Required]
        [NotMapped]
        public int SafetyAttribute_Id { get; set; }
        public virtual DbAttributeValue SafetyAttributeValue { get; set; }

        //[ForeignKey("MedicineAttributeValue")]
        [Required]
        [NotMapped]
        public int MedicineAttribute_Id { get; set; }
        public virtual DbAttributeValue MedicineAttributeValue { get; set; }

        //[ForeignKey("PopulationAttributeValue")]
        [Required]
        [NotMapped]
        public int PopulationAttribute_Id { get; set; }
        public virtual DbAttributeValue PopulationAttributeValue { get; set; }

        //[ForeignKey("DensityAttributeValue")]
        [Required]
        [NotMapped]
        public int DensityAttribute_Id { get; set; }
        public virtual DbAttributeValue DensityAttributeValue { get; set; }

        //[ForeignKey("JetAttributeValue")]
        [Required]
        [NotMapped]
        public int JetAttribute_Id { get; set; }
        public virtual DbAttributeValue JetAttributeValue { get; set; }

        //[ForeignKey("SeaAttributeValue")]
        [Required]
        [NotMapped]
        public int SeaAttribute_Id { get; set; }
        public virtual DbAttributeValue SeaAttributeValue { get; set; }

        //[ForeignKey("MountainAttributeValue")]
        [Required]
        [NotMapped]
        public int MountainAttribute_Id { get; set; }
        public virtual DbAttributeValue MountainAttributeValue { get; set; }
    }
}
