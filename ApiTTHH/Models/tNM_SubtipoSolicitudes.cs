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
    
    public partial class tNM_SubtipoSolicitudes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_SubtipoSolicitudes()
        {
            this.tNM_Solicitudes = new HashSet<tNM_Solicitudes>();
            this.tNM_SolicitudesTablaAmortizacion = new HashSet<tNM_SolicitudesTablaAmortizacion>();
        }
    
        public int IdSubtipoSolicitud { get; set; }
        public Nullable<int> IdTipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> ApruebaSupervisor { get; set; }
        public Nullable<byte> OrdenAprobacionSupervisor { get; set; }
        public Nullable<bool> ApruebaTH { get; set; }
        public Nullable<byte> OrdenAprobacionTH { get; set; }
        public Nullable<bool> ApruebaFinanciero { get; set; }
        public Nullable<byte> OrdenAprobacionFinanciero { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<bool> RequiereTablaAmortizacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tNM_Conceptos tNM_Conceptos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Solicitudes> tNM_Solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudesTablaAmortizacion> tNM_SolicitudesTablaAmortizacion { get; set; }
        public virtual tNM_TiposSolicitudes tNM_TiposSolicitudes { get; set; }
    }
}
