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
                        new Answer<ICountry>(-0.4, 0.4, "Blisko"),
                        new Answer<ICountry>(0.0, 0.66, "Średnio"),
                        new Answer<ICountry>(0.33, 0.99, "Daleko"),
                        new Answer<ICountry>(0.6, 1.4, "Bardzo daleko")
                    },
                    FuzzyFunctions.DistanceFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak panuje temperatura?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.8, 1, "Wysoka"),
                        new Answer<ICountry>(0.6, 0.8, "Średnia"),
                        new Answer<ICountry>(0.3, 0.5, "Umiarkowana"),
                        new Answer<ICountry>(0.1, 0.3, "Niska")
                    },
                    FuzzyFunctions.ClimeteFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak duży jest kraj?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.5556,1.4444, "Bardzo duży"),
                        new Answer<ICountry>(0.4, 0.7, "Duży"),
                        new Answer<ICountry>(0.35, 0.65, "Średni"),
                        new Answer<ICountry>(0.4385, 0.5615, "Mały")
                    },
                    FuzzyFunctions.AreaFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "W jakim stopniu kraj jest rozwinięty?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.2,1.8, "Bardzo"),
                        new Answer<ICountry>(-0.2, 0.6, "Średno"),
                        new Answer<ICountry>(-0.05, 0.05, "Słabo"),
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

            questions.Add(
                new Question<ICountry>
                (
                    "Jaki jest poziom bezpieczeństwa kraju?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.6, 1.4, "Wysoki"),
                        new Answer<ICountry>(0.1, 0.9, "Średni"),
                        new Answer<ICountry>(-0.4, 0.4, "Niski"),
                    },
                    FuzzyFunctions.SafetyFuzzy.Invoke
                ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jaki jest poziom medycyny w kraju?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.6, 1.4, "Wysoki"),
                        new Answer<ICountry>(0.1, 0.9, "Średni"),
                        new Answer<ICountry>(-0.4, 0.4, "Niski"),
                   },
                   FuzzyFunctions.MedicineFuzzy.Invoke
               ));

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
                       new Answer<ICountry>(0.5,1.5, "Bardzo"),
                        new Answer<ICountry>(0.1154, 0.7556, "Raczej tak"),
                        new Answer<ICountry>(-0.0015, 0.2154, "Raczej nie"),
                        new Answer<ICountry>(-0.2015, 0.2015, "Wcale")
                   },
                   FuzzyFunctions.MonumentsFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak dużo ludności mieszka w kraju?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.02, 1.98, "Dużo"),
                        new Answer<ICountry>(-0.02, 0.06, "Średnio"),
                        new Answer<ICountry>(-0.04, 0.04, "Mało"),
                   },
                   FuzzyFunctions.PopulationFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jaka jest gęstość zaludnienia?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.0, 2.0, "Bardzo Duża"),
                        new Answer<ICountry>(-0.394, 0.406, "Duża"),
                        new Answer<ICountry>(-0.296, 0.304, "Średnia"),
                        new Answer<ICountry>(-0.12, 0.12, "Mała"),
                   },
                   FuzzyFunctions.DensityFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak duży chcesz mieć jetlag?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.6, 1.4, "Duży"),
                        new Answer<ICountry>(0.1, 0.9, "Średni"),
                        new Answer<ICountry>(-0.4, 0.4, "Mały"),
                   },
                   FuzzyFunctions.JetFuzzy.Invoke
               ));

            return questions;
        }
    }
}
