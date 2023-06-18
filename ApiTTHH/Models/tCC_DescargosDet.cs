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
    
    public partial class tCC_DescargosDet
    {
        public int IdDescargoDet { get; set; }
        public int IdDescargoCab { get; set; }
        public string CodigoPrincipal { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<int> IdTipoImpuestoIva { get; set; }
        public Nullable<decimal> ValorIva { get; set; }
        public Nullable<int> IdTipoImpuestoIce { get; set; }
        public Nullable<decimal> ValorIce { get; set; }
        public Nullable<int> IdTipoImpuestoIrbpnr { get; set; }
        public Nullable<decimal> ValorIrbpnr { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> IdPlanCuentasEmpresaDebito { get; set; }
        public Nullable<int> IdPlanCuentasEmpresaCredito { get; set; }
        public Nullable<int> IdCentroCosto { get; set; }
        public Nullable<int> IdObjetoConsumo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public Nullable<int> IdCargoCab { get; set; }
        public Nullable<int> idnotacredito { get; set; }
        public Nullable<int> IdCuota { get; set; }
    
        public virtual tCC_CargosCab tCC_CargosCab { get; set; }
        public virtual tCC_DescargosCab tCC_DescargosCab { get; set; }
        public virtual tGS_Cuotas_V2 tGS_Cuotas_V2 { get; set; }
        public virtual tCG_ObjetosConsumos tCG_ObjetosConsumos { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos1 { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos2 { get; set; }
    }
}
