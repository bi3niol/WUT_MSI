using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.Models;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class DiscernabilityMatrixGenerator
    {
        private static string lambda = "";

        public static string[,] Generate()
        {
            DataModel[] dataModel = DataHelper.GetDataModelsFromDb();
            AttributeManager attributeManager = new AttributeManager(dataModel);

            List<int> maxSet = new List<int>();
            for (int i = 0; i < dataModel[0].Attributes.Length; i++)
                maxSet.Add(i);

            Reducts.Attribute maxAttribute = attributeManager.GenerateAttributeSet(maxSet);

            string[,] matrix = new string[dataModel.Length, dataModel.Length];

            for (int i = 0; i < dataModel.Length; i++)
            {
                for (int k = 0; k < dataModel.Length; k++)
                {
                    if(i == k)
                    { matrix[i, k] = null; continue; }

                    string first = dataModel[i].CountryName;
                    string second = dataModel[k].CountryName;

                    if (maxAttribute.AreInSameSet(first, second)) matrix[i, k] = lambda;
                    //else matrix[i, k] = maxAttribute.GetKeyDiffrenceFromValue(first, second);
                    else matrix[i, k] = GetDiffrence(dataModel[i], dataModel[k]);
                }
            }

            return matrix;
        }

        private static string GetDiffrence(DataModel model1, DataModel model2)
        {
            var difference = new List<int>();
            for (int i = 0; i < model1.Attributes.Length; i++)
                if (model1.Attributes[i].AttributeValueId != model2.Attributes[i].AttributeValueId)
                    difference.Add(model1.Attributes[i].AttributeValueId);

            var result = new StringBuilder();
            for(int i=0; i<difference.Count; i++)
            {
                result.Append(difference[i]);
                if (i < difference.Count - 1)
                    result.Append("_");
            }

            return result.ToString();
        }
    }
}
