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
    
    public partial class tIV_DetalleRecepciones
    {
        public int IdDetalleRecepciones { get; set; }
        public int IdMaestroRecepciones { get; set; }
        public int IdBodega { get; set; }
        public int IdArticulo { get; set; }
        public decimal CantidadRecibida { get; set; }
        public int IdUnidadMedida { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Cantidad { get; set; }
        public int IdUnidadStock { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tIV_Articulos tIV_Articulos { get; set; }
        public virtual tIV_Bodegas tIV_Bodegas { get; set; }
        public virtual tIV_MaestroRecepciones tIV_MaestroRecepciones { get; set; }
        public virtual tIV_UnidadesMedida tIV_UnidadesMedida { get; set; }
        public virtual tIV_UnidadesMedida tIV_UnidadesMedida1 { get; set; }
    }
}
