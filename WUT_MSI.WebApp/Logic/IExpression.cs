using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Logic
{
    public interface IExpression
    {
        Result GetValue(AttributeType attributeType, int value);
        List<AttributeType> GetAttributes();
    }
}