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

        private static AttributeType StartGenerate()
        {
            CurrentRules = new Dictionary<Conjunction, string>();

            foreach (var element in MinimalRules)
                CurrentRules.Add(new Conjunction(element.Function), element.Name);

            Questions = CurrentRules.First().Key.GetAttributes();

            LastQuestion = Questions.First();
            Questions.Remove(LastQuestion);

            return LastQuestion;
        }

        private static GetQuestionResult GetNextQuestion(int answear)
        {
            var rules = CurrentRules.ToArray();
            foreach(var element in rules)
            {
                switch (element.Key.GetValue(LastQuestion, answear))
                {
                    case Result.True:
                        return new GetQuestionResult
                        {
                            Result = QuestionResult.Answear,
                            Countries = new string[] { element.Value },
                        };
                    case Result.False:
                        CurrentRules.Remove(element.Key);
                        break;
                }
            }

            if (CurrentRules.Count() == 0)
                return new GetQuestionResult
                {
                    Result = QuestionResult.NoAnswear,
                };

            if(CurrentRules.Count()==1)
                return new GetQuestionResult
                {
                    Result = QuestionResult.Answear,
                    Countries = new string[] { CurrentRules.First().Value },
                };

            if (Questions.Count() == 0)
                Questions = CurrentRules.First().Key.GetAttributes();

            LastQuestion = Questions.First();
            Questions.Remove(LastQuestion);

            return new GetQuestionResult
            {
                Result = QuestionResult.Question,
                Question = LastQuestion,
            };
        }
    }

    public class GetQuestionResult
    {
        public QuestionResult Result { get; set; }
        public string[] Countries { get; set; }
        public AttributeType Question { get; set; }
    }
    public enum QuestionResult
    {
        /// <summary>
        /// Daje następne pytanie
        /// </summary>
        Question,
        /// <summary>
        /// Nie ma pasującej odpowiedzi
        /// </summary>
        NoAnswear,
        /// <summary>
        /// Jest odpowiedź
        /// </summary>
        Answear
    }
}