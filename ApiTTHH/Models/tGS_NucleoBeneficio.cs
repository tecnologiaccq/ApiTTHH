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
    
    public partial class tGS_NucleoBeneficio
    {
        public int IdNucleoBeneficio { get; set; }
        public Nullable<int> IdNucleo { get; set; }
        public Nullable<int> IdBeneficio { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGS_Beneficio tGS_Beneficio { get; set; }
        public virtual tGS_Nucleo tGS_Nucleo { get; set; }
    }
}