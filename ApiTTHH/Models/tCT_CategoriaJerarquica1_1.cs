//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCT_CategoriaJerarquica1_1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCT_CategoriaJerarquica1_1()
        {
            this.tCT_CategoriaJerarquica1_2 = new HashSet<tCT_CategoriaJerarquica1_2>();
        }
    
        public int IdCategoriaJerarquica1_1 { get; set; }
        public string CategoriaJerarquica1_1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCT_CategoriaJerarquica1_2> tCT_CategoriaJerarquica1_2 { get; set; }
    }
}
