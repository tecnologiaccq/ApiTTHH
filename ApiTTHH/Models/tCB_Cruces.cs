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
    
    public partial class tCB_Cruces
    {
        public int IdCruce { get; set; }
        public Nullable<int> IdConciliacion { get; set; }
        public Nullable<int> IdMovimientoContable { get; set; }
        public Nullable<int> IdMovimientoBancario { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<System.DateTime> FechaCruce { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCB_Conciliaciones tCB_Conciliaciones { get; set; }
        public virtual tCB_MovimientosBancarios tCB_MovimientosBancarios { get; set; }
        public virtual tCB_MovimientosContables tCB_MovimientosContables { get; set; }
    }
}
