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
    
    public partial class tCC_HistoricoCargosCab
    {
        public int IdHistoricoCargosCab { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdCargoCab { get; set; }
        public int IdTipoDocumentoCCQ { get; set; }
        public int IdCobradorEfectivo { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Saldo { get; set; }
    }
}