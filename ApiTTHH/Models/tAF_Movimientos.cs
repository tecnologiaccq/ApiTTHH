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
    
    public partial class tAF_Movimientos
    {
        public int IdMovimiento { get; set; }
        public int IdActivo { get; set; }
        public Nullable<int> IdUbicacionDestino { get; set; }
        public Nullable<int> IdProveedorDestino { get; set; }
        public string Motivo { get; set; }
        public Nullable<System.DateTime> FechaEstimadaRetorno { get; set; }
        public Nullable<System.DateTime> FechaRealRetorno { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdCentroDestino { get; set; }
        public Nullable<bool> Procesado { get; set; }
    
        public virtual tAF_MaestroActivos tAF_MaestroActivos { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tAF_Ubicaciones tAF_Ubicaciones { get; set; }
    }
}
