using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для CreateDish.xaml
    /// </summary>
    public partial class CreateDish : Window
    {
        user3Entities db = new user3Entities();
        public CreateDish()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Menu menu = new Menu();
                menu.NameBludo = txtbName.Text;
                menu.Wheight = txtbWeight.Text;
                menu.Struct = txtbCompos.Text;
                menu.RazdelMenu = cbRazdel.SelectedIndex;
                menu.Price = Convert.ToInt32(txtbPrice.Text);
                if (img != null)
                {
                    menu.Image = img;
                }
                else
                { 
                
                }
                db.Menu.Add(menu);
                db.SaveChanges();
                Close();
            }
            catch
            { }
        }
        byte[] img;
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            img = File.ReadAllBytes(ofd.FileName);
        }
    }
}
