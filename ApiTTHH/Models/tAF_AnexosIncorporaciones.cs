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
