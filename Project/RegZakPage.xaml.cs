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
    /// Логика взаимодействия для RegZakPage.xaml
    /// </summary>
    public partial class RegZakPage : Page
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public RegZakPage()
        {
            InitializeComponent();
            dgZak.ItemsSource = db.Zakazi.ToArray().ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new StoliWindow().ShowDialog();
            //new RegZakWindow().ShowDialog();
        }

        private void dgZak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dgZakBludo.Visibility = Visibility.Visible;
            Zakazi zakazi = dgZak.SelectedItem as Zakazi;
            int idZak = Convert.ToInt32(zakazi.idZakaza);

            dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
        }
    }
}