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
    
    public partial class BEMPL_CAT_CIUDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BEMPL_CAT_CIUDAD()
        {
            this.BEMPL_DATOSPOSTULANTE = new HashSet<BEMPL_DATOSPOSTULANTE>();
        }
    
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public Nullable<int> IdProvincia { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BEMPL_DATOSPOSTULANTE> BEMPL_DATOSPOSTULANTE { get; set; }
    }
}