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
    
    public partial class tCEC_Estudiantes
    {
        public int IdEstudiante { get; set; }
        public int IdPersona { get; set; }
        public string IdTipoIdentificacion { get; set; }
        public Nullable<int> IdEstadoCivil { get; set; }
        public Nullable<int> IdNivelInstruccion { get; set; }
        public Nullable<int> IdProfesion { get; set; }
        public Nullable<int> CodigoSocio { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string CorreoPersonal { get; set; }
        public string CorreoEmpresarial { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoConvencional { get; set; }
        public string DireccionDomicilio { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_Personas tGN_Personas { get; set; }
    }
}
