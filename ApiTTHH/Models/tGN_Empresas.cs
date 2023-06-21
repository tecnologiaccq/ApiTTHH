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
    
    public partial class tGN_Empresas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_Empresas()
        {
            this.ATS_Compras = new HashSet<ATS_Compras>();
            this.mAF_Depreciacion = new HashSet<mAF_Depreciacion>();
            this.mAF_MaestroActivos = new HashSet<mAF_MaestroActivos>();
            this.PermissionPolicyUser = new HashSet<PermissionPolicyUser>();
            this.SecuritySystemUser = new HashSet<SecuritySystemUser>();
            this.SecuritySystemUserCustom = new HashSet<SecuritySystemUserCustom>();
            this.tAF_AsientosContables = new HashSet<tAF_AsientosContables>();
            this.tAF_Depreciacion = new HashSet<tAF_Depreciacion>();
            this.tAF_Desincorporaciones = new HashSet<tAF_Desincorporaciones>();
            this.tAF_Incorporaciones = new HashSet<tAF_Incorporaciones>();
            this.tAF_MaestroActivos = new HashSet<tAF_MaestroActivos>();
            this.tAF_TiposActivos = new HashSet<tAF_TiposActivos>();
            this.tCB_Conciliaciones = new HashSet<tCB_Conciliaciones>();
            this.tCC_AsientosXCargos = new HashSet<tCC_AsientosXCargos>();
            this.tCC_AsientosXCruces = new HashSet<tCC_AsientosXCruces>();
            this.tCC_AsientosXDescargos = new HashSet<tCC_AsientosXDescargos>();
            this.tCC_AsientosXDescargosDevolucionesParcialesCAM = new HashSet<tCC_AsientosXDescargosDevolucionesParcialesCAM>();
            this.tCC_Caja = new HashSet<tCC_Caja>();
            this.tCC_CajaIngresoChequeGarantia = new HashSet<tCC_CajaIngresoChequeGarantia>();
            this.tCC_CajaSolicitudesEgresos = new HashSet<tCC_CajaSolicitudesEgresos>();
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_CargosCabExtension = new HashSet<tCC_CargosCabExtension>();
            this.tCC_Clientes = new HashSet<tCC_Clientes>();
            this.tCC_Cobradores = new HashSet<tCC_Cobradores>();
            this.tCC_CruceDocumentos = new HashSet<tCC_CruceDocumentos>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCC_DescargosCabExtension = new HashSet<tCC_DescargosCabExtension>();
            this.tCC_DescargosCabRelacionPagoTemp = new HashSet<tCC_DescargosCabRelacionPagoTemp>();
            this.tCC_HistorialAperturaCaja = new HashSet<tCC_HistorialAperturaCaja>();
            this.tCC_HistorialCierreCaja = new HashSet<tCC_HistorialCierreCaja>();
            this.tCC_RelacionPago = new HashSet<tCC_RelacionPago>();
            this.tCC_TemporalCruceDoc = new HashSet<tCC_TemporalCruceDoc>();
            this.tCC_TempTransaccionesComerciales = new HashSet<tCC_TempTransaccionesComerciales>();
            this.tCC_TiposCobros = new HashSet<tCC_TiposCobros>();
            this.tCC_TiposDocumentosCCQ = new HashSet<tCC_TiposDocumentosCCQ>();
            this.tCC_Vendedores = new HashSet<tCC_Vendedores>();
            this.tCEC_EventosCursos = new HashSet<tCEC_EventosCursos>();
            this.tCEC_EventosCursosXDictar = new HashSet<tCEC_EventosCursosXDictar>();
            this.tCG_AsientosContableCab = new HashSet<tCG_AsientosContableCab>();
            this.tCG_AsientosContableDet = new HashSet<tCG_AsientosContableDet>();
            this.tCG_GrupoComprobantes = new HashSet<tCG_GrupoComprobantes>();
            this.tCG_IntAsientosContableCab = new HashSet<tCG_IntAsientosContableCab>();
            this.tCG_ObjetosConsumos = new HashSet<tCG_ObjetosConsumos>();
            this.tCG_PeriodoContable = new HashSet<tCG_PeriodoContable>();
            this.tCG_PlanCuentasEmpresa = new HashSet<tCG_PlanCuentasEmpresa>();
            this.tCG_SaldoMayor = new HashSet<tCG_SaldoMayor>();
            this.tCG_SecuencialesComprobantes = new HashSet<tCG_SecuencialesComprobantes>();
            this.tCP_AprobacionDePagos = new HashSet<tCP_AprobacionDePagos>();
            this.tCP_ArchivoBancoAnticipado = new HashSet<tCP_ArchivoBancoAnticipado>();
            this.tCP_AsientosXCargos = new HashSet<tCP_AsientosXCargos>();
            this.tCP_AsientosXCruces = new HashSet<tCP_AsientosXCruces>();
            this.tCP_AsientosXDescargos = new HashSet<tCP_AsientosXDescargos>();
            this.tCP_CargosCab = new HashSet<tCP_CargosCab>();
            this.tCP_CruceDocumentos = new HashSet<tCP_CruceDocumentos>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tCP_FinanciamientoCargos = new HashSet<tCP_FinanciamientoCargos>();
            this.tCP_Proveedores = new HashSet<tCP_Proveedores>();
            this.tCT_ListaPrecios = new HashSet<tCT_ListaPrecios>();
            this.tFT_FacturaCab = new HashSet<tFT_FacturaCab>();
            this.tFT_Productos = new HashSet<tFT_Productos>();
            this.tGN_BancosCCQ = new HashSet<tGN_BancosCCQ>();
            this.tGN_CentrosCostos = new HashSet<tGN_CentrosCostos>();
            this.tGN_Establecimientos = new HashSet<tGN_Establecimientos>();
            this.tGN_InformacionesAdicionalesDocumentos = new HashSet<tGN_InformacionesAdicionalesDocumentos>();
            this.tGN_Parametros = new HashSet<tGN_Parametros>();
            this.tGN_ParametrosGenerales = new HashSet<tGN_ParametrosGenerales>();
            this.tGN_TarjetaCredito = new HashSet<tGN_TarjetaCredito>();
            this.tGN_TiposDocumentos = new HashSet<tGN_TiposDocumentos>();
            this.tGS_Socios = new HashSet<tGS_Socios>();
            this.tGS_SociosPreregistro = new HashSet<tGS_SociosPreregistro>();
            this.tIV_Ajustes = new HashSet<tIV_Ajustes>();
            this.tIV_Bodegas = new HashSet<tIV_Bodegas>();
            this.tIV_Articulos = new HashSet<tIV_Articulos>();
            this.tIV_Contabilizacion = new HashSet<tIV_Contabilizacion>();
            this.tIV_MaestroFisico = new HashSet<tIV_MaestroFisico>();
            this.tIV_MaestroSolicitudes = new HashSet<tIV_MaestroSolicitudes>();
            this.tIV_Saldos = new HashSet<tIV_Saldos>();
            this.tIV_Transacciones = new HashSet<tIV_Transacciones>();
            this.tNM_Areas = new HashSet<tNM_Areas>();
            this.tNM_BasesCalculadas = new HashSet<tNM_BasesCalculadas>();
            this.tNM_CalendarioNominas = new HashSet<tNM_CalendarioNominas>();
            this.tNM_Colaboradores = new HashSet<tNM_Colaboradores>();
            this.tNM_Conceptos = new HashSet<tNM_Conceptos>();
            this.tNM_Departamentos = new HashSet<tNM_Departamentos>();
            this.tNM_Empleados = new HashSet<tNM_Empleados>();
            this.tNM_FormularioGP = new HashSet<tNM_FormularioGP>();
            this.tPR_DetalleFormulacionMes = new HashSet<tPR_DetalleFormulacionMes>();
            this.tPR_MaestroFormulacion = new HashSet<tPR_MaestroFormulacion>();
            this.tPR_MaestroFormulacionFlujoCaja = new HashSet<tPR_MaestroFormulacionFlujoCaja>();
            this.tPR_MaestroPresupuesto = new HashSet<tPR_MaestroPresupuesto>();
            this.tPR_MaestroPresupuestoFlujoCaja = new HashSet<tPR_MaestroPresupuestoFlujoCaja>();
        }
    
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> TipoIdRepresentanteLegal { get; set; }
        public string IdRepresentanteLegal { get; set; }
        public string NombreRepresentanteLegal { get; set; }
        public string IdFiscal { get; set; }
        public string Telefono { get; set; }
        public Nullable<int> TipoIdContador { get; set; }
        public string IdContador { get; set; }
        public Nullable<bool> ProduccionSRI { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string Nombre { get; set; }
        public string RepresentanteLegal { get; set; }
        public string RUC { get; set; }
        public string NombreContador { get; set; }
        public Nullable<int> IdTipoEmpresa { get; set; }
        public Nullable<int> IdSocioDoce { get; set; }
        public Nullable<int> IdPeriodoUltimaGeneracionCuotas { get; set; }
        public Nullable<bool> EstaPausadoServiciosDOCE { get; set; }
        public string Firma1 { get; set; }
        public string Firma2 { get; set; }
        public Nullable<bool> MenuWeb { get; set; }
        public string UrlLogo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATS_Compras> ATS_Compras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAF_Depreciacion> mAF_Depreciacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAF_MaestroActivos> mAF_MaestroActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyUser> PermissionPolicyUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecuritySystemUser> SecuritySystemUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecuritySystemUserCustom> SecuritySystemUserCustom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_AsientosContables> tAF_AsientosContables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Depreciacion> tAF_Depreciacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Desincorporaciones> tAF_Desincorporaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Incorporaciones> tAF_Incorporaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_MaestroActivos> tAF_MaestroActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_TiposActivos> tAF_TiposActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_Conciliaciones> tCB_Conciliaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXCargos> tCC_AsientosXCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXCruces> tCC_AsientosXCruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXDescargos> tCC_AsientosXDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXDescargosDevolucionesParcialesCAM> tCC_AsientosXDescargosDevolucionesParcialesCAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Caja> tCC_Caja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoChequeGarantia> tCC_CajaIngresoChequeGarantia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaSolicitudesEgresos> tCC_CajaSolicitudesEgresos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCabExtension> tCC_CargosCabExtension { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Cobradores> tCC_Cobradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CruceDocumentos> tCC_CruceDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCabExtension> tCC_DescargosCabExtension { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCabRelacionPagoTemp> tCC_DescargosCabRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_HistorialAperturaCaja> tCC_HistorialAperturaCaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_HistorialCierreCaja> tCC_HistorialCierreCaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_RelacionPago> tCC_RelacionPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TemporalCruceDoc> tCC_TemporalCruceDoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TempTransaccionesComerciales> tCC_TempTransaccionesComerciales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TiposCobros> tCC_TiposCobros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TiposDocumentosCCQ> tCC_TiposDocumentosCCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Vendedores> tCC_Vendedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_EventosCursos> tCEC_EventosCursos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_EventosCursosXDictar> tCEC_EventosCursosXDictar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_AsientosContableCab> tCG_AsientosContableCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_AsientosContableDet> tCG_AsientosContableDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_GrupoComprobantes> tCG_GrupoComprobantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_IntAsientosContableCab> tCG_IntAsientosContableCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_ObjetosConsumos> tCG_ObjetosConsumos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_PeriodoContable> tCG_PeriodoContable { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_PlanCuentasEmpresa> tCG_PlanCuentasEmpresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_SaldoMayor> tCG_SaldoMayor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_SecuencialesComprobantes> tCG_SecuencialesComprobantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AprobacionDePagos> tCP_AprobacionDePagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_ArchivoBancoAnticipado> tCP_ArchivoBancoAnticipado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXCargos> tCP_AsientosXCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXCruces> tCP_AsientosXCruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXDescargos> tCP_AsientosXDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCab> tCP_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CruceDocumentos> tCP_CruceDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_FinanciamientoCargos> tCP_FinanciamientoCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_Proveedores> tCP_Proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCT_ListaPrecios> tCT_ListaPrecios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFT_FacturaCab> tFT_FacturaCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFT_Productos> tFT_Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_BancosCCQ> tGN_BancosCCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_CentrosCostos> tGN_CentrosCostos { get; set; }
        public virtual tGN_TiposEmpresas tGN_TiposEmpresas { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Establecimientos> tGN_Establecimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_InformacionesAdicionalesDocumentos> tGN_InformacionesAdicionalesDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Parametros> tGN_Parametros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_ParametrosGenerales> tGN_ParametrosGenerales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_TarjetaCredito> tGN_TarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_TiposDocumentos> tGN_TiposDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Ajustes> tIV_Ajustes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Bodegas> tIV_Bodegas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Articulos> tIV_Articulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Contabilizacion> tIV_Contabilizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_MaestroFisico> tIV_MaestroFisico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_MaestroSolicitudes> tIV_MaestroSolicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Saldos> tIV_Saldos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Transacciones> tIV_Transacciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Areas> tNM_Areas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_BasesCalculadas> tNM_BasesCalculadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CalendarioNominas> tNM_CalendarioNominas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Colaboradores> tNM_Colaboradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Conceptos> tNM_Conceptos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Departamentos> tNM_Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Empleados> tNM_Empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_FormularioGP> tNM_FormularioGP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_DetalleFormulacionMes> tPR_DetalleFormulacionMes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_MaestroFormulacion> tPR_MaestroFormulacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_MaestroFormulacionFlujoCaja> tPR_MaestroFormulacionFlujoCaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_MaestroPresupuesto> tPR_MaestroPresupuesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_MaestroPresupuestoFlujoCaja> tPR_MaestroPresupuestoFlujoCaja { get; set; }
    }
}