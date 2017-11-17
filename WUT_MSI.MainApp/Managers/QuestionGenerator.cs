using System.Collections.Generic;
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
                        new Answer<Country>(0.8, int.MaxValue, "Bardzo daleko")
                    },
                    FuzzyFunctions.DistanceFuzzy.Invoke
                ));

            questions.Add(
                new Question<Country>
                (
                    "Jak klimat dominuje?",
                    new List<IAnswer<Country>>()
                    {
                        new Answer<Country>(0.8, int.MaxValue, "Tropikalny"),
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
                        new Answer<Country>(0.8, int.MaxValue, "Bardzo duży"),
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
                        new Answer<Country>(0.6, int.MaxValue, "Bardzo"),
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
                        new Answer<Country>(0.6, int.MaxValue, "Dużo"),
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
                        new Answer<Country>(0.6, int.MaxValue, "Wysoki"),
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
                        new Answer<Country>(0.7, int.MaxValue, "Wysoki"),
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
                        new Answer<Country>(0.6, int.MaxValue, "Wysoki"),
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
                        new Answer<Country>(0.7, int.MaxValue, "Bardzo"),
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
                        new Answer<Country>(0.7, int.MaxValue, "Dużo"),
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
                        new Answer<Country>(0.7, int.MaxValue, "Duża"),
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
                        new Answer<Country>(0.65, int.MaxValue, "Duży"),
                        new Answer<Country>(0.35, 0.65, "Średni"),
                        new Answer<Country>(0, 0.35, "Mały"),
                   },
                   FuzzyFunctions.JetFuzzy.Invoke
               ));

            return questions;
        }
    }
}
