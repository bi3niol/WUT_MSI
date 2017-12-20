using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class DiscernabilityMatrix
    {
        private string[,] matrix;

        public DiscernabilityMatrix()
        {
            matrix = InconscientyReduction.InconscientyReductor.GenerateReducted();
        }

        public int GetLength(int i) => matrix.GetLength(i);

        public string this[int i, int k]
        {
            get
            {
                if (i >= matrix.GetLength(0) || k >= matrix.GetLength(1))
                    return null;

                return matrix[i, k];
            }

            set
            {
                if (i < matrix.GetLength(0) || k < matrix.GetLength(1))
                    matrix[i, k] = value;
            }
        }

        public List<string> CalculateValueFor(int i)
        {
            List<string> function = new List<string>();

            for (int k = 0; k < matrix.GetLength(1); k++)
                function.Add(matrix[i, k]);
            
            return function.Distinct().ToList();
        }
    }
}
