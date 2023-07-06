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
    
    public partial class tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp
    {
        public int IdCajaIngresoTarjetaCredito { get; set; }
        public int IdDescargoCab { get; set; }
        public Nullable<int> IdCaja { get; set; }
        public string NumeroDeposito { get; set; }
        public Nullable<bool> EsDepositoDefinitivo { get; set; }
        public int IdFormaPagoSRI { get; set; }
        public int IdTarjetaCredito { get; set; }
        public string Recap { get; set; }
        public string NumeroVoucher { get; set; }
        public int IdMesFormaPagoTarjeta { get; set; }
        public decimal Interes { get; set; }
        public decimal Valor { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public string NumeroTarjeta { get; set; }
    
        public virtual tCC_Caja tCC_Caja { get; set; }
        public virtual tCT_FormasPagoSRI tCT_FormasPagoSRI { get; set; }
        public virtual tGN_MesFormaPagoTarjeta tGN_MesFormaPagoTarjeta { get; set; }
        public virtual tGN_TarjetaCredito tGN_TarjetaCredito { get; set; }
        public virtual tCC_DescargosCabRelacionPagoTemp tCC_DescargosCabRelacionPagoTemp { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
    }
}
