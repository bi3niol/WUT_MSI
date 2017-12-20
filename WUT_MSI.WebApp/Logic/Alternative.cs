using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Logic
{
    public class Alternative: IExpression
    {
        public List<Factor> factors;

        public Alternative(string expression)
        {
            factors = new List<Factor>();

            string[] elements = expression.Split('_');

            foreach (var element in elements)
                factors.Add(new Factor(int.Parse(element)));
        }

        public Result GetValue(AttributeType attributeType, int value)
        {
            var factor = factors.FirstOrDefault(item => item.AttributeType == attributeType);

            if (factor == null)
                return Result.NoResult;

            if (factor.GetValue(value))
                return Result.True;

            factors.Remove(factor);

            if (factors.Count == 0)
                return Result.False;

            return Result.NoResult;
        }

        public List<AttributeType> GetAttributes()
        {
            var result = new List<AttributeType>();

            foreach (var factor in factors)
                result.Add(factor.AttributeType);

            return result;
        }
    }
}