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
    
    public partial class tCP_CruceDocumentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCP_CruceDocumentos()
        {
            this.tCP_AsientosXCruces = new HashSet<tCP_AsientosXCruces>();
        }
    
        public int IdCruceDocumentos { get; set; }
        public int IdCargoCab { get; set; }
        public int IdDescargoCab { get; set; }
        public Nullable<int> IdAsientoContableCabAplicacion { get; set; }
        public System.DateTime FechaAplicacion { get; set; }
        public decimal Valor { get; set; }
        public Nullable<decimal> SaldoActualCargo { get; set; }
        public Nullable<decimal> SaldoFinalCargo { get; set; }
        public Nullable<decimal> SaldoActualDescargo { get; set; }
        public Nullable<decimal> SaldoFinalDescargo { get; set; }
        public Nullable<int> IdEstadoCruceDocumento { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdPlanCuentaEmpresaSaldo { get; set; }
        public Nullable<bool> EsManual { get; set; }
        public Nullable<int> IdAsientoContableCabAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab1 { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXCruces> tCP_AsientosXCruces { get; set; }
        public virtual tCP_CargosCab tCP_CargosCab { get; set; }
        public virtual tCP_DescargosCab tCP_DescargosCab { get; set; }
        public virtual tCT_EstadoCruceDocumento tCT_EstadoCruceDocumento { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
    }
}
