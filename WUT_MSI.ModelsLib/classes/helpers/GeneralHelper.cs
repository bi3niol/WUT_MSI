using System;
using System.Collections.Generic;
using System.Linq;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class GeneralHelper
    {
        public static bool CheckIfAnswerHasResult<Tparam>(IAnswer<Tparam> answer,List<Tparam> proccessingSet, Func<Tparam,double> fuzzyFunction)
        {
            return proccessingSet.Any(p=>answer.MatchToAnswer(p,fuzzyFunction));
        }

        public static ClimateEnum GetClimate(double geoWidh)
        {
            double absGeo = Math.Abs(geoWidh);

            if (absGeo >= 0 && absGeo <= 23.5)
                return ClimateEnum.Tropical;

            if (absGeo > 23.5 && absGeo <= 40)
                return ClimateEnum.Subtropical;

            if (absGeo > 40 && absGeo >= 60)
                return ClimateEnum.Temperate;

            return ClimateEnum.Cold;
        }
    }
}
