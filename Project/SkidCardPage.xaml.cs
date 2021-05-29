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
    /// Логика взаимодействия для SkidCardPage.xaml
    /// </summary>
    public partial class SkidCardPage : Page
    {
        user3Entities db = new user3Entities();
        public SkidCardPage()
        {
            InitializeComponent();
            dgSaleCard.ItemsSource = db.SkidCards.ToArray().ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new CreateSaleCard().ShowDialog();
            dgSaleCard.ItemsSource = db.SkidCards.ToArray().ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dgSaleCard.SelectedItem != null)
            {
                SkidCards sc = dgSaleCard.SelectedItem as SkidCards;
                db.SkidCards.Remove(sc);
                db.SaveChanges();
                dgSaleCard.ItemsSource = db.SkidCards.ToArray().ToList();
            }
            else
                MessageBox.Show("Выберите поле для удаления!");
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
                dgSaleCard.ItemsSource = db.SkidCards.ToList();
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
                dgSaleCard.ItemsSource = db.SkidCards.ToList();
            }
        }

        private void txtbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgSaleCard.ItemsSource = db.SkidCards.Where(t => t.NumberCard == txtbSearch.Text).ToArray().ToList();
        }
    }
}
