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
    
    public partial class tPR_DetalleFormulacionMes
    {
        public int IdDetalleFormulacionMes { get; set; }
        public int IdMaestroFormulacion { get; set; }
        public int IdPlanCuentaEmpresa { get; set; }
        public int IdCentroCosto { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public int IdEmpresa { get; set; }
        public int Mes { get; set; }
        public decimal Valor { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tFT_Productos tFT_Productos { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tPR_MaestroFormulacion tPR_MaestroFormulacion { get; set; }
    }
}
