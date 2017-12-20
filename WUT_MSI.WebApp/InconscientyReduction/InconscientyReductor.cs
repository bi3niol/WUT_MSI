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

            for (int i = 0; i < originalMatrix.Length; i++)
                for (int k = i; k < originalMatrix.Length; k++)
                {
                    if (i == k) continue;

                    if (IsInconscienty(beforeMatrix[i], beforeMatrix[k]))
                        if (repetitions.ContainsKey(i)) repetitions[i].Add(k);
                        else repetitions.Add(i, new List<int>() { k });
                }

            /* Dealing with Repetitions */
            foreach (var pair in repetitions)
                ReductInconscientyRecords(maxAttribute, beforeMatrix, pair.Key, pair.Value);

            /* Restoring Matrix Representation */
            string[,] matrix = new string[beforeMatrix.Count, originalMatrix.Length];

            for (int i = 0; i < beforeMatrix.Count; i++)
                for (int k = 0; k < originalMatrix.Length; k++)
                    matrix[i, k] = beforeMatrix[i][k];

            return matrix;
        }

        private static void ReductInconscientyRecords(Reducts.Attribute maxAttribute, List<string[]> beforeMatrix, int key, List<int> value)
        {
            // Dla każdego zestawu rekordów danego państwa, dla których nie zgadza się odpowiedź (przy tych samych wartosciach atrybutów)
            // Wyznacz zbiór W oraz A_W i AW oraz policz przybliżenia.
            // Usuń ten, dla którego przybliżenie górne/dolne jest mniejsze.
        }

        private static bool IsInconscienty(string[] s1, string[] s2)
        {
            for (int i = 0; i < s1.Length; i++)
                if (s1[i] != s2[i])
                    return false;

            return true;
        }
    }
}
