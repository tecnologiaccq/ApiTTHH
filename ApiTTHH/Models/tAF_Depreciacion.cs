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
    
    public partial class tAF_Depreciacion
    {
        public int IdDepreciacion { get; set; }
        public int IdActivo { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPeriodoContable { get; set; }
        public Nullable<decimal> ValorAlicuota { get; set; }
        public Nullable<int> PeriodosDepreciados { get; set; }
        public Nullable<decimal> DepreciacionAcumulada { get; set; }
        public Nullable<int> IdUbicacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdCentroCostos { get; set; }
    
        public virtual tAF_MaestroActivos tAF_MaestroActivos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
        public virtual tAF_Ubicaciones tAF_Ubicaciones { get; set; }
    }
}
