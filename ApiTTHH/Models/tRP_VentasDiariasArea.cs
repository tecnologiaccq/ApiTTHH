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
    
    public partial class tRP_VentasDiariasArea
    {
        public int IdVentasDiariasArea { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdCategoriaJerarquica1_2 { get; set; }
        public decimal VentasDia { get; set; }
        public decimal VentasMTD { get; set; }
        public decimal VentasYTD { get; set; }
        public decimal VentasMesAnteriorDia { get; set; }
        public decimal VentasMesAnteriorMTD { get; set; }
        public decimal VentasMesAnteriorTotal { get; set; }
        public decimal VentasAnoAnteriorMTD { get; set; }
        public decimal VentasAnoAnteriorMesTotal { get; set; }
        public decimal VentasAnoAnteriorMesAnterior { get; set; }
        public decimal VentasAnoAnteriorYTD { get; set; }
        public decimal VentasAnoAnteriorTotal { get; set; }
        public decimal PresupuestoMes { get; set; }
        public decimal CumplimientoMes { get; set; }
        public decimal PresupuestoTotal { get; set; }
        public decimal CumplimientoAno { get; set; }
        public decimal ProyeccionMes { get; set; }
        public decimal ProyeccionAno { get; set; }
        public Nullable<decimal> PctjVentasAnoAnteriorMTD { get; set; }
        public Nullable<decimal> PctjVentasAnoAnteriorYTD { get; set; }
    
        public virtual tCT_CategoriaJerarquica1_2 tCT_CategoriaJerarquica1_2 { get; set; }
        public virtual tRP_Fechas tRP_Fechas { get; set; }
    }
}