using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.classes.exceptions;
using WUT_MSI.ModelsLib.interfaces;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class CountryQuestionGetter : IQuestionGetter<ICountry>
    {
        private bool[] IsQuestionUsed { get; }
        private List<IQuestion<ICountry>> Questions { get; }
        private Random random = new Random();

        public CountryQuestionGetter(List<IQuestion<ICountry>> Questions)
        {
            if (Questions == null || Questions.Count==0)
                throw new Exception("parametr Questions nie moze byc pusty");
            this.Questions = Questions;
            IsQuestionUsed = new bool[Questions.Count];
        }

        public bool HasQuestion
        {
            get
            {
                return IsQuestionUsed.Any(t => !t);
            }
        }

        public IQuestion<ICountry> GetNextQuestion(List<ICountry> currentEvaluatingSet)
        {
            var index = random.Next() % Questions.Count;
            var tmp = index;
            while (IsQuestionUsed[index])
            {
                index = (index + 1) % Questions.Count;
                if (tmp == index)
                    throw new NoMoreQuestionsException();
            }
            IsQuestionUsed[index] = true;
            return Questions[index];
        }
    }
}
