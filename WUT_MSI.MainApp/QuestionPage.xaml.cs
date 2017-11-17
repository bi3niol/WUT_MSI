using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.classes;
using WUT_MSI.ModelsLib.classes.exceptions;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.MainApp
{
    /// <summary>
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        public IQuestion<ICountry> Question { get; set; }
        public List<IAnswer<ICountry>> Answers { get; set; }
        private Evaluator<ICountry> evaluator;

        public QuestionPage(Evaluator<ICountry> evaluator)
        {
            InitializeComponent();

            this.evaluator = evaluator;
            Question = evaluator.GetQuestion();
            //Question = new Question<ICountry>("Pytanie", new List<IAnswer<ICountry>>() { new Answer<ICountry>(0, 1, "odpowiedź"), new Answer<ICountry>(0, 1, "odpowiedź") }, null);

            AnswerList.SelectionChanged += AnswerList_SelectionChanged;
            this.DataContext = Question;
        }

        private void AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnswerList.SelectedValue == null) return;
            try
            {

                var question = evaluator[AnswerList.SelectedValue as Answer<ICountry>];
                while (!question.Answers.Any(item => GeneralHelper.CheckIfAnswerHasResult(item, evaluator.CurrentAnswerSet, question.FuzzyFunction)))
                {
                    question = evaluator.GetQuestion();
                }
                Question = question;
                Answers = Question.Answers.Where(i => GeneralHelper.CheckIfAnswerHasResult(i, evaluator.CurrentAnswerSet, Question.FuzzyFunction)).ToList();
                this.DataContext = Question;
                AnswerList.ItemsSource = Answers;
            }
            catch (HasAnswerException)
            {
                NavigationService.Navigate(new ResultPage(evaluator.CurrentAnswerSet));
            }
            catch (NoMoreQuestionsException)
            {
                NavigationService.Navigate(new ResultPage(evaluator.CurrentAnswerSet));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
