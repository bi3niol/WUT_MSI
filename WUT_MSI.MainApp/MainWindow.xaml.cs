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
using WUT_MSI.MainApp.Managers;
using WUT_MSI.Models;
using WUT_MSI.Models.classes;
using WUT_MSI.ModelsLib.classes.helpers;
using WUT_MSI.ModelsLib.interfaces;

namespace WUT_MSI.MainApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
        private IQuestionGetter<Country> questionGetter;

		public MainWindow()
		{
			InitializeComponent();

            questionGetter = new CountryQuestionGetter(QuestionGenerator.GetQuestions());
        }
	}
}
