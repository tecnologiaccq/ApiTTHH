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
    
    public partial class MSG_Whatsapp
    {
        public int IdMensaje { get; set; }
        public string NombreAplicacion { get; set; }
        public string Proceso { get; set; }
        public string Telefono { get; set; }
        public string Mensaje { get; set; }
        public string UrlFile { get; set; }
        public string Filename { get; set; }
        public Nullable<bool> isEnviado { get; set; }
        public Nullable<System.DateTime> FechaHoraEnvío { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
