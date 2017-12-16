using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Models
{
    public class AttributeModel
    {
        public AttributeType AttributeType { get; private set; }
        public int Value { get; private set; }

        public AttributeModel(AttributeType attributeType, int value)
        {
            AttributeType = attributeType;
            Value = value;
        }
    }
}