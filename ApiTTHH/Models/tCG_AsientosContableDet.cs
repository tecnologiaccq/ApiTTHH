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
    
    public partial class tCG_AsientosContableDet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCG_AsientosContableDet()
        {
            this.tCB_MovimientosContables = new HashSet<tCB_MovimientosContables>();
        }
    
        public int IdAsientoContableDet { get; set; }
        public int IdAsientoContableCab { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdObjetoConsumo { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public int IdPlanCuentasEmpresa { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public decimal ValorDebito { get; set; }
        public decimal ValorCredito { get; set; }
        public string NumeroReferencia { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public string DescripcionReferencia { get; set; }
        public Nullable<decimal> ValorRetorno { get; set; }
        public Nullable<int> IdCodigoConciliacion { get; set; }
        public string NumeroCaso { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdConcepto { get; set; }
    
        public virtual tCB_CodigosConciliacion tCB_CodigosConciliacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_MovimientosContables> tCB_MovimientosContables { get; set; }
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tCG_ObjetosConsumos tCG_ObjetosConsumos { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tNM_Empleados tNM_Empleados { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tNM_Conceptos tNM_Conceptos { get; set; }
    }
}
