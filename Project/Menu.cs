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
    
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            this.ZakazBluda = new HashSet<ZakazBluda>();
        }
    
        public int idBluda { get; set; }
        public string NameBludo { get; set; }
        public string Wheight { get; set; }
        public string Struct { get; set; }
        public int RazdelMenu { get; set; }
        public int Price { get; set; }
    
        public virtual Razdeli Razdeli { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazBluda> ZakazBluda { get; set; }
    }
}
