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
    
    public partial class tIV_ConversionUnidades
    {
        public int IdConversionUnidades { get; set; }
        public int IdUnidadOrigen { get; set; }
        public int IdUnidadDestino { get; set; }
        public decimal Factor { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tIV_UnidadesMedida tIV_UnidadesMedida { get; set; }
        public virtual tIV_UnidadesMedida tIV_UnidadesMedida1 { get; set; }
    }
}
