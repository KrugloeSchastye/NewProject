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
    /// Логика взаимодействия для TablesWindow.xaml
    /// </summary>
    public partial class TablesWindow : Window
    {
        public TablesWindow()
        {
            InitializeComponent();
        }
        user3Entities db = new user3Entities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tables = db.Stoli.ToList();
            foreach (var item in tables)
            {
                lvTable.Items.Add(item.NameStola);
            }
        }
    }
}
