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
    /// Логика взаимодействия для CreateSaleCard.xaml
    /// </summary>
    public partial class CreateSaleCard : Window
    {
        user3Entities db = new user3Entities();
        int count = 1;
        public CreateSaleCard()
        {
            InitializeComponent();

            foreach (var item in db.SkidCards)
            {
                count++;
            }
            txtbNCard.Text = $"{count}";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtbName.Text == "" || txtbSurname.Text == "" || txtbPatr.Text == "" || txtbNominal.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                SkidCards sc = new SkidCards();

                Employee emp = cbxEmp.SelectedItem as Employee;
                int idEmp = emp.idEmployee;

                sc.Surname = txtbName.Text;
                sc.Name = txtbName.Text;
                sc.Patronymic = txtbPatr.Text;
                sc.idEmployee = idEmp;
                sc.Nominal = txtbNominal.Text;
                sc.NumberCard = txtbNCard.Text;

                db.SkidCards.Add(sc);
                db.SaveChanges();

                Close();
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
