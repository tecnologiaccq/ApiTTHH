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
    
    public partial class tGN_FormastGN_Formass_tCC_CajaIngresoChequeftCC_CajaIngresoCheques
    {
        public Nullable<int> ftCC_CajaIngresoCheques { get; set; }
        public Nullable<int> tGN_Formass { get; set; }
        public int OID { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
    
        public virtual tCC_CajaIngresoCheque tCC_CajaIngresoCheque { get; set; }
        public virtual tGN_Formas tGN_Formas { get; set; }
    }
}
