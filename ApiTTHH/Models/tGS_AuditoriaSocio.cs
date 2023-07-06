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
    
    public partial class tGS_AuditoriaSocio
    {
        public int IdAuditoriaSocio { get; set; }
        public int IdSocio { get; set; }
        public string IdentificacionAnterior { get; set; }
        public Nullable<int> IdTipoIdentificacionAnterior { get; set; }
        public string PrimerNombreAnterior { get; set; }
        public string SegundoNombreAnterior { get; set; }
        public string PrimerApellidoAnterior { get; set; }
        public string SegundoApellidoAnterior { get; set; }
        public Nullable<decimal> CapitalAnterior { get; set; }
        public Nullable<decimal> ValorCuotaAnterior { get; set; }
        public Nullable<int> IdTamanioSocioAnterior { get; set; }
        public Nullable<int> IdBancoAnterior { get; set; }
        public Nullable<int> IdTipoCuentaAnterior { get; set; }
        public string NumeroCuentaAnterior { get; set; }
        public Nullable<int> IdTarjetaCreditoAnterior { get; set; }
        public string NombreTitularAnterior { get; set; }
        public string NumeroTarjetaCreditoAnterior { get; set; }
        public Nullable<System.DateTime> FechaCaducidadTarjetaAnterior { get; set; }
        public Nullable<int> IdAsesorAnterior { get; set; }
        public Nullable<int> IdCobradorAnterior { get; set; }
        public string IdentificacionActual { get; set; }
        public Nullable<int> IdTipoIdentificacionActual { get; set; }
        public string PrimerNombreActual { get; set; }
        public string SegundoNombreActual { get; set; }
        public string PrimerApellidoActual { get; set; }
        public string SegundoApellidoActual { get; set; }
        public Nullable<decimal> CapitalActual { get; set; }
        public Nullable<decimal> ValorCuotaActual { get; set; }
        public Nullable<int> IdTamanioSocioActual { get; set; }
        public Nullable<int> IdBancoActual { get; set; }
        public Nullable<int> IdTipoCuentaActual { get; set; }
        public string NumeroCuentaActual { get; set; }
        public Nullable<int> IdTarjetaCreditoActual { get; set; }
        public string NombreTitularActual { get; set; }
        public string NumeroTarjetaCreditoActual { get; set; }
        public Nullable<System.DateTime> FechaCaducidadTarjetaActual { get; set; }
        public Nullable<int> IdAsesorActual { get; set; }
        public Nullable<int> IdCobradorActual { get; set; }
        public string Observacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCC_Cobradores tCC_Cobradores { get; set; }
        public virtual tCC_Cobradores tCC_Cobradores1 { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Bancos tGN_Bancos1 { get; set; }
        public virtual tGN_TarjetaCredito tGN_TarjetaCredito { get; set; }
        public virtual tGN_TarjetaCredito tGN_TarjetaCredito1 { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas1 { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion { get; set; }
        public virtual tGN_TiposIdentificacion tGN_TiposIdentificacion1 { get; set; }
        public virtual tGS_Asesor tGS_Asesor { get; set; }
        public virtual tGS_Asesor tGS_Asesor1 { get; set; }
        public virtual tGS_TamanoSocio tGS_TamanoSocio { get; set; }
        public virtual tGS_TamanoSocio tGS_TamanoSocio1 { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
    }
}
