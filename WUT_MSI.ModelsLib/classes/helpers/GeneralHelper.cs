using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class GeneralHelper
    {
        public static bool CheckIfAnswerHasResult<Tparam>(IAnswer<Tparam> answer,List<Tparam> proccessingSet, Func<Tparam,double> fuzzyFunction)
        {
            return proccessingSet.Any(p=>answer.MatchToAnswer(p,fuzzyFunction));
        }
        public static string GetClimate(double geoWidh)
        {

            return "";
        }
    }
}
