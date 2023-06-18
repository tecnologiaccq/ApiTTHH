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
    
    public partial class tCC_FallosDebitoBancos
    {
        public int IdFallosDebitoBancos { get; set; }
        public string CodigoBanco { get; set; }
        public int IdBancoCCQ { get; set; }
        public string NumeroOrden { get; set; }
        public System.DateTime FechaCobro { get; set; }
        public int Secuencial { get; set; }
        public string NumeroItem { get; set; }
        public string Referencia { get; set; }
        public decimal ValorCobrado { get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdCargoCab { get; set; }
        public string Detalles { get; set; }
        public Nullable<bool> CorreoEnviado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCC_CargosCab tCC_CargosCab { get; set; }
        public virtual tCC_Clientes tCC_Clientes { get; set; }
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
    }
}
