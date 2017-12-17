using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.Reducts.Helpers
{
    public class PermutationHelper
    {
        public static List<List<int>> AllPermutations { get; set; }

        public static void GenerateAllPermutations()
        {
            AllPermutations = new List<List<int>>();

            List<int> numbers = new List<int>();

            for (int i = 0; i < 12; i++)
                numbers.Add(i);
            
            for (int i = 0; i < (1 << numbers.Count); i++)
            {
                List<int> partial = new List<int>();

                for (int k = 0; k < numbers.Count; k++)
                    if ((i & (1 << k)) > 0)
                        partial.Add(numbers[k]);

                AllPermutations.Add(partial);
            }
        }
    }
}