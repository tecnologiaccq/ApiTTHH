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
