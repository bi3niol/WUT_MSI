using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbAttribute: Entity<AttributeType>
    {
        public string Name { get; set; }
        public virtual ICollection<DbAttributeValue> AttributeValues { get; set; }
    }
}
