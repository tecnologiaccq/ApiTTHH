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
    
    public partial class XpoWorkflowInstanceControlCommandRequest
    {
        public System.Guid Oid { get; set; }
        public string TargetWorkflowUniqueId { get; set; }
        public Nullable<System.Guid> TargetActivityInstanceId { get; set; }
        public Nullable<int> Command { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Result { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
    }
}
