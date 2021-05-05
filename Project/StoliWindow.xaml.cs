using Project.Model;
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
                Stoli s = (Stoli)cbStoli.SelectedItem ;

                if (s.IsBusy == false)
                {
                    MessageBox.Show("Стол занят!");
                }
                else
                {
                    foreach (var i in db.Stoli)
                    {
                        if (s.idStola == i.idStola)
                        {
                            i.IsBusy = false;
                        }
                    }
                    new RegZakWindow(s.idStola).ShowDialog();
                    this.Close();
                }
            }
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbStoli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
