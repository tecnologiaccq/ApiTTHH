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
    
    public partial class tCP_CuentasContablesDescargos
    {
        public int IdCuentasContablesDescargos { get; set; }
        public Nullable<int> IdPlanCuentaEmpresa { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public int IdDescargoCab { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public Nullable<int> IdObjetoConsumo { get; set; }
    
        public virtual tCG_ObjetosConsumos tCG_ObjetosConsumos { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tCP_DescargosCab tCP_DescargosCab { get; set; }
        public virtual tNM_Empleados tNM_Empleados { get; set; }
    }
}
