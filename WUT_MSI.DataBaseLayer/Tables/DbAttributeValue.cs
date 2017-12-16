using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.DataBaseLayer.Tables
{
    public class DbAttributeValue: Entity<int>
    {
        public string Value { get; set; }
    }
}
