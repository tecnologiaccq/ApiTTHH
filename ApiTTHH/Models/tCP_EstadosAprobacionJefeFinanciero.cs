//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCP_EstadosAprobacionJefeFinanciero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCP_EstadosAprobacionJefeFinanciero()
        {
            this.tCP_CargosCab = new HashSet<tCP_CargosCab>();
        }
    
        public int IdEstadoAprobacion { get; set; }
        public string NombreEstado { get; set; }
        public Nullable<bool> Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCab> tCP_CargosCab { get; set; }
    }
}
