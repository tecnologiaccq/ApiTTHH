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
    
    public partial class tCP_LiquidacionComprasReembolsos
    {
        public int IdReembolso { get; set; }
        public int IdCargoCab { get; set; }
        public string TipoIdentificacionProveedorReembolso { get; set; }
        public string IdentificacionProveedorReembolso { get; set; }
        public string RazonSocialProveedorReembolso { get; set; }
        public string CodPaisPagoProveedorReembolso { get; set; }
        public string TipoProveedorReembolso { get; set; }
        public string CodDocReembolso { get; set; }
        public Nullable<System.DateTime> FechaEmisionDocReembolso { get; set; }
        public string EstablecimientoDocReembolso { get; set; }
        public string PuntoEmisioniDocReembolso { get; set; }
        public string SecuencialDocReembolso { get; set; }
        public string NumeroDocumentoReembolso { get; set; }
        public string NumeroAutorizacionDocReembolso { get; set; }
        public Nullable<decimal> ImporteTotalReembolso { get; set; }
        public Nullable<decimal> SubTotalIvaVigentePorCiento { get; set; }
        public Nullable<decimal> SubtotalIVACeroPorCiento { get; set; }
        public Nullable<decimal> SubtotalIVANoObjetoIva { get; set; }
        public Nullable<decimal> SubtotalIVAExcentoIva { get; set; }
        public Nullable<decimal> ValorIVA { get; set; }
        public Nullable<decimal> ValorICE { get; set; }
        public Nullable<int> xtraIdReembolsoPadre { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
