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
    
    public partial class vRegistroAtencionCliente
    {
        public int IdAtencion { get; set; }
        public Nullable<int> idCliente { get; set; }
        public string Categoria { get; set; }
        public string Servicio { get; set; }
        public string gestion { get; set; }
        public string Notas { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
