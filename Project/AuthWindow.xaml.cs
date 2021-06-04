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
using System.Windows.Threading;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        public AuthWindow()
        {
            InitializeComponent();
            //BookingStolWind bookingStol = new BookingStolWind();
            //bookingStol.Show();
        }
        string Login { get; set; }
        string Dates { get; set; }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            bool enter = false;
            user3Entities db = new user3Entities();

            Login itemLogin = db.Login.Where(i => i.UserName == txtbLogin.Text).FirstOrDefault();
            if (itemLogin == null)
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
            else
            {
                foreach (var item in db.Login)
                {
                    if (itemLogin.UserName == item.UserName && pswbPassword.Password == item.Password)
                    {
                        this.Login = item.UserName;
                        this.Dates = DateTime.Now.ToString();
                        new MainWindow(this.Login, this.Dates ).Show();
                        this.Close();
                        enter = true;
                    }
                }
                if (!enter)
                {
                    itemLogin.CountWrong++;
                    if (itemLogin.CountWrong < 5)
                    {
                        MessageBox.Show($"Неправильно введены логин или пароль Попытка {itemLogin.CountWrong}/5", "Ошибка", MessageBoxButton.OK);
                    }
                    if (itemLogin.CountWrong == 5)
                    {
                        MessageBox.Show("Этот логин Заблокирован (" + itemLogin.UserName + ")");
                        Block(itemLogin, db);
                    }
                    if (itemLogin.CountWrong > 5)
                    {
                        MessageBox.Show("Дождитесь, пока пройдет блокировка");
                    }
                    db.SaveChanges();
                }
            }
        }
        public async void Block(Login item, user3Entities db)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 5);
            if (item.CountWrong >= 5 && item.UserName == "Admin")
            {
                timer.Interval = timeSpan;
                timer.Start();
                await Task.Run(() => this.timer.Tick += ((o, e) =>
                {
                    item.CountWrong = 0;
                    db.SaveChanges();
                    MessageBox.Show(item.UserName + " разблокирован");
                    timer.Stop();
                }));
            }
            if (item.CountWrong >= 5 && item.UserName == "Manager")
            {
                timer.Interval = timeSpan;
                timer.Start();
                await Task.Run(() => this.timer.Tick += ((o, e) =>
                {
                    item.CountWrong = 0;
                    db.SaveChanges();
                    MessageBox.Show(item.UserName + " разблокирован");
                    timer.Stop();
                }));
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
