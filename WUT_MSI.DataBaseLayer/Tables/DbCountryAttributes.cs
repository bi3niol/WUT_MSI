using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbCountryAttributes: Entity<long>
    {
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual DbCountry Country { get; set; }

        [ForeignKey("DistanceAttributeValue")]
        public int DistanceAttributeId { get; set; }
        public virtual DbAttributeValue DistanceAttributeValue { get; set; }

        [ForeignKey("ClimateAttributeValue")]
        public int ClimateAttributeId { get; set; }
        public virtual DbAttributeValue ClimateAttributeValue { get; set; }

        [ForeignKey("AreaAttributeValue")]
        public int AreaAttributeId { get; set; }
        public virtual DbAttributeValue AreaAttributeValue { get; set; }

        [ForeignKey("DevelopmentAttributeValue")]
        public int DevelopmentAttributeId { get; set; }
        public virtual DbAttributeValue DevelopmentAttributeValue { get; set; }

        [ForeignKey("RainsAttributeValue")]
        public int RainsAttributeId { get; set; }
        public virtual DbAttributeValue RainsAttributeValue { get; set; }

        [ForeignKey("SafetyAttributeValue")]
        public int SafetyAttributeId { get; set; }
        public virtual DbAttributeValue SafetyAttributeValue { get; set; }

        [ForeignKey("MedicineAttributeValue")]
        public int MedicineAttributeId { get; set; }
        public virtual DbAttributeValue MedicineAttributeValue { get; set; }

        [ForeignKey("PopulationAttributeValue")]
        public int PopulationAttributeId { get; set; }
        public virtual DbAttributeValue PopulationAttributeValue { get; set; }

        [ForeignKey("DensityAttributeValue")]
        public int DensityAttributeId { get; set; }
        public virtual DbAttributeValue DensityAttributeValue { get; set; }

        [ForeignKey("JetAttributeValue")]
        public int JetAttributeId { get; set; }
        public virtual DbAttributeValue JetAttributeValue { get; set; }

        [ForeignKey("SeaAttributeValue")]
        public int SeaAttributeId { get; set; }
        public virtual DbAttributeValue SeaAttributeValue { get; set; }

        [ForeignKey("MountainAttributeValue")]
        public int MountainAttributeId { get; set; }
        public virtual DbAttributeValue MountainAttributeValue { get; set; }
    }
}
