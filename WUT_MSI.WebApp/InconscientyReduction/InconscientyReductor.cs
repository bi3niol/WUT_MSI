using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.WebApp.Helpers;
using WUT_MSI.WebApp.MinimalRules;
using WUT_MSI.WebApp.Models;
using WUT_MSI.WebApp.Reducts;

namespace WUT_MSI.WebApp.InconscientyReduction
{
    public class InconscientyReductor
    {
        public static string[,] GenerateReducted()
        {
            DataModel[] dataModel = DataHelper.GetDataModelsFromDb();
            AttributeManager attributeManager = new AttributeManager(dataModel);

            List<int> maxSet = new List<int>();
            for (int i = 0; i < dataModel[0].Attributes.Length; i++)
                maxSet.Add(i);

            Reducts.Attribute maxAttribute = attributeManager.GenerateAttributeSet(maxSet);

            /* Original Matrix */
            string[,] originalMatrix = DiscernabilityMatrixGenerator.Generate();
            List<string[]> beforeMatrix = new List<string[]>();

            for (int i = 0; i < originalMatrix.GetLength(0); i++)
            {
                string[] values = new string[originalMatrix.GetLength(1)];

                for (int k = 0; k < originalMatrix.GetLength(1); k++)
                    values[k] = originalMatrix[i, k];

                beforeMatrix.Add(values);
            }

            /* Checking for Repetitions */
            Dictionary<int, List<int>> repetitions = new Dictionary<int, List<int>>();

            for (int i = 0; i < originalMatrix.GetLength(0); i++)
                for (int k = 0; k < originalMatrix.GetLength(1); k++)
                {
                    if (i == k) continue;
                    if (IsInconscienty(beforeMatrix[i], beforeMatrix[k]))
                        if (repetitions.ContainsKey(i)) repetitions[i].Add(k);
                        else repetitions.Add(i, new List<int>() { k });
                }

            if (repetitions.Count == 0)
                return originalMatrix;

            /* Dealing with Repetitions */
            List<List<string[]>> tempBefore = new List<List<string[]>>();

            foreach (var pair in repetitions)
                tempBefore.Add(ReductInconscientyRecords(dataModel, maxAttribute, beforeMatrix, pair.Key, pair.Value));

            List<string[]> resultFromReduct = new List<string[]>();

            foreach (List<string[]> s in tempBefore)
                resultFromReduct = resultFromReduct.Except(s).ToList();

            /* Restoring Matrix Representation */
            string[,] matrix = new string[resultFromReduct.Count, originalMatrix.Length];

            for (int i = 0; i < resultFromReduct.Count; i++)
                for (int k = 0; k < originalMatrix.Length; k++)
                    matrix[i, k] = resultFromReduct[i][k];

            return matrix;
        }

        private static List<string[]> ReductInconscientyRecords(DataModel[] dataModel,
            Reducts.Attribute maxAttribute, List<string[]> beforeMatrix, int key, List<int> value)
        {
            // Dla każdego zestawu rekordów danego państwa, dla których nie zgadza się odpowiedź (przy tych samych wartosciach atrybutów)
            // Wyznacz zbiór W oraz A_W i AW oraz policz przybliżenia.
            // Usuń ten, dla którego przybliżenie górne/dolne jest mniejsze.


            DataModel[] countries = dataModel.Where(c => c.CountryId == key).ToArray(); // Main Country

            List<DataModel[]> restCountries = new List<DataModel[]>();
            restCountries.Add(countries);

            foreach (int v in value)
                restCountries.Add(dataModel.Where(c => c.CountryId.ToString() == beforeMatrix[v][0]).ToArray());

            Dictionary<DataModel[], List<string>> A_WsetDictionary = new Dictionary<DataModel[], List<string>>();
            //Dictionary<DataModel[], List<string>> AWsetDictionary = new Dictionary<DataModel[], List<string>>();

            foreach (DataModel[] model in restCountries) // Model is my W set
            {
                A_WsetDictionary.Add(model, GetA_WSet(maxAttribute, model)); // A_W set
                //AWsetDictionary.Add(model, GetAWSet(maxAttribute, model)); // AW set
            }

            float UPower = dataModel.Length;
            Dictionary<DataModel[], float> approximationValue = new Dictionary<DataModel[], float>();

            foreach (var pair in A_WsetDictionary)
                approximationValue.Add(pair.Key, pair.Value.Count() / UPower);

            float maxValue = approximationValue.Max(p => p.Value);
            approximationValue.OrderByDescending(p => p.Key);

            for (int i = 0; i < approximationValue.Count; i++)
            {
                if (approximationValue.ElementAt(i).Value == maxValue) continue;

                beforeMatrix.RemoveAt(value[i]);
            }

            return beforeMatrix;
        }

        private static List<string> GetAWSet(Reducts.Attribute maxAttribute, DataModel[] model)
        {
            List<string> resultAWset = new List<string>();

            foreach (List<string> names in maxAttribute.Values.Values)
            {
                List<string> modelNames = model.Select(c => c.CountryName).ToList();

                if (ContainsAWset(modelNames, names))
                    resultAWset.AddRange(names);
            }

            return resultAWset;
        }

        private static bool ContainsAWset(List<string> modelNames, List<string> names)
        {
            foreach (string name in names)
                if (modelNames.Contains(name))
                    return true;

            return false;
        }

        private static List<string> GetA_WSet(Reducts.Attribute maxAttribute, DataModel[] model)
        {
            List<string> resultA_Wset = new List<string>();

            foreach (List<string> names in maxAttribute.Values.Values)
            {
                List<string> modelNames = model.Select(c => c.CountryName).ToList();

                if (ContainsA_Wset(modelNames, names))
                    resultA_Wset.AddRange(names);
            }

            return resultA_Wset;
        }

        private static bool ContainsA_Wset(List<string> modelNames, List<string> names)
        {
            foreach (string name in names)
                if (!modelNames.Contains(name))
                    return false;

            return true;
        }

        private static bool IsInconscienty(string[] s1, string[] s2)
        {
            for (int i = 1; i < s1.Length; i++)
                if (s1[i] != s2[i])
                    return false;

            return true;
        }
    }
}
