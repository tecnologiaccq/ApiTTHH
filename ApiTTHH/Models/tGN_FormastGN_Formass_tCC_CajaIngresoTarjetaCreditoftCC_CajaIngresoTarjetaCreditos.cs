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
    
    public partial class tGN_FormastGN_Formass_tCC_CajaIngresoTarjetaCreditoftCC_CajaIngresoTarjetaCreditos
    {
        public Nullable<int> ftCC_CajaIngresoTarjetaCreditos { get; set; }
        public Nullable<int> tGN_Formass { get; set; }
        public int OID { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
    
        public virtual tCC_CajaIngresoTarjetaCredito tCC_CajaIngresoTarjetaCredito { get; set; }
        public virtual tGN_Formas tGN_Formas { get; set; }
    }
}