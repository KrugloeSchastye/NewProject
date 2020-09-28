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
    /// Логика взаимодействия для EmpWindow.xaml
    /// </summary>
    public partial class EmpPage : Page
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public EmpPage()
        {
            InitializeComponent();
            dgEmployee.ItemsSource = db.Employee.ToList().ToArray();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new CreateEmp().ShowDialog();
            var q =
                from i in db.Employee
                select i;
            dgEmployee.ItemsSource = q.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployee.SelectedItem != null)
            {
                Employee emp = (Employee)dgEmployee.SelectedItem;

                if (MessageBox.Show("Вы точно хотите удалить?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    db.Employee.Remove(emp);
                    db.SaveChanges();
                }

                var query = from item in db.Employee
                            select item;
                dgEmployee.ItemsSource = query.ToList();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.IsReadOnly = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgEmployee.IsReadOnly = true;
            db.SaveChanges();
        }

        private void cbxVSearch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxVSearch.IsChecked == true)
            {
                txtbSearch.IsEnabled = true;
            }
            else 
            {
                txtbSearch.IsEnabled = false;
                txtbSearch.Text = "";
                dgEmployee.ItemsSource = db.Employee.ToList();
            }
        }

        private void cbxVSearch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbxVSearch.IsChecked == true)
            {
                txtbSearch.IsEnabled = true;
            }
            else
            {
                txtbSearch.IsEnabled = false;
                txtbSearch.Text = "";
                dgEmployee.ItemsSource = db.Employee.ToList();
            }
        }

        private void txtbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgEmployee.ItemsSource = db.Employee.Where(t => t.Surname == txtbSearch.Text).ToArray().ToList();
        }
    }
}
