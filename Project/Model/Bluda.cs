﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Bluda : ObservableCollection<Menu>
    {
        user3Entities db = new user3Entities();
        public Bluda()
        {
            var q =
                from lmenu in db.Menu
                select lmenu;
            foreach (Menu item in q)
            {
                this.Add(item);
            }
        }
    }
}
