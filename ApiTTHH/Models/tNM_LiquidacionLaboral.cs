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
    
    public partial class tNM_LiquidacionLaboral
    {
        public long IdLiquidacionLaboral { get; set; }
        public int IdColaborador { get; set; }
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public Nullable<int> IdMotivoEgreso { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> EstadoProceso { get; set; }
        public Nullable<int> IdCalendarioNomina { get; set; }
        public Nullable<int> IdModoCalculo { get; set; }
        public Nullable<decimal> DiasFaltantes { get; set; }
    
        public virtual tNM_CalendarioNominas tNM_CalendarioNominas { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_MotivosEgreso tNM_MotivosEgreso { get; set; }
    }
}
