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
    
    public partial class tGN_ColumnasTablasSistema
    {
        public int IdColumnaTablaSistema { get; set; }
        public string NombreTabla { get; set; }
        public string NombreColumna { get; set; }
    
        public virtual tGN_TablasSistema tGN_TablasSistema { get; set; }
    }
}