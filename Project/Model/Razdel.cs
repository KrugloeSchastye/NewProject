using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    class Razdel : ObservableCollection<Razdeli>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public Razdel()
        {
            var q =
                from rMenu in db.Razdeli
                select rMenu;
            foreach (Razdeli item in q)
            {
                this.Add(item);
            }
        }
    }
}
