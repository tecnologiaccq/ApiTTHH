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
    
    public partial class tCP_DescargosCab
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCP_DescargosCab()
        {
            this.tCP_AsientosXDescargos = new HashSet<tCP_AsientosXDescargos>();
            this.tCP_CruceDocumentos = new HashSet<tCP_CruceDocumentos>();
            this.tCP_CuentasContablesDescargos = new HashSet<tCP_CuentasContablesDescargos>();
            this.tCP_DescargosDet = new HashSet<tCP_DescargosDet>();
            this.tCP_TemporalCruceDoc = new HashSet<tCP_TemporalCruceDoc>();
        }
    
        public int IdDescargoCab { get; set; }
        public Nullable<int> IdAsientoContableCab { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPeriodoContable { get; set; }
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
        public string Motivo { get; set; }
        public Nullable<int> IdTipoDocumentoModificado { get; set; }
        public string NumeroDocumentoModificado { get; set; }
        public Nullable<System.DateTime> FechaEmisionDocSustento { get; set; }
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
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string InformacionAdicional { get; set; }
        public Nullable<int> IdEstadoDocumento { get; set; }
        public Nullable<int> IdGrupoComprobante { get; set; }
        public Nullable<long> NumeroComprobante { get; set; }
        public string NombreArchivo { get; set; }
        public Nullable<int> NumeroOrden { get; set; }
        public string ReferenciaBanco { get; set; }
        public string Concepto { get; set; }
        public Nullable<int> IdBancoCCQ { get; set; }
        public Nullable<int> IdTarjetaCredito { get; set; }
        public Nullable<bool> EsPagoContable { get; set; }
        public Nullable<bool> EsManual { get; set; }
        public Nullable<int> IdEstadoDOCE { get; set; }
        public string MensajeDOCE { get; set; }
        public Nullable<System.DateTime> FechaEnvioDOCE { get; set; }
        public string NumeroCaso { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string BeneficiarioPagoContable { get; set; }
        public string IdentificacionPagoContable { get; set; }
        public Nullable<int> idretenciones { get; set; }
        public bool EsDocumentoCam { get; set; }
        public Nullable<int> IdPlanCuentaEmpresaCxCCam { get; set; }
        public Nullable<int> IdPlanCuentaEmpresaSaldo { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<System.DateTime> FechaComprobante { get; set; }
    
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tCG_GrupoComprobantes tCG_GrupoComprobantes { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXDescargos> tCP_AsientosXDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CruceDocumentos> tCP_CruceDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CuentasContablesDescargos> tCP_CuentasContablesDescargos { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
        public virtual tNM_Empleados tNM_Empleados { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tCT_EstadoDocumentoSRI tCT_EstadoDocumentoSRI { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tGN_TarjetaCredito tGN_TarjetaCredito { get; set; }
        public virtual tGN_TiposDocumentos tGN_TiposDocumentos { get; set; }
        public virtual tGN_TiposDocumentos tGN_TiposDocumentos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosDet> tCP_DescargosDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_TemporalCruceDoc> tCP_TemporalCruceDoc { get; set; }
    }
}
