using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.Models.interfaces;
using WUT_MSI.ModelsLib.classes;

namespace WUT_MSI.MainApp.Managers
{
    public class QuestionGenerator
    {
        public static List<IQuestion<Country>> GetQuestions()
        {
            List<IQuestion<Country>> questions = new List<IQuestion<Country>>();

            questions.Add(
                new Question<Country>
                (
                    "Jak daleko znajduje się państwo?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0, 0.4, "Blisko"),
                        new Answer<Country>(0.4, 0.6, "Średnio"),
                        new Answer<Country>(0.6, 0.8, "Daleko"),
                        new Answer<Country>(0.8, 1, "Bardzo daleko")
                    },
                    FuzzyFunctions.DistanceFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "Jak klimat dominuje?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.8, 1, "Tropikalny"),
                        new Answer<Country>(0.6, 0.8, "Sybtropikalny"),
                        new Answer<Country>(0.3, 0.6, "Umiarkowany"),
                        new Answer<Country>(0, 0.3, "Chłodny")
                    },
                    FuzzyFunctions.ClimeteFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "Jak duży jest kraj?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.8, 1, "Bardzo duży"),
                        new Answer<Country>(0.6, 0.8, "Duży"),
                        new Answer<Country>(0.3, 0.6, "Średni"),
                        new Answer<Country>(0, 0.3, "Mały")
                    },
                    FuzzyFunctions.AreaFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "W jakim stopniu kraj jest rozwinięty?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.6, 1, "Bardzo"),
                        new Answer<Country>(0.35, 0.6, "Średno"),
                        new Answer<Country>(0, 0.35, "Słabo"),
                    },
                    FuzzyFunctions.DevelopementFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "Jak dużo opadów występuje?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.6, 1, "Dużo"),
                        new Answer<Country>(0.35, 0.6, "Umarkowanie"),
                        new Answer<Country>(0, 0.35, "Mało"),
                    },
                    FuzzyFunctions.RainsFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "Jaki jest poziom bezpieczeństwa kraju?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.6, 1, "Wysoki"),
                        new Answer<Country>(0.4, 0.6, "Średni"),
                        new Answer<Country>(0, 0.4, "Niski"),
                    },
                    FuzzyFunctions.SafetyFuzzy.Invoke
                ));

            questions.Add(
               new Question<Country>
               (
                   "Jaki jest poziom medycyny w kraju?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.7, 1, "Wysoki"),
                        new Answer<Country>(0.5, 0.7, "Średni"),
                        new Answer<Country>(0, 0.5, "Niski"),
                   },
                   FuzzyFunctions.MedicineFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Jak duży jest koszt pobytu?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.6, 1, "Wysoki"),
                        new Answer<Country>(0.3, 0.6, "Średni"),
                        new Answer<Country>(0, 0.3, "Niski"),
                   },
                   FuzzyFunctions.MedicineFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Czy państwo jest atrakcyjne turystycznie?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.7, 1, "Bardzo"),
                        new Answer<Country>(0.45, 0.6, "Raczej tak"),
                        new Answer<Country>(0.25, 0.45, "Raczej nie"),
                        new Answer<Country>(0, 0.25, "Wcale"),
                   },
                   FuzzyFunctions.MonumentsFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Jak dużo ludności mieszka w kraju?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.7, 1, "Dużo"),
                        new Answer<Country>(0.35, 0.7, "Raczej nie"),
                        new Answer<Country>(0, 0.35, "Mało"),
                   },
                   FuzzyFunctions.PopulationFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Jaka jest gęstość zaludnienia?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.7, 1, "Duża"),
                        new Answer<Country>(0.45, 0.7, "Średnia"),
                        new Answer<Country>(0, 0.45, "Mała"),
                   },
                   FuzzyFunctions.DensityFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Jak duży chcesz mieć jetlag?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(0.65, 1, "Duży"),
                        new Answer<Country>(0.35, 0.65, "Średni"),
                        new Answer<Country>(0, 0.35, "Mały"),
                   },
                   FuzzyFunctions.JetFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Czy jest wyspą?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(1, 1, "Tak"),
                        new Answer<Country>(0, 0, "Nie"),
                   },
                   FuzzyFunctions.IslandFuzzy.Invoke
               ));

            questions.Add(
               new Question<Country>
               (
                   "Czy występują wulkany?",
                   new List<IAnswer<Country>>()
                   {
                        new Answer<Country>(1, 1, "Tak"),
                        new Answer<Country>(0, 0, "Nie"),
                   },
                   FuzzyFunctions.VuclansFuzzy.Invoke
               ));

            return questions;
        }
    }
}
