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
        public static List<IQuestion<ICountry>> GetQuestions()
        {
            List<IQuestion<ICountry>> questions = new List<IQuestion<ICountry>>();

            questions.Add(
                new Question<ICountry>
                (
                    "Jak daleko znajduje się państwo?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0, 0.4, "Blisko"),
                        new Answer<ICountry>(0.4, 0.6, "Średnio"),
                        new Answer<ICountry>(0.6, 0.8, "Daleko"),
                        new Answer<ICountry>(0.8, 1, "Bardzo daleko")
                    },
                    FuzzyFunctions.DistanceFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak temperatura dominuje?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.8, 1, "Wysoka"),
                        new Answer<ICountry>(0.6, 0.8, "Srednia"),
                        new Answer<ICountry>(0.3, 0.6, "umiarkowana"),
                        new Answer<ICountry>(0, 0.3, "niska")
                    },
                    FuzzyFunctions.ClimeteFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak duży jest kraj?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.8,1, "Bardzo duży"),
                        new Answer<ICountry>(0.6, 0.8, "Duży"),
                        new Answer<ICountry>(0.3, 0.6, "Średni"),
                        new Answer<ICountry>(0, 0.3, "Mały")
                    },
                    FuzzyFunctions.AreaFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "W jakim stopniu kraj jest rozwinięty?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.6,1, "Bardzo"),
                        new Answer<ICountry>(0.35, 0.6, "Średno"),
                        new Answer<ICountry>(0, 0.35, "Słabo"),
                    },
                    FuzzyFunctions.DevelopementFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak dużo opadów występuje?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.1, 0.3, "Dużo"),
                        new Answer<ICountry>(0.6, 0.8, "Umarkowanie"),
                        new Answer<ICountry>(0.3, 0.4, "Mało"),
                    },
                    FuzzyFunctions.RainsFuzzy.Invoke
                ));

            //questions.Add(
            //    new Question<ICountry>
            //    (
            //        "Jaki jest poziom bezpieczeństwa kraju?",
            //        new List<IAnswer<ICountry>>()
            //        {
            //            new Answer<ICountry>(0.6, int.MaxValue, "Wysoki"),
            //            new Answer<ICountry>(0.4, 0.6, "Średni"),
            //            new Answer<ICountry>(0, 0.4, "Niski"),
            //        },
            //        FuzzyFunctions.SafetyFuzzy.Invoke
            //    ));

            //questions.Add(
            //   new Question<ICountry>
            //   (
            //       "Jaki jest poziom medycyny w kraju?",
            //       new List<IAnswer<ICountry>>()
            //       {
            //            new Answer<ICountry>(0.7, int.MaxValue, "Wysoki"),
            //            new Answer<ICountry>(0.5, 0.7, "Średni"),
            //            new Answer<ICountry>(0, 0.5, "Niski"),
            //       },
            //       FuzzyFunctions.MedicineFuzzy.Invoke
            //   ));

            //questions.Add(
            //   new Question<ICountry>
            //   (
            //       "Jak duży jest koszt pobytu?",
            //       new List<IAnswer<ICountry>>()
            //       {
            //            new Answer<ICountry>(0.6, int.MaxValue, "Wysoki"),
            //            new Answer<ICountry>(0.3, 0.6, "Średni"),
            //            new Answer<ICountry>(0, 0.3, "Niski"),
            //       },
            //       FuzzyFunctions.CostFuzzy.Invoke
            //   ));

            questions.Add(
               new Question<ICountry>
               (
                   "Czy państwo jest atrakcyjne turystycznie?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.5, 1, "Bardzo"),
                        new Answer<ICountry>(0.2, 0.5, "Raczej tak"),
                        new Answer<ICountry>(0.1, 0.3, "Raczej nie"),
                        new Answer<ICountry>(0, 0.25, "Wcale"),
                   },
                   FuzzyFunctions.MonumentsFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak dużo ludności mieszka w kraju?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.7, 1, "Dużo"),
                        new Answer<ICountry>(0.4, 0.7, "Średnio"),
                        new Answer<ICountry>(0, 0.4, "Mało"),
                   },
                   FuzzyFunctions.PopulationFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jaka jest gęstość zaludnienia?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.5, 1, "Duża"),
                        new Answer<ICountry>(0.25, 0.5, "Średnia"),
                        new Answer<ICountry>(0, 0.3, "Mała"),
                   },
                   FuzzyFunctions.DensityFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak duży chcesz mieć jetlag?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.7, 1, "Duży"),
                        new Answer<ICountry>(0.4, 0.7, "Średni"),
                        new Answer<ICountry>(0, 0.4, "Mały"),
                   },
                   FuzzyFunctions.JetFuzzy.Invoke
               ));

            return questions;
        }
    }
}
