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
    /// Логика взаимодействия для RegOrders.xaml
    /// </summary>
    public partial class RegOrders : Window
    {
        int idTable;
        int stat;
        string Login;
        int idZak;
        double Summa;
        double SummaS;
        public RegOrders(int idTable, int stat, string Login)
        {
            InitializeComponent();

            this.idTable = idTable;
            this.stat = stat;
            this.Login = Login;
        }
        user3Entities db = new user3Entities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (stat == 0)
            {
                Zakazi zak = new Zakazi();
                zak.Stol = idTable;
                zak.DateOpenZakaz = DateTime.Now;
                zak.SummaZakaza = 0;
                var emp = db.Employee.Where(i => i.Login.UserName == Login).FirstOrDefault();
                zak.Employee = emp.idEmployee;
                
                zak.Closed = false;
                db.Zakazi.Add(zak);
                db.SaveChanges();
                idZak = zak.idZakaza;

                txtbStol.Text = Convert.ToString(idTable);
                txtbEmployee.Text = emp.Surname.ToString();

                btnAdd.IsEnabled = true;
            }
            else
            {
                idZak = stat;
                var zakaz = db.Zakazi.Where(i => i.idZakaza == stat).FirstOrDefault();
                txtbEmployee.Text = zakaz.Employee1.Surname;
                if (zakaz.idSCard != null)
                {
                    txtbSkidCard.Text = zakaz.idSCard;
                    cbSearchSC.IsChecked = true;
                    txtItogS.Text = zakaz.SummaZakazaS.ToString();
                }
                txtItog.Text = zakaz.SummaZakaza.ToString();
                txtbStol.Text = zakaz.Stol.ToString();
                dgOrdBludo.ItemsSource = db.ZakazBluda.Where(i => i.idZakaza == idZak).ToList();
                btnAdd.IsEnabled = true;
                btnDel.IsEnabled = true;
                btnSave.IsEnabled = true;
                Summa = zakaz.SummaZakaza;
                //SummaS = (double)zakaz.SummaZakazaS;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddBludoWindow(idZak).ShowDialog();
            Summa = 0;
            dgOrdBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
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
            db.SaveChanges();
            if (txtbSkidCard.Text != null)
            {
                string nCard = txtbSkidCard.Text;
                user3Entities db1 = new user3Entities();

                SkidCards ItemSkidCart = db.SkidCards.Where(i => i.NumberCard == nCard).FirstOrDefault();
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
                    txtItogS.Text = txtItog.Text;
                }
            }
            btnDel.IsEnabled = true;
            btnSave.IsEnabled = true;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrdBludo.SelectedItem != null)
            {
                ZakazBluda delBludo = (ZakazBluda)dgOrdBludo.SelectedItem;
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
                    dgOrdBludo.ItemsSource = db.ZakazBluda.Where(i => i.idZakaza == idZak).ToList();
                }
            }
            else
                MessageBox.Show("Выберите какое именно блюдо хотите удалить!");
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
                    if (idTable == i.idStola)
                    {
                        i.IsBusy = false;
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
                        item2.idSCard = txtbSkidCard.Text;
                    }
                }
                db.SaveChanges();
                Close();
            }
            else
                Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (stat == 0)
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
                    if (idTable == i.idStola)
                    {
                        i.IsBusy = true;
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
            SkidCards ItemSkidCart = db.SkidCards.Where(i => i.NumberCard == nCard).FirstOrDefault();
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
                txtItogS.Text = txtItog.Text;
            }
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
    }
}
