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
    
    public partial class tCC_RegistroPagoRecaudadores
    {
        public int IdRegistroPagoRecaudador { get; set; }
        public int IdRecaudador { get; set; }
        public int IdTipoPago { get; set; }
        public int IdCliente { get; set; }
        public string IdTipoDocumento { get; set; }
        public int IdCuentaC { get; set; }
        public decimal ValorPago { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string CreadoPor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public System.DateTime UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
