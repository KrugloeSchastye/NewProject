using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Emp : ObservableCollection<Employee>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public Emp()
        {
            var q =
                from lmenu in db.Employee
                select lmenu;
            foreach (Employee item in q)
            {
                this.Add(item);
            }
        }
    }
}
