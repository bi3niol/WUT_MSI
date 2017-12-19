using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbCountryAttributes: Entity<long>
    {
        [DisplayName("Kraj")]
        public virtual DbCountry Country { get; set; }
        [DisplayName(QuestionStrings.Distance)]
        public virtual DbAttributeValue DistanceAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Climate)]
        public virtual DbAttributeValue ClimateAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Area)]
        public virtual DbAttributeValue AreaAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Development)]
        public virtual DbAttributeValue DevelopmentAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Rains)]
        public virtual DbAttributeValue RainsAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Safety)]
        public virtual DbAttributeValue SafetyAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Medicine)]
        public virtual DbAttributeValue MedicineAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Population)]
        public virtual DbAttributeValue PopulationAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Density)]
        public virtual DbAttributeValue DensityAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Jet)]
        public virtual DbAttributeValue JetAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Sea)]
        public virtual DbAttributeValue SeaAttributeValue { get; set; }

        [DisplayName(QuestionStrings.Mountain)]
        public virtual DbAttributeValue MountainAttributeValue { get; set; }
    }
}
