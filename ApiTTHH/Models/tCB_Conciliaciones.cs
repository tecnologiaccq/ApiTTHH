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
    
    public partial class tCB_Conciliaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCB_Conciliaciones()
        {
            this.tCB_Cruces = new HashSet<tCB_Cruces>();
            this.tCB_CrucesBancarios = new HashSet<tCB_CrucesBancarios>();
            this.tCB_CrucesContables = new HashSet<tCB_CrucesContables>();
            this.tCB_MovimientosBancarios = new HashSet<tCB_MovimientosBancarios>();
            this.tCB_MovimientosContables = new HashSet<tCB_MovimientosContables>();
        }
    
        public int IdConciliacion { get; set; }
        public Nullable<int> IdCuentaBancaria { get; set; }
        public Nullable<System.DateTime> FechaDesde { get; set; }
        public Nullable<System.DateTime> FechaHasta { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> SaldoBanco { get; set; }
        public Nullable<decimal> ChequesNRB { get; set; }
        public Nullable<decimal> NCyDEPNRB { get; set; }
        public Nullable<decimal> NDNRB { get; set; }
        public Nullable<decimal> NDNRL { get; set; }
        public Nullable<decimal> NCyDEPNRL { get; set; }
        public Nullable<decimal> ConsumoNRL { get; set; }
        public Nullable<decimal> Ajustes { get; set; }
        public Nullable<decimal> SaldoConciliado { get; set; }
        public Nullable<decimal> SaldoContable { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<bool> Cerrada { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<decimal> ChequesNRL { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_Cruces> tCB_Cruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_CrucesBancarios> tCB_CrucesBancarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_CrucesContables> tCB_CrucesContables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_MovimientosBancarios> tCB_MovimientosBancarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_MovimientosContables> tCB_MovimientosContables { get; set; }
    }
}
