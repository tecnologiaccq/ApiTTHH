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
    
    public partial class tNM_CapacitacionColaborador
    {
        public int IdCapacitacionColaborador { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<System.DateTime> FechaGraduacion { get; set; }
        public string Nombre { get; set; }
        public string Institucion { get; set; }
        public Nullable<int> IdCiudad { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string Titulo_Curso { get; set; }
    
        public virtual tGN_Ciudad tGN_Ciudad { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
    }
}