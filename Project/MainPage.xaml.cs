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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        string Login;
        user3Entities db = new user3Entities();
        public MainPage(string Login)
        {
            InitializeComponent();
            this.Login = Login;
            Login currLogin = (Login)db.Login.Where(i => i.UserName == Login).FirstOrDefault();
            if (currLogin.Role == 1)
            { }
            if (currLogin.Role == 2)
            {
                btnBludo.Visibility = Visibility.Collapsed;
                btnBookingStol.Visibility = Visibility.Collapsed;
            }
            if (currLogin.Role == 3)
            {
                btnEmp.Visibility = Visibility.Collapsed;
                btnBludo.Visibility = Visibility.Collapsed;
                btnZak.Visibility = Visibility.Collapsed;
                btnCard.Visibility = Visibility.Collapsed;
            }
            if (currLogin.Role == 4)
            {
                btnEmp.Visibility = Visibility.Collapsed;
            }
            if(currLogin.Role == 5)
            {
                btnBludo.Visibility = Visibility.Collapsed;
                btnBookingStol.Visibility = Visibility.Collapsed;
                btnCard.Visibility = Visibility.Collapsed;
                btnEmp.Visibility = Visibility.Collapsed;
                btnReps.Visibility = Visibility.Collapsed;
                btnZak.Visibility = Visibility.Collapsed;
                tbHeader.Visibility = Visibility.Collapsed;

                tbAccess.Text = "Информационная система для клиентов не доступна!";
                tbAccess.Visibility = Visibility.Visible;
            }
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

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new SkidCardPage());
        }

        private void btnReps_Click(object sender, RoutedEventArgs e)
        {
            new ReportsWindow().ShowDialog();
        }

        private void btnBookingStol_Click(object sender, RoutedEventArgs e)
        {
            new BookingWind(Login).ShowDialog();
        }
    }
}
