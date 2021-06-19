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
        user3Entities db = new user3Entities();
        public CreateEmp()
        {
            InitializeComponent();
        }
        private void txtbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLogin.Text = "";
            txtLogin.Text = Translit(txtbSurname.Text.ToLower()) + "_" + Translit(txtbName.Text.ToLower());
        }

        private static string Translit(string s)
        {
            StringBuilder ret = new StringBuilder();
            string[] rus = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            string[] eng = { "a", "b", "v", "g", "d", "e", "e", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts","ch", "sh", "shch", null, "y", null, "e", "yu", "ya" };

            for (int j = 0; j < s.Length; j++)
                for (int i = 0; i < rus.Length; i++)
                    if (s.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
            return ret.ToString();
        }

        private void txtbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLogin.Text = "";
            txtLogin.Text = Translit(txtbSurname.Text.ToLower()) + "_" + Translit(txtbName.Text.ToLower());
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
                emp.NumberOfSales = 0;
                Roles rol = cbRole.SelectedItem as Roles;
                emp.Role = rol.idRole;
                db.Employee.Add(emp);
                db.SaveChanges();
                Login log = new Login();
                log.UserName = txtLogin.Text;
                log.Password = txtPassword.Text;
                log.Role = rol.idRole;
                log.CountWrong = 0;
                db.Login.Add(log);
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
