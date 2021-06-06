using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
    /// Логика взаимодействия для RegZakPage.xaml
    /// </summary>
    public partial class RegZakPage : Page
    {
        user3Entities db = new user3Entities();
        string Login;
        public RegZakPage(string Login)
        {
            InitializeComponent();

            this.Login = Login;

            dgZak.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() == "").ToList();
            dgZakC.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() != "").ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //new StoliWindow().ShowDialog();
            string titl = "Выбор стола";
            new TablesWindow(titl,Login).ShowDialog();
            dgZak.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() == "").ToList();
            dgZakC.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() != "").ToList();
        }

        private void dgZak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Zakazi zakazi = dgZak.SelectedItem as Zakazi;
            //int idZak = Convert.ToInt32(zakazi.idZakaza);

            ////dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
            //int stol = Convert.ToInt32(zakazi.Stol);
            //double summ = Convert.ToInt32(zakazi.SummaZakaza);
            //double summS = Convert.ToDouble(zakazi.SummaZakazaS);
            //string open = Convert.ToString(zakazi.DateOpenZakaz);
            //string close = Convert.ToString(zakazi.DateCloseZakaz);
            new RegOrders(zakazi.Stol, zakazi.idZakaza, Login).ShowDialog();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            dgZak.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() == "").ToList();
            dgZakC.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() != "").ToList();
        }

        private void btnCloseZak_Click(object sender, RoutedEventArgs e)
        {
            if (dgZak.SelectedItem != null)
            {
                Zakazi zak = dgZak.SelectedItem as Zakazi;
                int idZak = Convert.ToInt32(zak.idZakaza);
                int Stol = Convert.ToInt32(zak.Stol);
                if (zak.Closed == false)
                {
                    if (MessageBox.Show("Вы уверены что хотите закрыть заказ?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        foreach (var item in db.Zakazi)
                        {
                            if (idZak == item.idZakaza)
                            {
                                item.DateCloseZakaz = DateTime.Now;
                                item.Closed = true;
                                if (item.TypeZakaz == 2)
                                {
                                    BookingStol t =(BookingStol)db.BookingStol.Where(tt => tt.idStol == item.Stoli.idStola && tt.Status==false).FirstOrDefault();
                                    t.Status = true;
                                }
                            }
                        }
                    }

                    foreach (var i in db.Stoli)
                    {
                        if (Stol == i.idStola)
                        {
                            i.IsBusy = true;
                        }
                    }
                    db.SaveChanges();
                    dgZak.ItemsSource = db.Zakazi.ToArray().ToList();

                    foreach (var item in db.Employee)
                    {
                        if (item.idEmployee == zak.Employee)
                        {
                            item.NumberOfSales = 0;
                            item.NumberOfSales++;
                        }
                    }
                    db.SaveChanges();
                    
                }
                else
                {
                    MessageBox.Show("Заказ уже закрыт!");
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ!");
            }
        }


        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgZak.SelectedItem != null)
            {
                Zakazi zak = dgZak.SelectedItem as Zakazi;
                int idZak = Convert.ToInt32(zak.idZakaza);
                int Stol = Convert.ToInt32(zak.Stol);
                if (MessageBox.Show("Вы точно хотите удалить этот заказ?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    foreach (var item in db.ZakazBluda)
                    {
                        if (item.idZakaza == idZak)
                        {
                            db.ZakazBluda.Remove(item);
                        }
                    }
                    db.Zakazi.Remove(zak);
                    foreach (var item in db.Stoli)
                    {
                        if (Stol == item.idStola)
                        {
                            item.IsBusy = true;
                        }
                    }
                    db.SaveChanges();
                    dgZak.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() == "").ToList(); 
                    dgZakC.ItemsSource = db.Zakazi.Where(t => t.DateCloseZakaz.ToString() != "").ToList();
                }
            }
        }

        private void dgZakC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Zakazi zakazi = dgZakC.SelectedItem as Zakazi;
            int idZak = Convert.ToInt32(zakazi.idZakaza);
            int stol = Convert.ToInt32(zakazi.Stol);
            double summ = Convert.ToInt32(zakazi.SummaZakaza);
            double summS = Convert.ToDouble(zakazi.SummaZakazaS);
            string open = Convert.ToString(zakazi.DateOpenZakaz);
            string close = Convert.ToString(zakazi.DateCloseZakaz);
            new ZakazInfoWindow(idZak, stol, summ, summS, open, close).ShowDialog();
        }
    }
}