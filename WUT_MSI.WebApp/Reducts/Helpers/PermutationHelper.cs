using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;

namespace WUT_MSI.WebApp.Reducts.Helpers
{
    public class PermutationHelper
    {
        public static List<List<int>> AllPermutations { get; set; }

        public static void GenerateAllPermutations()
        {
            AllPermutations = new List<List<int>>();

            List<int> numbers = new List<int>();
            DbTablesInterface database = new DbTablesInterface();

            for (int i = 0; i < database.GetAttributes(a => true).Length; i++)
                numbers.Add(i);
            
            for (int i = 0; i < (1 << numbers.Count); i++)
            {
                List<int> partial = new List<int>();

                for (int k = 0; k < numbers.Count; k++)
                    if ((i & (1 << k)) > 0)
                        partial.Add(numbers[k]);

                AllPermutations.Add(partial);
            }

            AllPermutations.RemoveAll(l => l.Count == 0 || l.Count == numbers.Count);
        }
    }
}