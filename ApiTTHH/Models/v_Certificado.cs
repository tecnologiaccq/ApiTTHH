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
    
    public partial class v_Certificado
    {
        public int Id { get; set; }
        public Nullable<bool> Web { get; set; }
        public string Nombre { get; set; }
        public int CodigoSocio { get; set; }
        public int IdEstadoSocio { get; set; }
        public Nullable<int> IdVendedor { get; set; }
        public Nullable<int> cuotas_debe { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Parrafo1 { get; set; }
        public string Parrafo2 { get; set; }
        public string Parrafo3 { get; set; }
        public string Parrafo4 { get; set; }
        public string Validez { get; set; }
        public string Fecha { get; set; }
        public string NombreEmisor { get; set; }
        public string Persona { get; set; }
        public string CargoPersona { get; set; }
    }
}
