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
    
    public partial class tNM_TiposEstadoCuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_TiposEstadoCuenta()
        {
            this.tNM_EstadosCuentaColaborador = new HashSet<tNM_EstadosCuentaColaborador>();
        }
    
        public int IdTipoEstadoCuenta { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_EstadosCuentaColaborador> tNM_EstadosCuentaColaborador { get; set; }
    }
}
