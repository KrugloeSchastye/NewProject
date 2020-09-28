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
    /// Логика взаимодействия для DishPage.xaml
    /// </summary>
    public partial class DishPage : Page
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public DishPage()
        {
            InitializeComponent();
            dgDish.ItemsSource = db.Menu.ToArray().ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new CreateDish().ShowDialog();
            dgDish.ItemsSource = db.Menu.ToArray().ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgDish.SelectedItem != null)
            {
                Menu menu = (Menu)dgDish.SelectedItem;

                if (MessageBox.Show("Вы точно хотите удалить?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    db.Menu.Remove(menu);
                    db.SaveChanges();
                }
                var query = from item in db.Menu
                            select item;
                dgDish.ItemsSource = query.ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgDish.IsReadOnly = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgDish.IsReadOnly = true;
            db.SaveChanges();
        }

        private void cbxVSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxVSearch.IsChecked == true)
            {
                cbSearch.IsEnabled = true;
            }
            else
            {
                cbSearch.IsEnabled = false;
                dgDish.ItemsSource = db.Menu.ToList();
            }
        }

        private void cbxVSearch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxVSearch.IsChecked == true)
            {
                cbSearch.IsEnabled = true;
            }
            else
            {
                cbSearch.IsEnabled = false;
                dgDish.ItemsSource = db.Menu.ToList();
            }
        }

        private void cbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgDish.ItemsSource = db.Menu.Where(t => t.RazdelMenu == cbSearch.SelectedIndex).ToArray().ToList();
        }
    }
}