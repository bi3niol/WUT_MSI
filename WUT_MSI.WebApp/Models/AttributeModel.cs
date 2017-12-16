using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Models
{
    public class AttributeModel
    {
        public int AttributeId { get; set; }
        public int AttributeValueId { get; private set; }

        public AttributeModel(int id, int value)
        {
            AttributeId = id;
            AttributeValueId = value;
        }
    }
}