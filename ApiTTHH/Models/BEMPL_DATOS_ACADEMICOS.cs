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
    
    public partial class BEMPL_DATOS_ACADEMICOS
    {
        public int IdEstudio { get; set; }
        public Nullable<int> IdDatosPostulante { get; set; }
        public string Institucion { get; set; }
        public Nullable<int> IdNivelEstudio { get; set; }
        public Nullable<int> IdEstadonivelAcademico { get; set; }
        public Nullable<int> AnioInicio { get; set; }
        public Nullable<int> MesInicio { get; set; }
        public Nullable<int> AnioFin { get; set; }
        public Nullable<int> MesFin { get; set; }
        public Nullable<bool> AlPresente { get; set; }
        public string Titulo { get; set; }
        public string MesInicioDesc { get; set; }
        public string MesFinDesc { get; set; }
    
        public virtual BEMPL_CAT_NIVEL_ESTUDIO BEMPL_CAT_NIVEL_ESTUDIO { get; set; }
        public virtual BEMPL_DATOS_ACADEMICOS BEMPL_DATOS_ACADEMICOS1 { get; set; }
        public virtual BEMPL_DATOS_ACADEMICOS BEMPL_DATOS_ACADEMICOS2 { get; set; }
        public virtual BEMPL_ESTADONIVELACADEMICO BEMPL_ESTADONIVELACADEMICO { get; set; }
        public virtual BEMPL_CAT_NIVEL_ACADEMICO BEMPL_CAT_NIVEL_ACADEMICO { get; set; }
    }
}