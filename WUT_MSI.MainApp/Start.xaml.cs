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
using WUT_MSI.ModelsLib.classes;
using WUT_MSI.ModelsLib.classes.helpers;

namespace WUT_MSI.MainApp
{
	/// <summary>
	/// Interaction logic for Start.xaml
	/// </summary>
	public partial class Start: Page
	{

		public Start()
		{
			InitializeComponent();
        }

		private void Start_Click(object sender, RoutedEventArgs e)
		{
            var evaluator = new Evaluator<ICountry>(new CountryQuestionGetter(QuestionGenerator.GetQuestions()));
            SerializationManager m = new SerializationManager();
            evaluator.SetEvaluatingSet(m.Deserialize<List<Country>>("Countries.xml").Select(item=>(ICountry)item).ToList());
            NavigationService.Navigate(new QuestionPage(evaluator));
		}
	}
}
