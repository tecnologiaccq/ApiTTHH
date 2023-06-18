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
    
    public partial class tCG_IntAsientosContableDet
    {
        public int IdAsientoContableDet { get; set; }
        public int IdAsientoContableCab { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdObjetoConsumo { get; set; }
        public Nullable<int> IdPlanCuentasEmpresa { get; set; }
        public Nullable<decimal> ValorDebito { get; set; }
        public Nullable<decimal> ValorCredito { get; set; }
        public Nullable<bool> EstadoPaso { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string NumeroReferencia { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public string DescripcionReferencia { get; set; }
        public Nullable<decimal> ValorRetorno { get; set; }
        public Nullable<int> IdCodigoConciliacion { get; set; }
        public Nullable<int> IdCentroCostos { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdConcepto { get; set; }
    
        public virtual tCG_IntAsientosContableCab tCG_IntAsientosContableCab { get; set; }
        public virtual tCG_ObjetosConsumos tCG_ObjetosConsumos { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
    }
}
