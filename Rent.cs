//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Malina_Nizametdinova
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rent()
        {
            this.Tenants1 = new HashSet<Tenants>();
        }
    
        public int ID { get; set; }
        public int ID_Tenant { get; set; }
        public string Name { get; set; }
        public int ID_Employee { get; set; }
        public string C__Pavilion { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Rent_start { get; set; }
        public Nullable<System.DateTime> Rent_end { get; set; }
    
        public virtual Employees Employees { get; set; }
        public virtual Tenants Tenants { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tenants> Tenants1 { get; set; }
    }
}
