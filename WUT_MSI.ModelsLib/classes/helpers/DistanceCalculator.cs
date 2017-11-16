using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models.classes.helpers
{
    public static class DistanceCalculator
    {
        private const double EarthCircuit = 40075.704;
        public static double GetDistance(double width1, double length1, double width2,double length2)
        {
            return Math.Sqrt((Math.Pow(width2 - width1, 2) + Math.Pow(Math.Cos(width1 * Math.PI / 180) * (length2 - length1), 2)))*EarthCircuit/360;
        }
    }
}
