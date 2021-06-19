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
using Word = Microsoft.Office.Interop.Word;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для ReportMessage.xaml
    /// </summary>
    public partial class ReportMessage : Window
    {
        int type;
        public ReportMessage(int type)
        {
            InitializeComponent();
            this.type = type;
        }
        user3Entities db = new user3Entities();
        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            if (type == 1)
            {
                var all = db.Employee.ToList().OrderBy(p => p.idEmployee).ToList();
                var application = new Excel.Application();
                application.SheetsInNewWorkbook = 2;
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                int start = 1;
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                worksheet.Name = "Отчет по сотрудникам";
                worksheet.Cells[1][start] = "Код";
                worksheet.Cells[2][start] = "Фамилия";
                worksheet.Cells[3][start] = "Сумма заказов";
                start++;
                for (int i = 0; i < all.Count(); i++)
                {
                    double sum = 0;

                    worksheet.Cells[1][start] = all[i].idEmployee;
                    worksheet.Cells[2][start] = all[i].Surname;
                    foreach (var item in db.Zakazi)
                    {
                        if (all[i].idEmployee == item.Employee)
                        {
                            sum += item.SummaZakaza;
                        }
                    }
                    worksheet.Cells[3][start] = sum;
                    start++;
                }
                application.Visible = true;
            }
            else if (type == 2)
            {
                var all = db.Menu.ToList().OrderBy(p => p.idBluda).ToList();
                var application = new Excel.Application();
                application.SheetsInNewWorkbook = 2;
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                int start = 1;
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                worksheet.Name = "Отчет по блюдам";
                worksheet.Cells[1][start] = "Код";
                worksheet.Cells[2][start] = "Наименование";
                worksheet.Cells[3][start] = "Количество заказов";

                start++;
                for (int i = 0; i < all.Count(); i++)
                {
                    worksheet.Cells[1][start] = all[i].idBluda;
                    worksheet.Cells[2][start] = all[i].NameBludo;
                    int sum = 0;
                    foreach (var item in db.ZakazBluda)
                    {
                        if (item.Menu.idBluda == all[i].idBluda)
                        {
                            sum += item.Kolvo;
                        }
                    }
                    worksheet.Cells[3][start] = sum;

                    start++;
                }
                application.Visible = true;

            }
            else if (type == 3)
            {
                var all = db.SkidCards.ToList().OrderBy(p => p.idCard).ToList();
                var application = new Excel.Application();
                application.SheetsInNewWorkbook = 2;
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                int start = 1;
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                worksheet.Name = "Отчет по скидочным картам";
                worksheet.Cells[1][start] = "Код";
                worksheet.Cells[2][start] = "ФИО";
                worksheet.Cells[3][start] = "Номинал";

                start++;
                for (int i = 0; i < all.Count(); i++)
                {
                    worksheet.Cells[1][start] = all[i].idCard;
                    worksheet.Cells[2][start] = all[i].Surname+" "+all[i].Name+" "+all[i].Patronymic;
                    worksheet.Cells[3][start] = all[i].Nominal;

                    start++;
                }
                application.Visible = true;
            }
        }

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            if (type == 1)
            {
                var Emp = db.Employee.ToList();

                //экземпляр приложения
                var app = new Word.Application();

                //добавления документа в приложение
                Word.Document doc = app.Documents.Add();

                foreach (var item in Emp)
                {
                    Word.Paragraph parHead = doc.Paragraphs.Add();
                    Word.Range rangeHead = parHead.Range;
                    rangeHead.Text = $"Отчет по оказанным услугам сотрудника: {item.Surname} {item.Name} {item.Patronymic}";
                    try
                    {
                        parHead.set_Style("Title");
                    }
                    catch
                    {
                        parHead.set_Style("Заголовок");
                    }
                    rangeHead.InsertParagraphAfter();

                    Word.Paragraph tablePar = doc.Paragraphs.Add();
                    Word.Range tabRan = tablePar.Range;
                    Word.Table analyzTable = doc.Tables.Add(tabRan, item.Zakazi.Count() + 1, 3);
                    analyzTable.Borders.InsideLineStyle = analyzTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    analyzTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    Word.Range cellRange;

                    cellRange = analyzTable.Cell(1, 1).Range;
                    cellRange.Text = "Код заказа";
                    cellRange = analyzTable.Cell(1, 2).Range;
                    cellRange.Text = "Блюда";
                    cellRange = analyzTable.Cell(1, 3).Range;
                    cellRange.Text = "Итог";

                    analyzTable.Rows[1].Range.Bold = 1;
                    analyzTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    var pOrders = db.Zakazi.Where(t => t.Employee == item.idEmployee).ToList();

                    for (int i = 0; i < pOrders.Count(); i++)
                    {
                        var currentOrd = pOrders[i];

                        cellRange = analyzTable.Cell(i + 2, 1).Range;
                        cellRange.Text = currentOrd.idZakaza.ToString();

                        string txt = "";

                        foreach (var item3 in db.ZakazBluda)
                        {
                            if (item3.idZakaza == pOrders[i].idZakaza)
                            {
                                if (txt == "")
                                {
                                    txt = "Наименование: " + item3.Menu.NameBludo + ", кол-во: " + item3.Kolvo + ", цена: " + item3.Cena;
                                }
                                else
                                    txt += "\nНаименование: " + item3.Menu.NameBludo + ", кол-во: " + item3.Kolvo + ", цена: " + item3.Cena;
                            }
                        }

                        cellRange = analyzTable.Cell(i + 2, 2).Range;
                        cellRange.Text = txt;

                        cellRange = analyzTable.Cell(i + 2, 3).Range;
                        cellRange.Text = currentOrd.SummaZakaza.ToString();
                    }

                    Word.Paragraph itogAnalyz = doc.Paragraphs.Add();
                    Word.Range itogRange = itogAnalyz.Range;

                    double summ = 0;
                    foreach (var item2 in db.Zakazi)
                    {
                        if (item2.Employee == item.idEmployee)
                        {
                            summ += item2.SummaZakaza;
                        }
                    }

                    itogRange.Text = $"Общая сумма: {summ}.";
                    try
                    {
                        itogRange.set_Style("Intense Quote");
                    }
                    catch
                    {
                        itogRange.set_Style("Выделенная цитата");
                    }
                    itogRange.Font.Color = Word.WdColor.wdColorRed;
                    itogRange.InsertParagraphAfter();

                    if (item != Emp.LastOrDefault())
                    {
                        doc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                    }
                }
                app.Visible = true;
            }
            else if (type == 2)
            {
                var Men = db.Menu.ToList();

                //экземпляр приложения
                var app = new Word.Application();

                //добавления документа в приложение
                Word.Document doc = app.Documents.Add();

                Word.Paragraph parHead = doc.Paragraphs.Add();
                Word.Range rangeHead = parHead.Range;
                rangeHead.Text = $"Отчет по блюдам";
                try
                {
                    parHead.set_Style("Title");
                }
                catch
                {
                    parHead.set_Style("Заголовок");
                }
                rangeHead.InsertParagraphAfter();

                Word.Paragraph tablePar = doc.Paragraphs.Add();
                Word.Range tabRan = tablePar.Range;
                Word.Table analyzTable = doc.Tables.Add(tabRan, Men.Count() + 1, 3);
                analyzTable.Borders.InsideLineStyle = analyzTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                analyzTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = analyzTable.Cell(1, 1).Range;
                cellRange.Text = "Код";
                cellRange = analyzTable.Cell(1, 2).Range;
                cellRange.Text = "Наименование";
                cellRange = analyzTable.Cell(1, 3).Range;
                cellRange.Text = "Количество заказов";

                analyzTable.Rows[1].Range.Bold = 1;
                analyzTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                var pMenu = db.Menu.ToList();

                for (int i = 0; i < pMenu.Count(); i++)
                {
                    var currentMenu = pMenu[i];

                    cellRange = analyzTable.Cell(i + 2, 1).Range;
                    cellRange.Text = currentMenu.idBluda.ToString();

                    cellRange = analyzTable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentMenu.NameBludo.ToString();

                    int sum = 0;
                    foreach (var item in db.ZakazBluda)
                    {
                        if (pMenu[i].idBluda == item.Menu.idBluda)
                        {
                            sum += item.Kolvo;
                        }
                    }
                    cellRange = analyzTable.Cell(i + 2, 3).Range;
                    cellRange.Text = sum.ToString();
                }

                Word.Paragraph itogAnalyz = doc.Paragraphs.Add();
                Word.Range itogRange = itogAnalyz.Range;

                itogRange.Font.Color = Word.WdColor.wdColorRed;
                itogRange.InsertParagraphAfter();

                app.Visible = true;
            }
            else if (type == 3)
            {
                var SC = db.SkidCards.ToList();

                //экземпляр приложения
                var app = new Word.Application();

                //добавления документа в приложение
                Word.Document doc = app.Documents.Add();

                Word.Paragraph parHead = doc.Paragraphs.Add();
                Word.Range rangeHead = parHead.Range;
                rangeHead.Text = $"Отчет по скидочным картам";
                try
                {
                    parHead.set_Style("Title");
                }
                catch
                {
                    parHead.set_Style("Заголовок");
                }
                rangeHead.InsertParagraphAfter();

                Word.Paragraph tablePar = doc.Paragraphs.Add();
                Word.Range tabRan = tablePar.Range;
                Word.Table analyzTable = doc.Tables.Add(tabRan, SC.Count() + 1, 3);
                analyzTable.Borders.InsideLineStyle = analyzTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                analyzTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = analyzTable.Cell(1, 1).Range;
                cellRange.Text = "Код";
                cellRange = analyzTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = analyzTable.Cell(1, 3).Range;
                cellRange.Text = "Номинал";

                analyzTable.Rows[1].Range.Bold = 1;
                analyzTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                var pSC = db.SkidCards.ToList();

                for (int i = 0; i < pSC.Count(); i++)
                {
                    var currentSC = pSC[i];

                    cellRange = analyzTable.Cell(i + 2, 1).Range;
                    cellRange.Text = currentSC.idCard.ToString();

                    cellRange = analyzTable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentSC.Surname.ToString()+" "+currentSC.Name.ToString()+" "+currentSC.Patronymic.ToString();

                    cellRange = analyzTable.Cell(i + 2, 3).Range;
                    cellRange.Text = currentSC.Nominal.ToString();
                }

                Word.Paragraph itogAnalyz = doc.Paragraphs.Add();
                Word.Range itogRange = itogAnalyz.Range;

                itogRange.Font.Color = Word.WdColor.wdColorRed;
                itogRange.InsertParagraphAfter();

                app.Visible = true;
            }
        }
    }
}