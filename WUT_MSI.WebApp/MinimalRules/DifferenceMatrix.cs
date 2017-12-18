using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WUT_MSI.WebApp.MinimalRules
{
    public class DifferenceMatrix
    {
        private List<int>[,] matrix;

        public DifferenceMatrix()
        {
            matrix = DifferenceMatrixGenerator.Generate();
        }

        public List<int> this[int i, int k]
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

        public List<int> CalculateValueFor(int i)
        {
            throw new NotImplementedException();
        }
    }
}