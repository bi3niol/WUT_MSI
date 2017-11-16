using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models.classes;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.classes.exceptions;
using WUT_MSI.ModelsLib.interfaces;

namespace WUT_MSI.ModelsLib.classes
{
    public class Evaluator<Tparam>
    {
        private List<Tparam> CurrentAnswerSet { get; set; }
        private IQuestionGetter<Tparam> QuestionGetter { get; }
        public Evaluator(IQuestionGetter<Tparam> questionGetter)
        {
            if (questionGetter == null)
                throw new Exception("parametr QuestionGetter nie moze byc nullem");
            QuestionGetter = questionGetter;
        }

        public void SetEvaluatingSet(List<Tparam> evaluatingSet)
        {
            CurrentAnswerSet = evaluatingSet;
        }

        public IQuestion<Tparam> GetQuestion()
        {
            if (!QuestionGetter.HasQuestion)
                throw new NoMoreQuestionsException();
            return QuestionGetter.GetNextQuestion(CurrentAnswerSet);
        }
    }
}
