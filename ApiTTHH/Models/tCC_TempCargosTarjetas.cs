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
    
    public partial class tCC_TempCargosTarjetas
    {
        public int IdTempCargosTarjetas { get; set; }
        public string CodigoSocio { get; set; }
        public string Identificacion { get; set; }
        public string Cliente { get; set; }
        public string Tarjeta { get; set; }
        public string FechaEmision { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumentoCargo { get; set; }
        public string NumeroDocumentoDescargo { get; set; }
        public string TipoDocumentoDescargo { get; set; }
        public string Comprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public string Recap { get; set; }
        public string NumeroVoucher { get; set; }
        public string TipoCredito { get; set; }
        public Nullable<decimal> Interes { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string Estado { get; set; }
        public string Facturas { get; set; }
    }
}
