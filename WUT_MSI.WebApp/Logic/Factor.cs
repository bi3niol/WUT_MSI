using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Helpers;

namespace WUT_MSI.WebApp.Logic
{
    public class Factor
    {
        private int value;

        public AttributeType AttributeType { get; set; }

        public Factor(int value)
        {
            this.value = value;
            AttributeType = AnswearHelper.Convert(value);
        }

        public bool GetValue(int attributeValue)
        {
            return value == attributeValue;
        }
    }
}