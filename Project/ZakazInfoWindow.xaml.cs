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
    /// Логика взаимодействия для ZakazInfoWindow.xaml
    /// </summary>
    public partial class ZakazInfoWindow : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        int idZak;
        int stol;
        int summ;
        string open;
        string close;
        public ZakazInfoWindow(int idZak, int stol, int summ, string open, string close)
        {
            InitializeComponent();
            this.idZak = idZak;
            this.stol = stol;
            this.summ = summ;
            this.open = open;
            this.close = close;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Zakazi zakazi = new Zakazi();

            txtStol.Text = stol.ToString(); 
            txtSumma.Text = summ.ToString();
            txtDateOpen.Text = open.ToString();
            txtDateClose.Text = close.ToString();
            dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
        }
    }
}
