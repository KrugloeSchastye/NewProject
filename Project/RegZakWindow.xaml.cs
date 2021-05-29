using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Логика взаимодействия для RegZakWindow.xaml
    /// </summary>
    public partial class RegZakWindow : Window
    {
        user3Entities db = new user3Entities();
        int Stol;
        int idZak;
        double Summa;
        double SummaS;

        public RegZakWindow(int Stol)
        {
            InitializeComponent();
            this.Stol = Stol;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgZakBludo.SelectedItem != null)
            {
                ZakazBluda delBludo = (ZakazBluda)dgZakBludo.SelectedItem;
                if (MessageBox.Show("Вы точно хотите удалить блюдо из заказа?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.ZakazBluda.Remove(delBludo);
                    db.SaveChanges();

                    Summa = 0;

                    foreach (var item in db.ZakazBluda)
                    {
                        if (item.idZakaza == idZak)
                        {
                            Summa += item.Summa;
                            txtItog.Text = $"Итог: {Summa}";
                        }
                    }

                    foreach (var item in db.Zakazi)
                    {
                        if (item.idZakaza == idZak)
                        {
                            item.SummaZakaza = Summa;
                            txtItog.Text = $"Итог: {Summa}";
                        }
                    }

                    db.SaveChanges();
                    txtItog.Text = $"Итог: {Summa}";
                    dgZakBludo.ItemsSource = db.ZakazBluda.Where(i => i.idZakaza == idZak).ToList();
                }
            }
            else
                MessageBox.Show("Выберите какое именно блюдо хотите удалить!");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddBludoWindow(idZak).ShowDialog();

            Summa = 0;
            
            dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();

            txtSCardCheck.Text = "";
            txtSertCheck.Text = "";

            txtItogS.Text = "";

            cbSearchSC.IsChecked = false;

            foreach (var item in db.ZakazBluda)
            {
                if (item.idZakaza == idZak)
                {
                    Summa += item.Summa;
                }
            }
            txtItog.Text = $"Итог: {Summa}";
            foreach (var item in db.Zakazi)
            {
                if (item.idZakaza == idZak)
                {
                    item.SummaZakaza = Summa;
                }
            }
            btnDel.IsEnabled = true;
            btnSave.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Zakazi zak = new Zakazi();
            zak.Stol = Stol;
            zak.DateOpenZakaz = DateTime.Now;
            zak.SummaZakaza = 0;
            zak.Employee = 1;
            zak.Closed = false;
            db.Zakazi.Add(zak);
            db.SaveChanges(); 
            idZak = zak.idZakaza;
            txtbStol.Text = Convert.ToString(Stol);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Summa <= 0)
            {
                MessageBox.Show("Вы ничего не выбрали!");
            }
            else
            {
                foreach (var i in db.Stoli)
                {
                    if (Stol == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                db.SaveChanges();
            }

            if (cbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Укажите сотрудника!", "Внимание!");
            }
            else
            {
                Employee emp = cbEmployee.SelectedItem as Employee;
                Zakazi zak = new Zakazi();
                zak.Employee = emp.idEmployee;
               // db.SaveChanges();
                foreach (var item in db.Zakazi)
                {
                    if (item.idZakaza == idZak)
                    {
                        item.Employee = emp.idEmployee;
                    }
                }
                db.SaveChanges();
            }
            if (txtbSkidCard.Text != "")
            {
                foreach (var item2 in db.Zakazi)
                {
                    if (item2.idZakaza == idZak)
                    {
                        item2.SummaZakazaS = SummaS;
                    }
                }
                db.SaveChanges();
                Close();
            }
            else
                Close();
        }

        double SkidCard = 0;
        private void txtbSkidCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nCard = txtbSkidCard.Text;
            user3Entities db1 = new user3Entities();

            SkidCards ItemSkidCart=db.SkidCards.Where(i => i.NumberCard == nCard).FirstOrDefault();
            if (ItemSkidCart != null)
            {
                txtSCardCheck.Text = "Проверен";
                SkidCard = double.Parse(ItemSkidCart.Nominal);
                txtItogS.Text = Convert.ToString(Summa - (Summa * SkidCard));
                SummaS = Summa - (Summa * SkidCard);
            }
            else
            {
                txtSCardCheck.Text = "Ошибка";
            }



            //foreach (var item in db.SkidCards)
            //{
            //    if (item.NumberCard == nCard)
            //    {
            //        txtSCardCheck.Text = "Проверен";
            //        SkidCard = double.Parse(item.Nominal);
            //        txtItogS.Text = Convert.ToString(Summa - (Summa * SkidCard));
            //        SummaS = Summa - (Summa * SkidCard);
            //    }
            //    else
            //    {
            //        txtSCardCheck.Text = "Ошибка";
            //        SkidCard = 0;
            //        SummaS = 0;
            //        db.SaveChanges();
            //        txtItogS.Text = "";
            //    }
            //}
        }

        private void cbSearchSC_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSearchSC.IsChecked == true)
            {
                txtbSkidCard.IsEnabled = true;
                gbItogS.Visibility = Visibility.Visible;
            }
            else
            {
                txtbSkidCard.IsEnabled = false;
                txtbSkidCard.Text = "";
                txtItogS.Text = "";
                txtSCardCheck.Text = "";
                gbItogS.Visibility = Visibility.Hidden;
            }
        }

        private void cbSearchSC_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbSearchSC.IsChecked == true)
            {
                txtbSkidCard.IsEnabled = true;
                gbItogS.Visibility = Visibility.Visible;
            }
            else
            {
                txtbSkidCard.IsEnabled = false;
                txtbSkidCard.Text = "";
                txtItogS.Text = "";
                txtSCardCheck.Text = "";
                gbItogS.Visibility = Visibility.Hidden;
            }
        }

        private void cbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee emp = cbEmployee.SelectedItem as Employee;
            Zakazi zak = new Zakazi();
            zak.Employee = emp.idEmployee;
            db.SaveChanges();
            foreach (var item in db.Zakazi)
            {
                if (item.idZakaza == idZak)
                {
                    item.Employee = emp.idEmployee;
                }
            }
            db.SaveChanges();

            btnAdd.IsEnabled = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заказ отменен!");
            foreach (var item in db.ZakazBluda)
            {
                if (idZak == item.idZakaza)
                {
                    db.ZakazBluda.Remove(item);
                }
            }
            foreach (var item in db.Zakazi)
            {
                if (idZak == item.idZakaza)
                {
                    db.Zakazi.Remove(item);
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
            Close();
        }
    }
}