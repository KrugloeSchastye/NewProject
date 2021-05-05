using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Role : ObservableCollection<Roles>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public Role()
        {
            var q =
                from stol in db.Roles
                select stol;

            foreach (Roles item in q)
            {
                this.Add(item);
            }
        }
    }
}
