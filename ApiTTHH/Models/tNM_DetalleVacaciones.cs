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
    
    public partial class tNM_DetalleVacaciones
    {
        public long IdDetalleVacaciones { get; set; }
        public long IdHistorialVacaciones { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public Nullable<System.DateTime> FechaReintegro { get; set; }
        public Nullable<decimal> DiasDisfrutados { get; set; }
        public Nullable<decimal> DiasCancelados { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> FinesSemana { get; set; }
        public Nullable<long> IdVacacion { get; set; }
    
        public virtual tNM_HistorialVacaciones tNM_HistorialVacaciones { get; set; }
        public virtual tNM_Vacaciones tNM_Vacaciones { get; set; }
    }
}
