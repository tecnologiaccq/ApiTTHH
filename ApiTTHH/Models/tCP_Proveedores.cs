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
    
    public partial class tCP_Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCP_Proveedores()
        {
            this.ATS_Compras = new HashSet<ATS_Compras>();
            this.tAF_Incorporaciones = new HashSet<tAF_Incorporaciones>();
            this.tAF_MaestroActivos = new HashSet<tAF_MaestroActivos>();
            this.tAF_Movimientos = new HashSet<tAF_Movimientos>();
            this.tCP_AnexosProveedor = new HashSet<tCP_AnexosProveedor>();
            this.tCP_AprobacionDePagos = new HashSet<tCP_AprobacionDePagos>();
            this.tCP_ArchivoBancoAnticipado = new HashSet<tCP_ArchivoBancoAnticipado>();
            this.tCP_CargosCab = new HashSet<tCP_CargosCab>();
            this.tCP_ConfirmacionBancosAuxiliar = new HashSet<tCP_ConfirmacionBancosAuxiliar>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tCP_FallosDebitoBancos = new HashSet<tCP_FallosDebitoBancos>();
            this.tCP_TemporalCruceDoc = new HashSet<tCP_TemporalCruceDoc>();
            this.tIV_Transacciones = new HashSet<tIV_Transacciones>();
            this.tIV_MaestroRecepciones = new HashSet<tIV_MaestroRecepciones>();
        }
    
        public int IdProveedor { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdSocio { get; set; }
        public Nullable<int> IdPlanCuentaEmpresa { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public Nullable<int> IdRetencionRenta { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> IdTipoContribuyente { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public Nullable<int> IdTipoPersona { get; set; }
        public Nullable<int> IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public Nullable<int> IdPais { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public Nullable<int> DiasVencimiento { get; set; }
        public Nullable<System.DateTime> FechaCaducidad { get; set; }
        public string Autorizacion { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string SecuencialDesde { get; set; }
        public string SecuencialHasta { get; set; }
        public Nullable<int> IdMedioPago { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdTipoCuentaBanco { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> IdBancoCCQ { get; set; }
        public string Observaciones { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string MedioPagoNombresApellidosTitular { get; set; }
        public Nullable<int> MedioPagoIdTipoIdentificacionTitular { get; set; }
        public string MedioPagoNumeroIdentificacionTitular { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATS_Compras> ATS_Compras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Incorporaciones> tAF_Incorporaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_MaestroActivos> tAF_MaestroActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Movimientos> tAF_Movimientos { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AnexosProveedor> tCP_AnexosProveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AprobacionDePagos> tCP_AprobacionDePagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_ArchivoBancoAnticipado> tCP_ArchivoBancoAnticipado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCab> tCP_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_ConfirmacionBancosAuxiliar> tCP_ConfirmacionBancosAuxiliar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_FallosDebitoBancos> tCP_FallosDebitoBancos { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_MediosPagos tGN_MediosPagos { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion { get; set; }
        public virtual tCP_RetencionesRenta tCP_RetencionesRenta { get; set; }
        public virtual tCP_TiposContribuyentes tCP_TiposContribuyentes { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
        public virtual tGN_Paises tGN_Paises { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion1 { get; set; }
        public virtual tGN_TiposPersonas tGN_TiposPersonas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_TemporalCruceDoc> tCP_TemporalCruceDoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Transacciones> tIV_Transacciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_MaestroRecepciones> tIV_MaestroRecepciones { get; set; }
    }
}
