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
    
    public partial class vPlanificacionCuotasAnticipadasEmisionBimestral
    {
        public int IdSolicitudCuotaAnticipada { get; set; }
        public int idsocio { get; set; }
        public int CodigoSocio { get; set; }
        public string FechaCuota { get; set; }
        public string FechaInicio { get; set; }
        public int nromeses { get; set; }
        public string FechaVencimiento { get; set; }
        public Nullable<decimal> ValorCuota { get; set; }
        public Nullable<decimal> ValorDescuento { get; set; }
        public Nullable<decimal> ValorCuotaDevengar { get; set; }
        public Nullable<decimal> ValorDescuentoDevengar { get; set; }
        public string Descripcion { get; set; }
        public int IdCuotaGenerada { get; set; }
        public int IdCaja { get; set; }
    }
}
