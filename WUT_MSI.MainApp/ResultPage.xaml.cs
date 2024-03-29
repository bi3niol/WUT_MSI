﻿using System;
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

namespace WUT_MSI.MainApp
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
    

        public ResultPage(List<ICountry> country)
        {
            InitializeComponent();

            var list = country.OrderByDescending(item => item.Result).ToList();
            list = list.Take(Math.Min(5,list.Count)).ToList();
            this.DataContext = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Start());
        }
    }
}
