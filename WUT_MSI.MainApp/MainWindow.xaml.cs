﻿using System.Windows;
using WUT_MSI.MainApp.Managers;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
	{
        private Evaluator<Country> evaluator;

		public MainWindow()
		{
			InitializeComponent();

            evaluator = new Evaluator<Country>(new CountryQuestionGetter(QuestionGenerator.GetQuestions()));
        }
	}
}
