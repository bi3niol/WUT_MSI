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
        public virtual DbCountry Country { get; set; }
        public virtual DbAttributeValue DistanceAttributeValue { get; set; }
        public virtual DbAttributeValue ClimateAttributeValue { get; set; }
        public virtual DbAttributeValue AreaAttributeValue { get; set; }
        public virtual DbAttributeValue DevelopmentAttributeValue { get; set; }
        public virtual DbAttributeValue RainsAttributeValue { get; set; }
        public virtual DbAttributeValue SafetyAttributeValue { get; set; }
        public virtual DbAttributeValue MedicineAttributeValue { get; set; }
        public virtual DbAttributeValue PopulationAttributeValue { get; set; }
        public virtual DbAttributeValue DensityAttributeValue { get; set; }
        public virtual DbAttributeValue JetAttributeValue { get; set; }
        public virtual DbAttributeValue SeaAttributeValue { get; set; }
        public virtual DbAttributeValue MountainAttributeValue { get; set; }
    }
}
