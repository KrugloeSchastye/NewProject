//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakazi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakazi()
        {
            this.ZakazBluda = new HashSet<ZakazBluda>();
        }
    
        public int idZakaza { get; set; }
        public int Stol { get; set; }
        public double SummaZakaza { get; set; }
        public Nullable<double> SummaZakazaS { get; set; }
        public Nullable<System.DateTime> DateOpenZakaz { get; set; }
        public Nullable<System.DateTime> DateCloseZakaz { get; set; }
        public int Employee { get; set; }
        public bool Closed { get; set; }
        public string idSCard { get; set; }
    
        public virtual Employee Employee1 { get; set; }
        public virtual Stoli Stoli { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazBluda> ZakazBluda { get; set; }
    }
}
