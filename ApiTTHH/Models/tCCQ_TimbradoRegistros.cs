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
    
    public partial class tCCQ_TimbradoRegistros
    {
        public int IdRegistro { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<System.DateTime> FechaTimbrado { get; set; }
        public Nullable<System.DateTime> FechaHoraTimbrado { get; set; }
        public Nullable<int> IdTipoAcceso { get; set; }
        public string IpCliente { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
    }
}