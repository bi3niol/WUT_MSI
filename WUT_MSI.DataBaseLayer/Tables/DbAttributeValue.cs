using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbAttributeValue: Entity<int>
    {
        //[ForeignKey("ParentAttribute")]
        //public AttributeType ParentAttributeId { get; set; }
        //public DbAttribute ParentAttribute { get; set; }
        public string Value { get; set; }
    }
}
