//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Malina_Nizametdinova
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tenants
    {
        public Tenants()
        {
            this.Rent = new HashSet<Rent>();
        }
    
        public int ID { get; set; }
        public int ID_Rent { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Adress { get; set; }
    
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
