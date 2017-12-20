using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WUT_MSI.DataBaseLayer;
using WUT_MSI.WebApp.Logic;
using WUT_MSI.WebApp.MinimalRules;

namespace WUT_MSI.WebApp.Helpers
{
    public static class QuestionHelper
    {
        private static AttributeType LastQuestion;
        private static Dictionary<Conjunction, string> CurrentRules;
        private static MinimalRule[] MinimalRules;
        private static List<AttributeType> Questions;

        public static void Initialize(List<MinimalRule> list)
        {
            MinimalRules = list.ToArray();
        }

        public static void StartGenerate()
        {
            CurrentRules = new Dictionary<Conjunction, string>();

            foreach (var element in MinimalRules)
                CurrentRules.Add(new Conjunction(element.Function), element.Name);

            Questions = CurrentRules.First().Key.GetAttributes();
        }

        public static KeyValuePair<bool,string> SetAnswear(int answear)
        {
            var rules = CurrentRules.ToArray();
            foreach(var element in rules)
            {
                switch (element.Key.GetValue(LastQuestion, answear))
                {
                    case Result.True:
                        return new KeyValuePair<bool, string>(true, element.Value);
                    case Result.False:
                        CurrentRules.Remove(element.Key);
                        break;
                }
            }

            if (CurrentRules.Count() == 0)
                return new KeyValuePair<bool, string>(false, null);

            if(CurrentRules.Count()==1)
                return new KeyValuePair<bool, string>(true, CurrentRules.First().Value);

            return new KeyValuePair<bool, string>(false, null);
        }

        public static AttributeType GetNextQuestion()
        {
            if (Questions.Count() == 0)
                Questions = CurrentRules.First().Key.GetAttributes();

            LastQuestion = Questions.First();
            Questions.Remove(LastQuestion);

            return LastQuestion;
        }
    }
}