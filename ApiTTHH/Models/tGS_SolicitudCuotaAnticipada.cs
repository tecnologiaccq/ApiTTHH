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
    
    public partial class tGS_SolicitudCuotaAnticipada
    {
        public int IdSolicitudCuotaAnticipada { get; set; }
        public int IdSocio { get; set; }
        public Nullable<System.DateTime> FechaCuota { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<int> NroMeses { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<decimal> ValorCuota { get; set; }
        public Nullable<decimal> ValorDescuento { get; set; }
        public Nullable<decimal> ValorCuotaDevengar { get; set; }
        public Nullable<decimal> ValorDescuentoDevengar { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdCuotaGenerada { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdCaja { get; set; }
        public Nullable<int> IdCobrador { get; set; }
    
        public virtual tGS_Socios tGS_Socios { get; set; }
    }
}
