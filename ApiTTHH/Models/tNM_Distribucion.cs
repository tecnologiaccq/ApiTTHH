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
    
    public partial class tNM_Distribucion
    {
        public int IdDistribucion { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdCentroCostos { get; set; }
        public Nullable<decimal> PorcentajeDistribucion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
    }
}
