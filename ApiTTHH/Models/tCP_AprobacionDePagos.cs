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
    
    public partial class tCP_AprobacionDePagos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCP_AprobacionDePagos()
        {
            this.tCP_TemporalAprobacionPagos = new HashSet<tCP_TemporalAprobacionPagos>();
        }
    
        public int IdAprobacionPago { get; set; }
        public Nullable<int> IdAprobacionPagoCab { get; set; }
        public Nullable<int> SecuencialCobro { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public int IdCargoCab { get; set; }
        public Nullable<int> IdMedioPago { get; set; }
        public Nullable<int> IdBancosCCQ { get; set; }
        public int IdProveedor { get; set; }
        public decimal ValorPagar { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdFinanciamientoCargos { get; set; }
        public Nullable<bool> EstadoSeleccion { get; set; }
        public Nullable<bool> EstadoAprobacion { get; set; }
        public Nullable<bool> EstadoOrdenPago { get; set; }
        public Nullable<bool> ArchivoGenerado { get; set; }
        public Nullable<bool> EstaPagado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<bool> @fixed { get; set; }
    
        public virtual tCP_AprobacionDePagosCab tCP_AprobacionDePagosCab { get; set; }
        public virtual tCP_CargosCab tCP_CargosCab { get; set; }
        public virtual tCP_FinanciamientoCargos tCP_FinanciamientoCargos { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_MediosPagos tGN_MediosPagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_TemporalAprobacionPagos> tCP_TemporalAprobacionPagos { get; set; }
    }
}
