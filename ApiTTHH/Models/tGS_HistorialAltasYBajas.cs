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
    
    public partial class tGS_HistorialAltasYBajas
    {
        public int IdHistorialAltaYBaja { get; set; }
        public int IdSocio { get; set; }
        public int IdMotivoAltaYBaja { get; set; }
        public System.DateTime FechaAltaOBaja { get; set; }
        public string Observacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGS_MotivosAltasYBajas tGS_MotivosAltasYBajas { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
    }
}
