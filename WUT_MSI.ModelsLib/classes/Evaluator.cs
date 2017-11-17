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
        public List<Tparam> CurrentAnswerSet { get; private set; }
        private IQuestionGetter<Tparam> QuestionGetter { get; }
        private IQuestion<Tparam> CurrentProccessingQuestion;
        public Evaluator(IQuestionGetter<Tparam> questionGetter)
        {
            if (questionGetter == null)
                throw new Exception("parametr QuestionGetter nie moze byc nullem");
            QuestionGetter = questionGetter;
            CurrentProccessingQuestion = QuestionGetter.GetNextQuestion(CurrentAnswerSet);
        }

        public void SetEvaluatingSet(List<Tparam> evaluatingSet)
        {
            CurrentAnswerSet = evaluatingSet;
        }

        public IQuestion<Tparam> this[IAnswer<Tparam> answer]
        {
            get
            {
                CurrentAnswerSet = answer.CutSet(CurrentAnswerSet, CurrentProccessingQuestion.FuzzyFunction);
                if (CurrentAnswerSet.Count <= 5)
                    throw new HasAnswerException();
                if (!QuestionGetter.HasQuestion)
                    throw new NoMoreQuestionsException();
                CurrentProccessingQuestion = QuestionGetter.GetNextQuestion(CurrentAnswerSet);
                return CurrentProccessingQuestion;
            }
        }

        public IQuestion<Tparam> GetQuestion()
        {
            if (!QuestionGetter.HasQuestion)
                throw new NoMoreQuestionsException();
            CurrentProccessingQuestion = QuestionGetter.GetNextQuestion(CurrentAnswerSet);
            return CurrentProccessingQuestion;
        }

        public List<Tparam> GetAnswerSet()
        {
            return CurrentAnswerSet.ToList();
        }
    }
}
