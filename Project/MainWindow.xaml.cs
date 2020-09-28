using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Dates;
        string Login;
        public MainWindow(string Login, string Dates)
        {
            InitializeComponent();
            this.Login = Login;
            this.Dates = Dates;
            MainFrame.Navigate(new MainPage());
            Manager.MainFrame = MainFrame;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"Круглое счастье";
            txtTitle.Text = $"Логин: {Login}, Время входа: {Dates}";
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;

        }
    }
}
