using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project {
    public partial class BookingStolWind : Form {
        string currDate = "";
        string Login;
        public BookingStolWind(string Login)
        {
            InitializeComponent();
            currDate = dpDateBooking.Value.ToString("d");
            Obnulenie();
            object sender=new object(); 
            EventArgs e=new EventArgs();
            txtTime_TextChanged(sender,e);
            dpDateBooking.MinDate = DateTime.Parse(DateTime.Now.ToString("d"));
            this.Login = Login;
        }
     

        user3Entities db = new user3Entities();
        private void btnStol1_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text ="1";
          
            Refresh();
        }

        
        
        private void dpDateBooking_ValueChanged(object sender, EventArgs e)
        {
            currDate = dpDateBooking.Value.ToString("d");
            txtTime_TextChanged(sender,e);
            lblNumberStol.Text = "";
            

        }
        
        private void btnStol2_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "2";
            
            Refresh();
        }

        private void btnStol3_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "3";
            
            Refresh();
        }

        private void btnStol4_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "4";
            
            Refresh();
        }

        private void btnStol5_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "5";
            
            Refresh();
        }

        private void btnStol6_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "6";
            
            Refresh();
        }

        private void btnStol7_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "7";
            
            Refresh();
        }

        private void btnStol8_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "8";
            
            Refresh();
        }

        private void btnStol9_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "9";
            
            Refresh();
        }

        private void btnStol10_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "10";
            
            Refresh();
        }

        private void btnStol11_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "11";
            
            Refresh();
        }

        private void btnStol12_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "12";
            
            Refresh();
        }

        private void btnStol13_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "13";
            
            Refresh();
        }

        private void btnStol14_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "14";
            
            Refresh();
        }

        private void btnStol15_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "15";
            
            Refresh();
        }

        private void btnStol16_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "16";
            
            Refresh();
        }

        private void btnStol17_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "17";
            
            Refresh();
        }

        private void btnStol18_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "18";
            
            Refresh();
        }

        private void btnStol19_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "19";
            
            Refresh();
        }

        private void btnStol20_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "20";
            
            Refresh();
        }

        private void btnStol21_Click(object sender, EventArgs e)
        {
            lblNumberStol.Text = "21";
            
            Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool proverka = true;
            Regex regex = new Regex(@"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
            Match match = regex.Match(txtFIO.Text);
            if (!match.Success)
            {
                proverka = false;
                MessageBox.Show("Поле с ФИО некорректно введено");
            }

            if (lblNumberStol.Text == "")
            {
                proverka = false;
                MessageBox.Show("Стол не выбран");
            }

            if (txtNumberPhone.Text == "")
            {
                proverka = false;
                MessageBox.Show("Поле номер телефона не заполнено");
            }

            regex =new Regex( @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)");
            Match match1 = regex.Match(txtNumberPhone.Text);
            if (!match1.Success)
            {
                proverka = false;
                MessageBox.Show("Некорректно введен номер телефона");
            }

            if (txtTime.Text == "")
            {
                proverka = false;
                MessageBox.Show("Поле время бронирования не заполнено");
            }

            int result;
            if (!int.TryParse(txtCountPeople.Text,out result))
            {
                proverka = false;
                MessageBox.Show("В поле количество необходимо вводить цифры");
            }

            if (proverka == true)
            {
                BookingStol bookingStol = new BookingStol();
                bookingStol.idStol = int.Parse(lblNumberStol.Text);
                
                bookingStol.TimeBooking = txtTime.Text;
                bookingStol.DateBooking = currDate;
                bookingStol.ClientFIO = txtFIO.Text;
                bookingStol.Status = false;
                db.BookingStol.Add(bookingStol);
                db.SaveChanges();

                MessageBox.Show("Бронь успешно создана");
                DialogResult dialogResult = MessageBox.Show("Бронирование успешно создано.\nСделать предзаказ?", "", MessageBoxButtons.YesNo);
                
                if(dialogResult==DialogResult.Yes)
                {
                    string statusZakaza = "Предзаказ";
                    RegOrders next = new RegOrders(int.Parse(lblNumberStol.Text),0,Login);
                    next.lblStasus.Content = statusZakaza;
                    next.lblDate.Content = currDate + " "+txtTime.Text;
                    next.Show();
                    Close();


                }
                
                Close();
            }
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            Obnulenie();
            List<BookingStol> list = db.BookingStol.Where(i => i.DateBooking == currDate&&i.Status==false).ToList();
            if (currDate == DateTime.Now.ToString("d")) 
                {
                var tables = db.Stoli.ToList();
                foreach (var item in tables)
                {
                    if (item.idStola == 1)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol1.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol1.BackColor = Color.Red;
                            btnStol1.Enabled = false;
                        }
                    }
                    if (item.idStola == 2)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol2.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol2.BackColor = Color.Red;
                            btnStol2.Enabled = false;
                        }
                    }
                    if (item.idStola == 3)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol3.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol3.BackColor = Color.Red;
                            btnStol3.Enabled = false;
                        }
                    }
                    if (item.idStola == 4)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol4.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol4.BackColor = Color.Red;
                            btnStol4.Enabled = false;
                        }
                    }
                    if (item.idStola == 5)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol5.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol5.BackColor = Color.Red;
                            btnStol5.Enabled = false;
                        }
                    }
                    if (item.idStola == 6)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol6.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol6.BackColor = Color.Red;
                            btnStol6.Enabled = false;
                        }
                    }
                    if (item.idStola == 7)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol7.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol7.BackColor = Color.Red;
                            btnStol7.Enabled = false;
                        }
                    }
                    if (item.idStola == 8)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol8.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol8.BackColor = Color.Red;
                            btnStol8.Enabled = false;
                        }
                    }
                    if (item.idStola == 9)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol9.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol9.BackColor = Color.Red;
                            btnStol9.Enabled = false;
                        }
                    }
                    if (item.idStola == 10)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol10.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol10.BackColor = Color.Red;
                            btnStol10.Enabled = false;
                        }
                    }
                    if (item.idStola == 11)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol11.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol11.BackColor = Color.Red;
                            btnStol11.Enabled = false;
                        }
                    }
                    if (item.idStola == 12)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol12.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol12.BackColor = Color.Red;
                            btnStol12.Enabled = false;
                        }
                    }
                    if (item.idStola == 13)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol13.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol13.BackColor = Color.Red;
                            btnStol13.Enabled = false;
                        }
                    }
                    if (item.idStola == 14)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol14.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol14.BackColor = Color.Red;
                            btnStol14.Enabled = false;
                        }
                    }
                    if (item.idStola == 15)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol15.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol15.BackColor = Color.Red;
                            btnStol15.Enabled = false;
                        }
                    }
                    if (item.idStola == 16)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol16.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol16.BackColor = Color.Red;
                            btnStol16.Enabled = false;
                        }
                    }
                    if (item.idStola == 17)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol17.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol17.BackColor = Color.Red;
                            btnStol17.Enabled = false;
                        }
                    }
                    if (item.idStola == 18)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol18.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol18.BackColor = Color.Red;
                            btnStol18.Enabled = false;
                        }
                    }
                    if (item.idStola == 19)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol19.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol19.BackColor = Color.Red;
                            btnStol19.Enabled = false;
                        }
                    }
                    if (item.idStola == 20)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol20.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol20.BackColor = Color.Red;
                            btnStol20.Enabled = false;
                        }
                    }
                    if (item.idStola == 21)
                    {
                        if (item.IsBusy == true)
                        {
                            btnStol21.BackColor = Color.Green;
                        }
                        else
                        {
                            btnStol21.BackColor = Color.Red;
                            btnStol21.Enabled = false;
                        }
                    }

                }
            }
            foreach (var item in list)
                
                if (item.TimeBooking != null)
                { 

                    if (item.idStol == 1)
                    {
                        btnStol1.BackColor = Color.Red;
                        btnStol1.Enabled = false;
                    }

                    if (item.idStol == 2)
                    {
                        btnStol2.BackColor = Color.Red;
                        btnStol2.Enabled = false;
                    }

                    if (item.idStol == 3)
                    {
                        btnStol3.BackColor = Color.Red;
                        btnStol3.Enabled = false;
                    }

                    if (item.idStol == 4)
                    {
                        btnStol4.BackColor = Color.Red;
                        btnStol4.Enabled = false;
                    }

                    if (item.idStol == 5)
                    {
                        btnStol5.BackColor = Color.Red;
                        btnStol5.Enabled = false;
                    }


                    if (item.idStol == 6)
                    {
                        btnStol6.BackColor = Color.Red;
                        btnStol6.Enabled = false;

                    }

                    if (item.idStol == 7)
                    {
                        btnStol7.BackColor = Color.Red;
                        btnStol7.Enabled = false;

                    }

                    if (item.idStol == 8)
                    {
                        btnStol8.BackColor = Color.Red;
                        btnStol8.Enabled = false;

                    }

                    if (item.idStol == 9)
                    {
                        btnStol9.BackColor = Color.Red;
                        btnStol9.Enabled = false;

                    }

                    if (item.idStol == 10)
                    {
                        btnStol10.BackColor = Color.Red;
                        btnStol10.Enabled = false;

                    }
                    if (item.idStol == 11)
                    {
                        btnStol11.BackColor = Color.Red;
                        btnStol11.Enabled = false;

                    }

                    if (item.idStol == 12)
                    {
                        btnStol12.BackColor = Color.Red;
                        btnStol12.Enabled = false;

                    }

                    if (item.idStol == 13)
                    {
                        btnStol13.BackColor = Color.Red;
                        btnStol13.Enabled = false;

                    }

                    if (item.idStol == 14)
                    {
                        btnStol14.BackColor = Color.Red;
                        btnStol14.Enabled = false;

                    }

                    if (item.idStol == 15)
                    {
                        btnStol15.BackColor = Color.Red;
                        btnStol15.Enabled = false;

                    }

                    if (item.idStol == 16)
                    {
                        btnStol16.BackColor = Color.Red;
                        btnStol16.Enabled = false;

                    }

                    if (item.idStol == 17)
                    {
                        btnStol17.BackColor = Color.Red;
                        btnStol17.Enabled = false;

                    }

                    if (item.idStol == 18)
                    {
                        btnStol18.BackColor = Color.Red;
                        btnStol18.Enabled = false;

                    }

                    if (item.idStol == 19)
                    {
                        btnStol19.BackColor = Color.Red;
                        btnStol19.Enabled = false;

                    }

                    if (item.idStol == 20)
                    {
                        btnStol20.BackColor = Color.Red;
                        btnStol20.Enabled = false;

                    }

                    if (item.idStol == 21)
                    {
                        btnStol21.BackColor = Color.Red;
                        btnStol21.Enabled = false;
                    }
                }
            }
        public void Obnulenie()
        {
            btnStol1.BackColor = Color.Green;
            btnStol1.Enabled = true;

            btnStol2.BackColor = Color.Green;
            btnStol2.Enabled = true;

            btnStol3.BackColor = Color.Green;
            btnStol3.Enabled = true;

            btnStol4.BackColor = Color.Green;
            btnStol4.Enabled = true;

            btnStol5.BackColor = Color.Green;
            btnStol5.Enabled = true;

            btnStol6.BackColor = Color.Green;
            btnStol6.Enabled = true;

            btnStol7.BackColor = Color.Green;
            btnStol7.Enabled = true;

            btnStol8.BackColor = Color.Green;
            btnStol8.Enabled = true;

            btnStol9.BackColor = Color.Green;
            btnStol9.Enabled = true;

            btnStol10.BackColor = Color.Green;
            btnStol10.Enabled = true;

            btnStol11.BackColor = Color.Green;
            btnStol11.Enabled = true;

            btnStol12.BackColor = Color.Green;
            btnStol12.Enabled = true;

            btnStol13.BackColor = Color.Green;
            btnStol13.Enabled = true;

            btnStol14.BackColor = Color.Green;
            btnStol14.Enabled = true;

            btnStol15.BackColor = Color.Green;
            btnStol15.Enabled = true;

            btnStol16.BackColor = Color.Green;
            btnStol16.Enabled = true;


            btnStol17.BackColor = Color.Green;
            btnStol17.Enabled = true;

            btnStol18.BackColor = Color.Green;
            btnStol18.Enabled = true;

            btnStol19.BackColor = Color.Green;
            btnStol19.Enabled = true;

            btnStol20.BackColor = Color.Green;
            btnStol20.Enabled = true;

            btnStol21.BackColor = Color.Green;
            btnStol21.Enabled = true;
        }
    }
}

