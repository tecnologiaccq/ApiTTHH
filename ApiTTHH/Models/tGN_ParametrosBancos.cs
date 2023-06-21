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
    
    public partial class tGN_ParametrosBancos
    {
        public int IdParametroBanco { get; set; }
        public int IdBanco { get; set; }
        public string CodigoOrientacionCobro { get; set; }
        public string CodigoOrientacionPago { get; set; }
        public string FormaPagoCreditoCuenta { get; set; }
        public string FormaPagoCreditoEfectivo { get; set; }
        public string FormaPagoCreditoCheque { get; set; }
        public string FormaPagoCreditoDebitoCuenta { get; set; }
        public string FormaPagoCreditoRecaudacion { get; set; }
        public string TipoCuentaCorriente { get; set; }
        public string TipoCuentaAhorros { get; set; }
        public string TipoCuentaVirtualPago { get; set; }
        public string TipoCuentaDebitoCuenta { get; set; }
        public string TipoIdClienteCedula { get; set; }
        public string TipoIdClienteRuc { get; set; }
        public string TipoIdClientePasaporte { get; set; }
        public string TipoIdClienteNoDisponible { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_Bancos tGN_Bancos { get; set; }
    }
}