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
    
    public partial class tCEC_EstudiantesTemporalesWeb
    {
        public int IdEstudianteTemporalWeb { get; set; }
        public string SessionId { get; set; }
        public int IdEvento { get; set; }
        public string NombresApellidos { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<bool> Procesado { get; set; }
    }
}
