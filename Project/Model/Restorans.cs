using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Restorans : ObservableCollection<Restaurants>
    {
        user3Entities db = new user3Entities();
        public Restorans()
        {
            var q =
                from rest in db.Restaurants
                select rest;

            foreach (Restaurants item in q)
            {
                this.Add(item);
            }
        }
    }
}
