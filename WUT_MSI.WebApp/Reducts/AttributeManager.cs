using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WUT_MSI.WebApp.Models;
using WUT_MSI.WebApp.Reducts.Helpers;

namespace WUT_MSI.WebApp.Reducts
{
    public class AttributeManager
    {
        private List<DataModel> countries;

        public AttributeManager(DataModel[] attributes)
        {
            countries = new List<DataModel>(attributes);
        }

        public void CalculateReducts()
        {
            if (PermutationHelper.AllPermutations == null)
                PermutationHelper.GenerateAllPermutations();

            foreach (List<int> set in PermutationHelper.AllPermutations)
            {

            }
        }

        private Attribute GenerateAttributeSet(List<int> setRange)
        {
            Attribute attribute = new Attribute(setRange);

            foreach (DataModel country in countries)
            {
                StringBuilder builder = new StringBuilder();

                foreach (int attributeId in setRange)
                    builder.Append(country.Attributes[attributeId].AttributeValueId);

                attribute.AddPair(builder.ToString(), country.CountryName);
            }

            return attribute;
        }
    }
}