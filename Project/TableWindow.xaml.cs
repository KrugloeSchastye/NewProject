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
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public TableWindow()
        {
            InitializeComponent();
            lvTables.ItemsSource = db.Stoli.ToArray().ToList();
        }

        private void lvTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Stoli s = lvTables.SelectedItem as Stoli;
            int idStola = Convert.ToInt32(s.idStola);
            if (MessageBox.Show("Освободить стол?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var item in db.Stoli)
                {
                    if (idStola == item.idStola && item.IsBusy == false)
                    {
                        item.IsBusy = true;
                        foreach (var i in db.Zakazi)
                        {
                            if (idStola == i.Stol)
                            {
                                i.DateCloseZakaz = DateTime.Now;
                            }
                        }
                    }
                }
                db.SaveChanges();
            }
            lvTables.ItemsSource = db.Stoli.ToArray().ToList();
        }
    }
}
