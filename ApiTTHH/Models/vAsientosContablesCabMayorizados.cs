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
    
    public partial class vAsientosContablesCabMayorizados
    {
        public int IdAsientoContableCab { get; set; }
        public string Empresa { get; set; }
        public string Descripcion { get; set; }
        public string GrupoComprobantes { get; set; }
        public Nullable<long> NumeroComprobante { get; set; }
        public Nullable<decimal> TotalDebito { get; set; }
        public Nullable<decimal> TotalCredito { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaComprobante { get; set; }
        public string PeriodoContable { get; set; }
        public int IdEmpresa { get; set; }
    }
}