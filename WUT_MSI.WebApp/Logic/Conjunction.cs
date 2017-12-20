using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Logic
{
    public class Conjunction: IExpression
    {
        private List<Alternative> alternatives;

        public Conjunction(List<string> expression)
        {
            alternatives = new List<Alternative>();
            foreach (var element in expression)
                if(!string.IsNullOrWhiteSpace(element))
                alternatives.Add(new Alternative(element));
        }

        public Result GetValue(AttributeType attributeType, int value)
        {
            var temp = alternatives.ToArray();
            foreach(var element in temp)
                switch (element.GetValue(attributeType, value))
                {
                    case Result.True:
                        alternatives.Remove(element);
                        break;
                    case Result.False:
                        return Result.False;
                }

            if (alternatives.Count() == 0)
                return Result.True;

            return Result.NoResult;
        }

        public List<AttributeType> GetAttributes()
        {
            var result = new List<AttributeType>();

            foreach (var element in alternatives)
                result.AddRange(element.GetAttributes());

            return result.Distinct().ToList();
        }
    }
}