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
    
    public partial class tNM_LimitesGP
    {
        public int IdLimiteGP { get; set; }
        public int EjercicioFiscal { get; set; }
        public decimal GastosVivienda { get; set; }
        public decimal GastosEducacion { get; set; }
        public decimal GastosSalud { get; set; }
        public decimal GastosVestimenta { get; set; }
        public decimal GastosAlimentacion { get; set; }
        public decimal GastosArteCultura { get; set; }
        public decimal GastosEnfermedadesCatastroficas { get; set; }
        public decimal ExoneracionDiscapacidad { get; set; }
        public decimal ExoneracionTerceraEdad { get; set; }
        public decimal GastosTotales { get; set; }
        public decimal PorcentajeTotal { get; set; }
        public decimal ImpuestoARetener { get; set; }
        public decimal PorcentajeRetencion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    }
}
