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
    
    public partial class KpiHistoryItem
    {
        public System.Guid Oid { get; set; }
        public Nullable<System.Guid> KpiInstance { get; set; }
        public Nullable<System.DateTime> RangeStart { get; set; }
        public Nullable<System.DateTime> RangeEnd { get; set; }
        public Nullable<double> Value { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
    
        public virtual KpiInstance KpiInstance1 { get; set; }
    }
}
