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
    
    public partial class tAF_AnexosIncorporaciones
    {
        public System.Guid Oid { get; set; }
        public Nullable<System.Guid> File { get; set; }
        public Nullable<int> IdIncorporacion { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
        public Nullable<int> IdTipoAnexo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdDesincorporacion { get; set; }
    
        public virtual tAF_Incorporaciones tAF_Incorporaciones { get; set; }
        public virtual tAF_Incorporaciones tAF_Incorporaciones1 { get; set; }
        public virtual tGN_TiposAnexos tGN_TiposAnexos { get; set; }
    }
}
