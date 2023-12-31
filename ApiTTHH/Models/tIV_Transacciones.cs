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
    
    public partial class tIV_Transacciones
    {
        public int IdTransaccion { get; set; }
        public int IdEmpresa { get; set; }
        public int IdBodega { get; set; }
        public int IdTipoTransaccion { get; set; }
        public Nullable<int> NroDocumento { get; set; }
        public int IdArticulo { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public Nullable<int> IdMaestroFisico { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Valor { get; set; }
        public System.DateTime FechaProceso { get; set; }
        public Nullable<int> IdCuentaDb { get; set; }
        public Nullable<int> IdCuentaCr { get; set; }
        public int Situacion { get; set; }
        public bool NoContabilizar { get; set; }
        public Nullable<int> IdMaestroSolicitudes { get; set; }
        public Nullable<int> IdMaestroRecepciones { get; set; }
        public Nullable<int> IdPeriodoContable { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tIV_Articulos tIV_Articulos { get; set; }
        public virtual tIV_Bodegas tIV_Bodegas { get; set; }
        public virtual tIV_MaestroFisico tIV_MaestroFisico { get; set; }
        public virtual tIV_MaestroRecepciones tIV_MaestroRecepciones { get; set; }
        public virtual tIV_MaestroSolicitudes tIV_MaestroSolicitudes { get; set; }
        public virtual tIV_TiposTransacciones tIV_TiposTransacciones { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
    }
}
