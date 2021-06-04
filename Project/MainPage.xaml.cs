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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string Login;
        public MainPage(string Login)
        {
            InitializeComponent();
            this.Login = Login;
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmpPage());
        }

        private void btnBludo_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DishPage());
        }

        private void btnZak_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegZakPage(Login));
        }

        private void btnTable_Click(object sender, RoutedEventArgs e)
        {
            new TableWindow().ShowDialog();
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SkidCardPage());
        }

        private void btnReps_Click(object sender, RoutedEventArgs e)
        {
            new ReportsWindow().ShowDialog();
        }
    }
}
