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
    
    public partial class tNM_ConceptosFijos
    {
        public long IdConceptoFijo { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<decimal> Unidades { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string Observaciones { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> NumeroCuotas { get; set; }
        public Nullable<int> CuotasPagadas { get; set; }
    
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_Conceptos tNM_Conceptos { get; set; }
    }
}