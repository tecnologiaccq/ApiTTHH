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
    
    public partial class tCG_ProcesoMayorizacion
    {
        public int IdProcesoMayorizacion { get; set; }
        public string CodigoCuenta { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Debito { get; set; }
        public Nullable<decimal> Credito { get; set; }
        public Nullable<decimal> FinalDebito { get; set; }
        public Nullable<decimal> FinalCredito { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
