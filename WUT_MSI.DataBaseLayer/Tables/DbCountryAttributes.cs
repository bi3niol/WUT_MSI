using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbCountryAttributes: Entity<long>
    {
        public virtual DbCountry Country { get; set; }
        public virtual DbAttribute Attribute { get; set; }
        public virtual DbAttributeValue Value { get; set; }
    }
}
