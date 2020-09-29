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
    /// Логика взаимодействия для DopEmpWindow.xaml
    /// </summary>
    public partial class DopEmpWindow : Window
    {
        string id;
        string surn;
        string name;
        string patr;
        string telep;
        string bdate;
        string rest;
        public DopEmpWindow(string id, string surn, string name, string patr, string telep, string bdate, string rest)
        {
            InitializeComponent();
            this.id = id;
            this.surn = surn;
            this.name = name;
            this.patr = patr;
            this.telep = telep;
            this.bdate = bdate;
            this.rest = rest;

            txtBirthDate.Text = bdate;
            txtID.Text = id;
            txtSurname.Text = surn;
            txtPatronymic.Text = patr;
            txtRestoran.Text = rest;
            txtTelephone.Text = telep;
            txtName.Text = name;
        }
    }
}
