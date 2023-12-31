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
    
    public partial class tNM_SolicitudVacacionesCab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_SolicitudVacacionesCab()
        {
            this.tNM_SolicitudVacacionesDet = new HashSet<tNM_SolicitudVacacionesDet>();
        }
    
        public int IdSolicitudVacaciones { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdTipoAusencia { get; set; }
        public Nullable<int> IdSupervisor { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string RespuestaSupervisor { get; set; }
        public Nullable<System.DateTime> FechaAprobacionSupervisor { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<int> IdEstadoAprob { get; set; }
        public Nullable<decimal> DiasSolicitados { get; set; }
        public Nullable<int> IdColaboradorReemplazo { get; set; }
        public string UrlSolicitud { get; set; }
    
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores1 { get; set; }
        public virtual tNM_EstadosFlujoAusencias tNM_EstadosFlujoAusencias { get; set; }
        public virtual tNM_TiposAusencia tNM_TiposAusencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudVacacionesDet> tNM_SolicitudVacacionesDet { get; set; }
    }
}
