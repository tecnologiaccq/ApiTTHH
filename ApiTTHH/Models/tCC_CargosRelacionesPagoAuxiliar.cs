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
    
    public partial class tCC_CargosRelacionesPagoAuxiliar
    {
        public int IdCargosRelacionesPagoAuxiliar { get; set; }
        public int IdCargoCab { get; set; }
        public Nullable<decimal> SaldoADebitar { get; set; }
        public Nullable<int> IdDescargoCab { get; set; }
        public Nullable<int> IdDescargoCabReal { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCC_CargosCab tCC_CargosCab { get; set; }
        public virtual tCC_DescargosCabRelacionPagoTemp tCC_DescargosCabRelacionPagoTemp { get; set; }
        public virtual tCC_DescargosCab tCC_DescargosCab { get; set; }
    }
}
