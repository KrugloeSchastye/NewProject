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
    /// Логика взаимодействия для RegZakWindow.xaml
    /// </summary>
    public partial class RegZakWindow : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        int Stol;
        int idZak;
        double Summa;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Zakazi zak = new Zakazi();
            zak.Stol = Stol;
            zak.DateOpenZakaz = DateTime.Now;
            zak.SummaZakaza = 0;
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
                Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        }
    }
}