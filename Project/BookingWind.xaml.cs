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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class BookingWind : Window
    {
        user3Entities db = new user3Entities();

        string Login;
        public BookingWind(string Login)
        {
            InitializeComponent();
            List<BookingStol> list = new List<BookingStol>();
            foreach (var item in db.BookingStol)
            {
                DateTime Date = DateTime.Parse(item.DateBooking);
                if (Date >= DateTime.Parse(DateTime.Now.ToString("d")))
                {
                    list.Add(item);
                }

            }
            dgBooking.ItemsSource = list;
            this.Login = Login;
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            new BookingStolWind(Login).ShowDialog();
        }

        private void btnRemoveBookingStol_Click(object sender, RoutedEventArgs e)
        {
            BookingStol itemStol = (BookingStol)dgBooking.SelectedItem;
            db.BookingStol.Remove(itemStol);
            db.SaveChanges();

            List<BookingStol> list = new List<BookingStol>();
            foreach (var item in db.BookingStol)
            {
                DateTime Date = DateTime.Parse(item.DateBooking);
                if (Date >=DateTime.Parse(DateTime.Now.ToString("d")))
                {
                    list.Add(item);
                }

            }
            dgBooking.ItemsSource = list;
        }
    }
}
