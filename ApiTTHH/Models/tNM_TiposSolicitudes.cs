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
    
    public partial class tNM_TiposSolicitudes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_TiposSolicitudes()
        {
            this.tNM_Solicitudes = new HashSet<tNM_Solicitudes>();
            this.tNM_SolicitudesTablaAmortizacion = new HashSet<tNM_SolicitudesTablaAmortizacion>();
            this.tNM_SubtipoSolicitudes = new HashSet<tNM_SubtipoSolicitudes>();
        }
    
        public int IdTipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Solicitudes> tNM_Solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudesTablaAmortizacion> tNM_SolicitudesTablaAmortizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SubtipoSolicitudes> tNM_SubtipoSolicitudes { get; set; }
    }
}
