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
    
    public partial class SecuencialCatalogo
    {
        public int IdSecuencialCatalogo { get; set; }
        public string NombreTabla { get; set; }
        public int Secuencial { get; set; }
        public bool Activo { get; set; }
        public Nullable<bool> Borrado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    }
}