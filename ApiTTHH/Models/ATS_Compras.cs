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
    
    public partial class ATS_Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ATS_Compras()
        {
            this.tCP_CargosCabReembolso = new HashSet<tCP_CargosCabReembolso>();
        }
    
        public int IdAtsCompras { get; set; }
        public Nullable<int> IdCargoCab { get; set; }
        public Nullable<int> IdAsientoContableCab { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPeriodoContable { get; set; }
        public int IdProveedor { get; set; }
        public int IdGrupoComprobante { get; set; }
        public Nullable<int> IdSustentoSRI { get; set; }
        public Nullable<long> NumeroComprobante { get; set; }
        public string Ambiente { get; set; }
        public string ClaveAcceso { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string DireccionEstablecimiento { get; set; }
        public string DireccionMatriz { get; set; }
        public string DireccionSucursal { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string Secuencial { get; set; }
        public string NumeroDocumento { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<System.DateTime> FechaAutorizacion { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public string Moneda { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string ObligadoContabilidad { get; set; }
        public string TipoEmision { get; set; }
        public Nullable<decimal> Propina { get; set; }
        public Nullable<decimal> SubtotalIva { get; set; }
        public Nullable<decimal> Subtotal0 { get; set; }
        public Nullable<decimal> SubtotalNoObjetoImpuesto { get; set; }
        public Nullable<decimal> TotalExcentoIva { get; set; }
        public Nullable<decimal> SubtotalSinImpuesto { get; set; }
        public Nullable<decimal> TotalDescuento { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> Ice { get; set; }
        public Nullable<decimal> Irbpnr { get; set; }
        public Nullable<int> IdRetencionRentaPropina { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string InformacionAdicional { get; set; }
        public Nullable<int> IdEstadoDocumento { get; set; }
        public Nullable<bool> EsManual { get; set; }
        public Nullable<bool> EstadoFinanciamiento { get; set; }
        public Nullable<bool> EstaEnAprobacion { get; set; }
        public Nullable<bool> GeneraRetencion { get; set; }
        public string Glosa { get; set; }
        public string NumeroCaso { get; set; }
        public Nullable<bool> NotaCreditoGenerada { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> idretenciones { get; set; }
        public Nullable<int> IdPlanCuentasEmpresaCXP { get; set; }
        public Nullable<bool> EsDocumentoCam { get; set; }
        public Nullable<bool> AprobadoParaPago { get; set; }
        public Nullable<decimal> ValorRetencionRentaPropina { get; set; }
        public string codSustento { get; set; }
        public string tpIdProv { get; set; }
        public string idProv { get; set; }
        public string tipoComprobante { get; set; }
        public string parteRel { get; set; }
        public Nullable<decimal> valRetBien10 { get; set; }
        public Nullable<decimal> valRetServ20 { get; set; }
        public Nullable<decimal> valorRetBienes { get; set; }
        public Nullable<decimal> valRetServ50 { get; set; }
        public Nullable<decimal> valorRetServicios { get; set; }
        public Nullable<decimal> valRetServ100 { get; set; }
        public Nullable<decimal> totbasesImpReemb { get; set; }
        public string estabRetencion1 { get; set; }
        public string ptoEmiRetencion1 { get; set; }
        public string secRetencion1 { get; set; }
        public string autRetencion1 { get; set; }
        public Nullable<System.DateTime> fechaEmiRet1 { get; set; }
        public Nullable<bool> ReportarAlArchivoXml { get; set; }
        public Nullable<bool> EstaGeneradoArchivoXML { get; set; }
        public Nullable<System.DateTime> FechaCreacionArchivoXML { get; set; }
        public string UsuarioCreacionArchivoXML { get; set; }
        public Nullable<int> IVA1_PorcentajeRetencion { get; set; }
        public string IVA1_CodigoRetencion { get; set; }
        public Nullable<decimal> IVA1_BaseImponible { get; set; }
        public Nullable<decimal> IVA1_ValorRetenido { get; set; }
        public Nullable<int> IVA2_PorcentajeRetencion { get; set; }
        public string IVA2_CodigoRetencion { get; set; }
        public Nullable<decimal> IVA2_BaseImponible { get; set; }
        public Nullable<decimal> IVA2_ValorRetenido { get; set; }
        public Nullable<int> IVA3_PorcentajeRetencion { get; set; }
        public string IVA3_CodigoRetencion { get; set; }
        public Nullable<decimal> IVA3_BaseImponible { get; set; }
        public Nullable<decimal> IVA3_ValorRetenido { get; set; }
        public Nullable<decimal> RENTA1_PorcentajeRetencion { get; set; }
        public string RENTA1_CodigoRetencion { get; set; }
        public Nullable<decimal> RENTA1_BaseImponible { get; set; }
        public Nullable<decimal> RENTA1_ValorRetenido { get; set; }
        public Nullable<decimal> RENTA2_PorcentajeRetencion { get; set; }
        public string RENTA2_CodigoRetencion { get; set; }
        public Nullable<decimal> RENTA2_BaseImponible { get; set; }
        public Nullable<decimal> RENTA2_ValorRetenido { get; set; }
        public Nullable<decimal> RENTA3_PorcentajeRetencion { get; set; }
        public string RENTA3_CodigoRetencion { get; set; }
        public Nullable<decimal> RENTA3_BaseImponible { get; set; }
        public Nullable<decimal> RENTA3_ValorRetenido { get; set; }
        public string NumeroDocumentoModificado { get; set; }
        public Nullable<System.DateTime> FechaEmisionDocumentoModificado { get; set; }
        public string NumeroAutorizacionDocumentoModificado { get; set; }
        public string CodigoDocumentoModificado { get; set; }
        public bool EsCargo { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tCT_EstadoDocumentoSRI tCT_EstadoDocumentoSRI { get; set; }
        public virtual tCG_GrupoComprobantes tCG_GrupoComprobantes { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tCP_SustentoSRI tCP_SustentoSRI { get; set; }
        public virtual tGN_TiposDocumentos tGN_TiposDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCabReembolso> tCP_CargosCabReembolso { get; set; }
    }
}
