//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCC_Contactos
    {
        public int IdContacto { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdTipoContacto { get; set; }
        public string PersonaContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string Contacto { get; set; }
        public string Descripcion { get; set; }
    
        public virtual tCC_Clientes tCC_Clientes { get; set; }
        public virtual tCC_TiposContactos tCC_TiposContactos { get; set; }
    }
}
