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
    
    public partial class tNM_NominaDefinitiva
    {
        public long IdNominaDefinitiva { get; set; }
        public Nullable<int> IdCalendarioNomina { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<decimal> Unidades { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<int> IdCuentaDb { get; set; }
        public Nullable<int> IdCuentaCr { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public bool Cancelado { get; set; }
        public Nullable<int> NumeroCuotas { get; set; }
        public Nullable<int> CuotasPagadas { get; set; }
        public Nullable<bool> AplicadoFactorProporcional { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> ValorMes { get; set; }
        public Nullable<int> IdConceptoMes { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tNM_CalendarioNominas tNM_CalendarioNominas { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_Conceptos tNM_Conceptos { get; set; }
        public virtual tNM_Departamentos tNM_Departamentos { get; set; }
    }
}
