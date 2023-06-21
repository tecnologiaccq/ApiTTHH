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
    
    public partial class tFT_Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tFT_Productos()
        {
            this.tCC_CargosDet = new HashSet<tCC_CargosDet>();
            this.tCEC_EventosCursosXDictar = new HashSet<tCEC_EventosCursosXDictar>();
            this.tCEC_PoliticasPromocion = new HashSet<tCEC_PoliticasPromocion>();
            this.tFT_FacturaDet = new HashSet<tFT_FacturaDet>();
            this.tFT_ProductosListaPrecios = new HashSet<tFT_ProductosListaPrecios>();
            this.tPR_DetalleFormulacionMes = new HashSet<tPR_DetalleFormulacionMes>();
        }
    
        public int IdProducto { get; set; }
        public int IdEmpresa { get; set; }
        public string CodigoProductoPrincipal { get; set; }
        public string CodigoProductoAuxiliar { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdTipoImpuestoIva { get; set; }
        public Nullable<int> IdTipoImpuestoIce { get; set; }
        public Nullable<int> IdTipoImpuestoIrbpnr { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<int> IdCategoriaProducto1 { get; set; }
        public Nullable<int> IdCategoriaProducto2 { get; set; }
        public Nullable<int> IdCategoriaProducto3 { get; set; }
        public Nullable<int> IdCategoriaJerarquica1_2 { get; set; }
        public string Notas { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<bool> VisibleAplicacion { get; set; }
        public Nullable<int> IdPlanCuentasEmpresaDebito { get; set; }
        public Nullable<int> IdPlanCuentasEmpresaCredito { get; set; }
        public Nullable<int> IdTipoDocumentoCCQ { get; set; }
        public Nullable<bool> EsFacturable { get; set; }
        public Nullable<bool> DescripcionModificable { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public bool PrecioModificable { get; set; }
        public Nullable<short> cod_categoria { get; set; }
        public Nullable<short> cod_servicio { get; set; }
        public string CodigoPrincipalDescripcion { get; set; }
        public Nullable<bool> AplicaEspectaculo { get; set; }
        public Nullable<int> SecuencialEspectaculo { get; set; }
        public string DescripcionLocalidadEspectaculo { get; set; }
        public Nullable<int> SecuencialEspectaculoCortesia { get; set; }
        public Nullable<int> CantidadAccesosPermitidos { get; set; }
        public string NombreEspectaculo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosDet> tCC_CargosDet { get; set; }
        public virtual tCC_TiposDocumentosCCQ tCC_TiposDocumentosCCQ { get; set; }
        public virtual tCC_TiposDocumentosCCQ tCC_TiposDocumentosCCQ1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_EventosCursosXDictar> tCEC_EventosCursosXDictar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_PoliticasPromocion> tCEC_PoliticasPromocion { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa2 { get; set; }
        public virtual tCT_CategoriaJerarquica1_2 tCT_CategoriaJerarquica1_2 { get; set; }
        public virtual tCT_CategoriaProducto1 tCT_CategoriaProducto1 { get; set; }
        public virtual tCT_CategoriaProducto2 tCT_CategoriaProducto2 { get; set; }
        public virtual tCT_CategoriaProducto3 tCT_CategoriaProducto3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFT_FacturaDet> tFT_FacturaDet { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos1 { get; set; }
        public virtual tGN_TiposImpuestosIva tGN_TiposImpuestosIva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFT_ProductosListaPrecios> tFT_ProductosListaPrecios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_DetalleFormulacionMes> tPR_DetalleFormulacionMes { get; set; }
    }
}