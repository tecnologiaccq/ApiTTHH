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
    
    public partial class tGS_Desuscripciones
    {
        public int IdDesuscripcion { get; set; }
        public int IdContactoPersona { get; set; }
        public string NumeroBoletin { get; set; }
        public string DescripcionBoletin { get; set; }
        public Nullable<System.DateTime> FechaDesuscripcion { get; set; }
        public string ObservacionDesuscripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_ContactoPersona tGN_ContactoPersona { get; set; }
    }
}