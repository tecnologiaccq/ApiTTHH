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
    
    public partial class tRP_PresupuestoVendedor
    {
        public int IdPresupuestoVendedor { get; set; }
        public System.DateTime FinMes { get; set; }
        public int IdVendedor { get; set; }
        public decimal Presupuesto { get; set; }
        public decimal Venta { get; set; }
        public Nullable<decimal> SaldoPpto { get; set; }
        public Nullable<decimal> Cumplimiento { get; set; }
    }
}
