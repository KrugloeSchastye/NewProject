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
    /// Логика взаимодействия для AddBludoWindow.xaml
    /// </summary>
    public partial class AddBludoWindow : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        int idZak;
         public AddBludoWindow(int idZak)
        {
            InitializeComponent();
            this.idZak = idZak;
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            int countKolvo = int.Parse(lblCount.Text);
            countKolvo++;
            lblCount.Text = countKolvo.ToString();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            int countKolvo = int.Parse(lblCount.Text);
            countKolvo--;
            lblCount.Text = countKolvo.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ZakazBluda zb = new ZakazBluda();
            zb.Kolvo = int.Parse(lblCount.Text);
            zb.NameBludo = ((Menu)cbBluda.SelectedItem).idBluda;
            zb.Cena = ((Menu)cbBluda.SelectedItem).Price;
            zb.Summa = ((Menu)cbBluda.SelectedItem).Price * zb.Kolvo;
            zb.idZakaza = idZak;
            db.ZakazBluda.Add(zb);
            db.SaveChanges();
            Close();
        }
    }
}
