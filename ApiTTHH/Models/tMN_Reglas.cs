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
    
    public partial class tMN_Reglas
    {
        public int IdReglas { get; set; }
        public string Nombre { get; set; }
        public string SQL { get; set; }
        public string SP { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> UltimoProceso { get; set; }
        public Nullable<int> Frecuencia { get; set; }
        public Nullable<int> UndFrecuencia { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
