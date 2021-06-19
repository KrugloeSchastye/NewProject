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
using Excel = Microsoft.Office.Interop.Excel;


namespace Project
{
    /// <summary>
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        user3Entities db = new user3Entities();
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            new ReportMessage(1).ShowDialog();
        }

        private void btnDish_Click(object sender, RoutedEventArgs e)
        {
            new ReportMessage(2).ShowDialog();
        }

        private void btnSCards_Click(object sender, RoutedEventArgs e)
        {
            new ReportMessage(3).ShowDialog();
        }
    }
}
