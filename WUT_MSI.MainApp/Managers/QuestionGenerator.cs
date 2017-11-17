﻿using System;
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
                    "Jak klimat dominuje?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.8, 1, "Tropikalny"),
                        new Answer<ICountry>(0.6, 0.8, "Sybtropikalny"),
                        new Answer<ICountry>(0.3, 0.6, "Umiarkowany"),
                        new Answer<ICountry>(0, 0.3, "Chłodny")
                    },
                    FuzzyFunctions.ClimeteFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jak duży jest kraj?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.8, 1, "Bardzo duży"),
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
                        new Answer<ICountry>(0.6, 1, "Bardzo"),
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
                        new Answer<ICountry>(0.6, 1, "Dużo"),
                        new Answer<ICountry>(0.35, 0.6, "Umarkowanie"),
                        new Answer<ICountry>(0, 0.35, "Mało"),
                    },
                    FuzzyFunctions.RainsFuzzy.Invoke
                ));

            questions.Add(
                new Question<ICountry>
                (
                    "Jaki jest poziom bezpieczeństwa kraju?",
                    new List<IAnswer<ICountry>>()
                    {
                        new Answer<ICountry>(0.6, 1, "Wysoki"),
                        new Answer<ICountry>(0.4, 0.6, "Średni"),
                        new Answer<ICountry>(0, 0.4, "Niski"),
                    },
                    FuzzyFunctions.SafetyFuzzy.Invoke
                ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jaki jest poziom medycyny w kraju?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.7, 1, "Wysoki"),
                        new Answer<ICountry>(0.5, 0.7, "Średni"),
                        new Answer<ICountry>(0, 0.5, "Niski"),
                   },
                   FuzzyFunctions.MedicineFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak duży jest koszt pobytu?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.6, 1, "Wysoki"),
                        new Answer<ICountry>(0.3, 0.6, "Średni"),
                        new Answer<ICountry>(0, 0.3, "Niski"),
                   },
                   FuzzyFunctions.MedicineFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Czy państwo jest atrakcyjne turystycznie?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.7, 1, "Bardzo"),
                        new Answer<ICountry>(0.45, 0.6, "Raczej tak"),
                        new Answer<ICountry>(0.25, 0.45, "Raczej nie"),
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
                        new Answer<ICountry>(0.35, 0.7, "Raczej nie"),
                        new Answer<ICountry>(0, 0.35, "Mało"),
                   },
                   FuzzyFunctions.PopulationFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jaka jest gęstość zaludnienia?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.7, 1, "Duża"),
                        new Answer<ICountry>(0.45, 0.7, "Średnia"),
                        new Answer<ICountry>(0, 0.45, "Mała"),
                   },
                   FuzzyFunctions.DensityFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Jak duży chcesz mieć jetlag?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(0.65, 1, "Duży"),
                        new Answer<ICountry>(0.35, 0.65, "Średni"),
                        new Answer<ICountry>(0, 0.35, "Mały"),
                   },
                   FuzzyFunctions.JetFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Czy jest wyspą?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(1, 1, "Tak"),
                        new Answer<ICountry>(0, 0, "Nie"),
                   },
                   FuzzyFunctions.IslandFuzzy.Invoke
               ));

            questions.Add(
               new Question<ICountry>
               (
                   "Czy występują wulkany?",
                   new List<IAnswer<ICountry>>()
                   {
                        new Answer<ICountry>(1, 1, "Tak"),
                        new Answer<ICountry>(0, 0, "Nie"),
                   },
                   FuzzyFunctions.VuclansFuzzy.Invoke
               ));

            return questions;
        }
    }
}
