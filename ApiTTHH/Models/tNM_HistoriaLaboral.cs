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
    
    public partial class tNM_HistoriaLaboral
    {
        public long IdHistoriaLaboral { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public string Texto { get; set; }
        public Nullable<long> IdHistorialConceptoFijo { get; set; }
        public Nullable<long> IdHistorialCargo { get; set; }
        public Nullable<long> IdCambioDepartamento { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tNM_CambiosDepartamentos tNM_CambiosDepartamentos { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_HistorialCargos tNM_HistorialCargos { get; set; }
        public virtual tNM_HistorialConceptosFijos tNM_HistorialConceptosFijos { get; set; }
    }
}
