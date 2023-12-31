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
    
    public partial class tCG_SaldoMayor
    {
        public int IdSaldoMayor { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPlanCuentasEmpresa { get; set; }
        public int IdPeriodoContable { get; set; }
        public decimal SaldoInicialMes { get; set; }
        public decimal DebitoMes { get; set; }
        public decimal CreditoMes { get; set; }
        public Nullable<decimal> SaldoFinalMes { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
    }
}
