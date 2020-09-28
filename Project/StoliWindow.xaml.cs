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
                int Stol = cbStoli.SelectedIndex + 1;
                new RegZakWindow(Stol).ShowDialog();
                this.Close();
            }
        }
    }
}
