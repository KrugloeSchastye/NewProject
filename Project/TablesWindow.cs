﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class TablesWindow : Form
    {
        string titl;
        string Login;
        public TablesWindow(string titl,string Login)
        {
            this.titl = titl;
            InitializeComponent();
            this.Login = Login;
            this.Text = titl;

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
                    }
                }
            }
        }
        user3Entities db = new user3Entities();

        private void btnStol1_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 1).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola, 0, Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят","Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol2_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 2).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol3_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 3).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol4_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 4).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol5_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 5).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol6_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 6).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol7_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 7).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol8_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 8).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol9_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 9).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol10_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 10).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol11_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 11).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol12_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 12).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol13_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 13).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol14_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 14).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol15_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 15).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol16_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 16).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol17_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 17).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol18_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 18).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol19_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 19).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol20_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 20).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStol21_Click(object sender, EventArgs e)
        {
            var tab = db.Stoli.Where(t => t.idStola == 21).FirstOrDefault();
            if (tab.IsBusy == true)
            {
                foreach (var i in db.Stoli)
                {
                    if (tab.idStola == i.idStola)
                    {
                        i.IsBusy = false;
                    }
                }
                new RegOrders(tab.idStola,0,Login).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Стол занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TablesWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
