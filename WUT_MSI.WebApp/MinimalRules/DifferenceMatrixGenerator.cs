using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.Models;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class DifferenceMatrixGenerator
    {
        private static List<int> lambda = new List<int>() { -1 };

        public static List<int>[,] Generate()
        {
            DataModel[] dataModel = DataHelper.GetDataModelsFromDb();
            AttributeManager attributeManager = new AttributeManager(dataModel);

            List<int> maxSet = new List<int>();
            for (int i = 0; i < dataModel[0].Attributes.Length; i++)
                maxSet.Add(i);

            Reducts.Attribute maxAttribute = attributeManager.GenerateAttributeSet(maxSet);

            List<int>[,] matrix = new List<int>[dataModel.Length, dataModel.Length];

            for (int i = 0; i < dataModel.Length; i++)
            {
                for (int k = 0; k < dataModel.Length; k++)
                {
                    string first = dataModel[i].CountryName;
                    string second = dataModel[k].CountryName;

                    if (maxAttribute.AreInSameSet(first, second)) matrix[i, k] = lambda;
                    else matrix[i, k] = maxAttribute.GetKeyDiffrenceFromValue(first, second);
                }
            }

            return matrix;
        }
    }
}