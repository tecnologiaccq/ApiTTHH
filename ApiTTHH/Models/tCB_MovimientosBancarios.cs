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
    
    public partial class tCB_MovimientosBancarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCB_MovimientosBancarios()
        {
            this.tCB_Cruces = new HashSet<tCB_Cruces>();
            this.tCB_CrucesBancarios = new HashSet<tCB_CrucesBancarios>();
            this.tCB_CrucesBancarios1 = new HashSet<tCB_CrucesBancarios>();
        }
    
        public int IdMovimientoBancario { get; set; }
        public Nullable<int> IdCuentaBancaria { get; set; }
        public Nullable<System.DateTime> FechaContable { get; set; }
        public string CodigoBanco { get; set; }
        public Nullable<int> CodigoInterno { get; set; }
        public string Referencia { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public string Concepto { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<int> IdConciliacion { get; set; }
        public Nullable<int> IdOriginal { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdMovimientoBancarioOriginal { get; set; }
    
        public virtual tCB_CodigosConciliacion tCB_CodigosConciliacion { get; set; }
        public virtual tCB_Conciliaciones tCB_Conciliaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_Cruces> tCB_Cruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_CrucesBancarios> tCB_CrucesBancarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_CrucesBancarios> tCB_CrucesBancarios1 { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
    }
}