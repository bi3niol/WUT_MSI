using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.DataBaseLayer.Tables;
using WUT_MSI.Models.classes;

namespace WUT_MSI.DataBaseGenerator
{
    public class Question
    {
        public Func<Country, double> Function { get; set; }
        public AttributeType AttributeType { get; set; }
        public List<Answear> Answears { get; set; }
        public double MatchingValue { get; set; }

        public int Length
        {
            get { return Answears.Count(); }
        }

        public Answear this[int index]
        {
            get { return Answears[index]; }
        }
    }

    public class Answear
    {
        private double min;
        private double max;

        public DbAttributeValue Value { get; }

        public Answear(DbAttributeValue value, double min, double max)
        {
            Value = value;
            this.min = min;
            this.max = max;
        }

        public double Matching(Country country, Func<Country, double> Function)
        {
            double value = Function(country);
            return (1 - 2 * Math.Abs((min + max) / 2 - value) / (max - min));
        }
    }
}
