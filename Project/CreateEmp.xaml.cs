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
    /// Логика взаимодействия для CreateEmp.xaml
    /// </summary>
    public partial class CreateEmp : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public CreateEmp()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.Name = Convert.ToString(txtbName.Text);
                emp.Surname = Convert.ToString(txtbSurname.Text);
                emp.Patronymic = Convert.ToString(txtbPatronymic.Text);
                emp.Telephone = Convert.ToString(txtbTelephone.Text);
                emp.Restoran = Convert.ToInt32(cbRestorans.SelectedIndex + 1);
                emp.BirthDate = DateTime.Parse(dpBirthDate.Text);
                db.Employee.Add(emp);
                db.SaveChanges();
                Close();
            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
