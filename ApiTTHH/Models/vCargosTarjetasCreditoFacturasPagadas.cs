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
    
    public partial class vCargosTarjetasCreditoFacturasPagadas
    {
        public Nullable<long> Id { get; set; }
        public string RazonSocial { get; set; }
        public Nullable<int> CodigoSocio { get; set; }
        public string Identificacion { get; set; }
        public string TipoFactura { get; set; }
        public string NumeroDocumento { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public int IdDescargoCab { get; set; }
        public int IdCajaIngresoTarjetaCredito { get; set; }
    }
}