using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Stol : ObservableCollection<Stoli>
    {
        KrugloeSchastyeEntities db = new KrugloeSchastyeEntities();
        public Stol()
        {
            var q =
                from stol in db.Stoli
                select stol;

            foreach (Stoli item in q)
            {
                this.Add(item);
            }
        }
    }
}
