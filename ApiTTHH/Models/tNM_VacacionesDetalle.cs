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
    
    public partial class tNM_VacacionesDetalle
    {
        public long IdVacacionDetalle { get; set; }
        public Nullable<long> IdVacacion { get; set; }
        public Nullable<long> IdHistorialVacaciones { get; set; }
        public Nullable<decimal> DiasSolicitados { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tNM_HistorialVacaciones tNM_HistorialVacaciones { get; set; }
        public virtual tNM_Vacaciones tNM_Vacaciones { get; set; }
    }
}
