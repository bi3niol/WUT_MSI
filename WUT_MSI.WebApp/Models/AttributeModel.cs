using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Models
{
    public class AttributeModel
    {
        public AttributeType AttributeId { get; set; }
        public int AttributeValueId { get; set; }
        public string AttributeValue { get; set; }

        public AttributeModel(AttributeType id, int value, string attributeValue)
        {
            AttributeId = id;
            AttributeValueId = value;
            AttributeValue = attributeValue;
        }
    }
}