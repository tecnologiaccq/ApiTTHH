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
    
    public partial class tNM_EstadosFlujoAusencias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_EstadosFlujoAusencias()
        {
            this.tNM_SolicitudPermiso = new HashSet<tNM_SolicitudPermiso>();
            this.tNM_SolicitudVacacionesCab = new HashSet<tNM_SolicitudVacacionesCab>();
        }
    
        public int IDEstado { get; set; }
        public string Descripcion { get; set; }
        public string Beneficio { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CodigoEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudPermiso> tNM_SolicitudPermiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudVacacionesCab> tNM_SolicitudVacacionesCab { get; set; }
    }
}