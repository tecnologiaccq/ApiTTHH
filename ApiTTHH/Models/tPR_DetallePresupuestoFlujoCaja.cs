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
    
    public partial class tPR_DetallePresupuestoFlujoCaja
    {
        public int IdDetallePresupuesto { get; set; }
        public int IdMaestroPresupuesto { get; set; }
        public Nullable<int> IdPlanCuentasEmpresa { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public Nullable<decimal> Ene { get; set; }
        public Nullable<decimal> RealEne { get; set; }
        public Nullable<decimal> CumplimientoEne { get; set; }
        public Nullable<decimal> Feb { get; set; }
        public Nullable<decimal> RealFeb { get; set; }
        public Nullable<decimal> CumplimientoFeb { get; set; }
        public Nullable<decimal> Mar { get; set; }
        public Nullable<decimal> RealMar { get; set; }
        public Nullable<decimal> CumplimientoMar { get; set; }
        public Nullable<decimal> Abr { get; set; }
        public Nullable<decimal> RealAbr { get; set; }
        public Nullable<decimal> CumplimientoAbr { get; set; }
        public Nullable<decimal> May { get; set; }
        public Nullable<decimal> RealMay { get; set; }
        public Nullable<decimal> CumplimientoMay { get; set; }
        public Nullable<decimal> Jun { get; set; }
        public Nullable<decimal> RealJun { get; set; }
        public Nullable<decimal> CumplimientoJun { get; set; }
        public Nullable<decimal> Jul { get; set; }
        public Nullable<decimal> RealJul { get; set; }
        public Nullable<decimal> CumplimientoJul { get; set; }
        public Nullable<decimal> Ago { get; set; }
        public Nullable<decimal> RealAgo { get; set; }
        public Nullable<decimal> CumplimientoAgo { get; set; }
        public Nullable<decimal> Sep { get; set; }
        public Nullable<decimal> RealSep { get; set; }
        public Nullable<decimal> CumplimientoSep { get; set; }
        public Nullable<decimal> Oct { get; set; }
        public Nullable<decimal> RealOct { get; set; }
        public Nullable<decimal> CumplimientoOct { get; set; }
        public Nullable<decimal> Nov { get; set; }
        public Nullable<decimal> RealNov { get; set; }
        public Nullable<decimal> CumplimientoNov { get; set; }
        public Nullable<decimal> Dic { get; set; }
        public Nullable<decimal> RealDic { get; set; }
        public Nullable<decimal> CumplimientoDic { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> RealTotal { get; set; }
        public Nullable<decimal> CumplimientoTotal { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tPR_MaestroPresupuestoFlujoCaja tPR_MaestroPresupuestoFlujoCaja { get; set; }
    }
}
