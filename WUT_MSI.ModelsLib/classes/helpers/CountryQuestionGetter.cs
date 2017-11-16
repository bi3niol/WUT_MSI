using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models.classes;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.interfaces;

namespace WUT_MSI.ModelsLib.classes.helpers
{
    public class CountryQuestionGetter : IQuestionGetter<Country>
    {
        private bool[] IsQuestionUsed { get; }
        private List<IQuestion<Country>> Questions { get; }
        private Random random = new Random();

        public CountryQuestionGetter(List<IQuestion<Country>> Questions)
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

        public IQuestion<Country> GetNextQuestion(List<Country> currentEvaluatingSet)
        {
            var index = random.Next() % Questions.Count;
            while (IsQuestionUsed[index])
                index = (index + 1) % Questions.Count;
            return Questions[index];
        }
    }
}
