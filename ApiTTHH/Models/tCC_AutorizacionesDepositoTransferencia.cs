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
    
    public partial class tCC_AutorizacionesDepositoTransferencia
    {
        public int IdAutorizacionDepositoTransferencia { get; set; }
        public Nullable<int> IdBancoCCQ { get; set; }
        public string Referencia { get; set; }
        public decimal Valor { get; set; }
        public Nullable<System.DateTime> FechaValor { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_BancosCCQ tGN_BancosCCQ { get; set; }
    }
}
