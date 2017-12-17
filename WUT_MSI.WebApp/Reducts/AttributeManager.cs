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

        public List<Attribute> CalculateReducts()
        {
            if (countries == null || countries.Count == 0)
                return null;

            if (PermutationHelper.AllPermutations == null)
                PermutationHelper.GenerateAllPermutations();

            List<Attribute> reducts = new List<Attribute>();
            List<int> maxSet = new List<int>();
            
            for (int i = 0; i < countries[0].Attributes.Count(); i++)
                maxSet.Add(i);

            Attribute maxReduct = GenerateAttributeSet(maxSet);

            foreach (List<int> set in PermutationHelper.AllPermutations)
            {
                Attribute currentAttribute = GenerateAttributeSet(set);

                if (currentAttribute.CheckIfIsNeeded(maxReduct))
                    reducts.Add(currentAttribute);
            }

            return reducts;
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