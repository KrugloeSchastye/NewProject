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

            //var all = db.Employee.ToList().OrderBy(p => p.idEmployee).ToList();
            //var application = new Excel.Application();
            //application.SheetsInNewWorkbook = 2;
            //Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            //int start = 1;
            //Excel.Worksheet worksheet = application.Worksheets.Item[1];
            //worksheet.Name = "Отчет по сотрудникам";
            //worksheet.Cells[1][start] = "Код";
            //worksheet.Cells[2][start] = "Фамилия";
            //worksheet.Cells[3][start] = "Количество заказов";
            //start++;
            //for (int i = 0; i < all.Count(); i++)
            //{
            //    worksheet.Cells[1][start] = all[i].idEmployee;
            //    worksheet.Cells[2][start] = all[i].Surname;
            //    worksheet.Cells[3][start] = all[i].NumberOfSales;
            //    start++;
            //}
            ///*var al = db.Sertifikats.ToList().OrderBy(p => p.ID_Sertifikat).ToList();
            //start = 1;
            //Excel.Worksheet worksheet1 = application.Worksheets.Item[2];
            //worksheet1.Name = "Отчет по сертификатам";
            //worksheet1.Cells[1][start] = "Код";
            //worksheet1.Cells[2][start] = "Дата";
            //worksheet1.Cells[3][start] = "Сумма";
            //worksheet1.Cells[4][start] = "Использован?";
            //start++;
            //for (int i = 0; i < al.Count(); i++)
            //{
            //    worksheet1.Cells[1][start] = al[i].ID_Sertifikat;
            //    worksheet1.Cells[2][start] = al[i].Date;
            //    worksheet1.Cells[3][start] = al[i].Summ;
            //    worksheet1.Cells[4][start] = al[i].Ispolzovan;
            //    start++;
            //}*/
            //application.Visible = true;
        }
    }
}
