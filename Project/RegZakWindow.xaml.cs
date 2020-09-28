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
        public RegZakWindow(int Stol)
        {
            InitializeComponent();
            this.Stol = Stol;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddBludoWindow(idZak).ShowDialog();
            dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
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
            db.SaveChanges();
            Close();
        }
    }
}
