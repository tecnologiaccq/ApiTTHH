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
    
    public partial class vCP_ProveedorCargosDescargos
    {
        public int IdEmpresa { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public int IdPeriodoContable { get; set; }
        public string NumeroDocumento { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<int> IdEstadoDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public Nullable<int> IdGrupoComprobante { get; set; }
        public Nullable<long> NumeroComprobante { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    }
}
