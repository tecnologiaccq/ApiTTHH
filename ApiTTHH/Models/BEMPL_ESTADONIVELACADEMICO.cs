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
    
    public partial class BEMPL_ESTADONIVELACADEMICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BEMPL_ESTADONIVELACADEMICO()
        {
            this.BEMPL_DATOS_ACADEMICOS = new HashSet<BEMPL_DATOS_ACADEMICOS>();
        }
    
        public int IdEstadoAcademico { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BEMPL_DATOS_ACADEMICOS> BEMPL_DATOS_ACADEMICOS { get; set; }
    }
}
