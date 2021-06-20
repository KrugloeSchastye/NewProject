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
    /// Логика взаимодействия для ZakazInfoWindow.xaml
    /// </summary>
    public partial class ZakazInfoWindow : Window
    {
        user3Entities db = new user3Entities();
        int idZak;
        int stol;
        double summ;
        double summS;
        string open;
        string close;
        public ZakazInfoWindow(int idZak, int stol, double summ, double summS, string open, string close)
        {
            InitializeComponent();
            this.idZak = idZak;
            this.stol = stol;
            this.summ = summ;
            this.summS = summS;
            this.open = open;
            this.close = close;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Zakazi zakazi = new Zakazi();

            txtStol.Text = stol.ToString(); 
            txtSumma.Text = summ.ToString();
            txtSummaS.Text = summS.ToString();
            txtDateOpen.Text = open.ToString();
            txtDateClose.Text = close.ToString();
            dgZakBludo.ItemsSource = db.ZakazBluda.Where(t => t.idZakaza == idZak).ToArray().ToList();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            var zak111 = db.Zakazi.Where(t => t.idZakaza == idZak).FirstOrDefault();

            string stri = "----------- Круглое счастье -----------";
            stri += "\n=======================================";
            var zb = db.ZakazBluda.Where(t => t.idZakaza == zak111.idZakaza).ToList();

            for (int i = 0; i < zb.Count(); i++)
            {
                string nBluda = "";
                if (zb[i].Menu.NameBludo.ToString().Length > 6)
                {
                    char[] ar = zb[i].Menu.NameBludo.ToString().ToCharArray();
                    nBluda = $"{ar[0]}{ar[1]}{ar[2]}{ar[3]}{ar[4]}{ar[5]}.";
                    stri += $"\n{nBluda}\t\t{zb[i].Kolvo}\t{zb[i].Cena}\t{zb[i].Summa}";
                }
                else
                {
                    stri += $"\n{zb[i].Menu.NameBludo}\t\t{zb[i].Kolvo}\t{zb[i].Cena}\t{zb[i].Summa}";
                }
            }
            stri += "\n=======================================";
            stri += $"\nИтого: {zak111.SummaZakaza} рублей";
            stri += $"\nИтог со скидкой: {zak111.SummaZakazaS} рублей";
            stri += "\n=======================================";
            stri += $"\nСотрудник: {zak111.Employee1.Surname}";
            stri += $"\nСтол: {zak111.Stol}";
            stri += $"\nОткрыт: {zak111.DateOpenZakaz}";
            stri += $"\nЗакрыт: {zak111.DateCloseZakaz}";
            stri += "\n=======================================";
            stri += "\nСпасибо за заказ, приятного аппетита!";
            stri += "\n=======================================";

            System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\Чек.txt", stri);
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\Чек.txt");
        }
    }
}
