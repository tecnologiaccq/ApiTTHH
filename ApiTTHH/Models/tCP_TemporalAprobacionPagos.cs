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
    
    public partial class tCP_TemporalAprobacionPagos
    {
        public int IdTemporalAprobacionPagos { get; set; }
        public Nullable<int> IdAprobacionPago { get; set; }
        public Nullable<int> IdCargoCab { get; set; }
    
        public virtual tCP_AprobacionDePagos tCP_AprobacionDePagos { get; set; }
    }
}