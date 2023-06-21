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
    
    public partial class tNM_Vacaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_Vacaciones()
        {
            this.tNM_DetalleVacaciones = new HashSet<tNM_DetalleVacaciones>();
            this.tNM_VacacionesDetalle = new HashSet<tNM_VacacionesDetalle>();
        }
    
        public long IdVacacion { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string Explicacion { get; set; }
        public string Respuesta { get; set; }
        public Nullable<int> IdSupervisor { get; set; }
        public Nullable<System.DateTime> FechaEnvioSupervisor { get; set; }
        public string RespuestaSupervisor { get; set; }
        public Nullable<bool> FueAprobadaSupervisor { get; set; }
        public string UsuarioSupervisor { get; set; }
        public Nullable<System.DateTime> FechaAprobacionSupervisor { get; set; }
        public Nullable<System.DateTime> FechaEnvioTH { get; set; }
        public Nullable<bool> FueAprobadaTH { get; set; }
        public string UsuarioTH { get; set; }
        public Nullable<System.DateTime> FechaAprobacionTH { get; set; }
        public string RespuestaTH { get; set; }
        public string NotificadoNomina { get; set; }
        public Nullable<System.DateTime> FechaNotificacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<decimal> DiasSolicitados { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public Nullable<int> FueProcesada { get; set; }
    
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_DetalleVacaciones> tNM_DetalleVacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_VacacionesDetalle> tNM_VacacionesDetalle { get; set; }
    }
}