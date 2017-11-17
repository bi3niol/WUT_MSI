using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.ModelsLib.classes
{
    public class Question<Tparam> : IQuestion<Tparam> where Tparam : IFuzzy
    {
        public List<IAnswer<Tparam>> Answers { get; }
        public Func<Tparam, double> FuzzyFunction { get; }
        public string DisplayQuestion { get; }

        public IAnswer<Tparam> this[int i]
        {
            get
            {
                return Answers[i];
            }
        }

        public Question(string displayQuestion, List<IAnswer<Tparam>> answers, Func<Tparam, double> fuzzyFunction)
        {
            Answers = answers;
            FuzzyFunction = fuzzyFunction;
            DisplayQuestion = displayQuestion;
        }
    }
}
