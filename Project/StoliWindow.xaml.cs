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
    /// Логика взаимодействия для StoliWindow.xaml
    /// </summary>
    public partial class StoliWindow : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public StoliWindow()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (cbStoli.SelectedItem == null)
                MessageBox.Show("Вы не выбрали стол!");
            else
            {
                Stoli s = cbStoli.SelectedItem as Stoli;
                int Stol = s.idStola;
                foreach (var item in db.Stoli)
                {
                    if (Stol == item.idStola)
                    {
                        if (item.IsBusy == false)
                        {
                            MessageBox.Show("Стол занят!");
                        }
                        else
                        {
                            new RegZakWindow(Stol).ShowDialog();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
