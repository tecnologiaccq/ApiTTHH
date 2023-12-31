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
    
    public partial class tGS_SociosPreregistro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGS_SociosPreregistro()
        {
            this.tGS_CuotasAfiliacion = new HashSet<tGS_CuotasAfiliacion>();
        }
    
        public int IdSocioPreregistro { get; set; }
        public int IdEmpresa { get; set; }
        public int IdVendedor { get; set; }
        public int IdMedioPago { get; set; }
        public int IdCobrador { get; set; }
        public int IdAsesor { get; set; }
        public int IdFrecuenciaGeneracionCuota { get; set; }
        public int IdTipoEmpresa { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdTipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> IdTarjetaCredito { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjetaCredito { get; set; }
        public Nullable<System.DateTime> FechaCaducidadTarjeta { get; set; }
        public Nullable<int> IdFormaPagoSRI { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public int IdLocalidad { get; set; }
        public int IdParroquia { get; set; }
        public string TelefonoFacturacion { get; set; }
        public string EmailFacturacion { get; set; }
        public decimal Capital { get; set; }
        public Nullable<decimal> ValorCuota { get; set; }
        public Nullable<decimal> ValorDescuentoAcuerdo { get; set; }
        public string CallePrincipal { get; set; }
        public string InterseccionPrincipal { get; set; }
        public string InterseccionSecundaria { get; set; }
        public string Numero { get; set; }
        public string NumeroReferencia { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<decimal> ValorCuotaIngreso { get; set; }
        public bool Aprobado { get; set; }
        public bool GenerarCuotaOrdinaria { get; set; }
        public Nullable<int> TipoRegistro { get; set; }
        public string CodigoSocioTemp { get; set; }
        public Nullable<int> IdCobradorFacturas { get; set; }
        public bool UsarDireccionFacturacionParaMatrix { get; set; }
        public Nullable<int> MesPreregistro { get; set; }
        public string OrdenCompraProximaFactura { get; set; }
        public Nullable<int> IdActividadCIIU { get; set; }
        public Nullable<bool> EsEmprendedor { get; set; }
        public Nullable<int> IdGrupoAfinidad { get; set; }
        public Nullable<int> CodigoSocioPadre { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdSocioPadre { get; set; }
        public Nullable<int> IdEstadoSocioPadre { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdSocioExiste { get; set; }
        public bool ExcluidoParaFacturacionSocial { get; set; }
        public byte IdMesEmisionBimestral { get; set; }
        public int MesesCuota { get; set; }
        public int NumeroCuotas { get; set; }
    
        public virtual tCC_Clientes tCC_Clientes { get; set; }
        public virtual tCC_Cobradores tCC_Cobradores { get; set; }
        public virtual tCC_Cobradores tCC_Cobradores1 { get; set; }
        public virtual tCC_Vendedores tCC_Vendedores { get; set; }
        public virtual tCT_FormasPagoSRI tCT_FormasPagoSRI { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_EstadoSocio tGN_EstadoSocio { get; set; }
        public virtual tGN_Localidad tGN_Localidad { get; set; }
        public virtual tGN_MediosPagos tGN_MediosPagos { get; set; }
        public virtual tGN_Parroquias tGN_Parroquias { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tGN_TarjetaCredito tGN_TarjetaCredito { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        public virtual tGN_TiposEmpresas tGN_TiposEmpresas { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion { get; set; }
        public virtual tGS_ActividadesCIIU tGS_ActividadesCIIU { get; set; }
        public virtual tGS_Asesor tGS_Asesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_CuotasAfiliacion> tGS_CuotasAfiliacion { get; set; }
        public virtual tGS_FrecuenciaGeneracionCuotas tGS_FrecuenciaGeneracionCuotas { get; set; }
        public virtual tGS_FrecuenciaGeneracionCuotas tGS_FrecuenciaGeneracionCuotas1 { get; set; }
        public virtual tGS_GrupoAfinidad tGS_GrupoAfinidad { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
        public virtual tGS_Socios tGS_Socios1 { get; set; }
    }
}
