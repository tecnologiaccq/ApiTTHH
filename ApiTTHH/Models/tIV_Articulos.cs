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
    
    public partial class tIV_Articulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tIV_Articulos()
        {
            this.tIV_Ajustes = new HashSet<tIV_Ajustes>();
            this.tIV_DetalleRecepciones = new HashSet<tIV_DetalleRecepciones>();
            this.tIV_DetalleSolicitudes = new HashSet<tIV_DetalleSolicitudes>();
            this.tIV_Fisico = new HashSet<tIV_Fisico>();
            this.tIV_Saldos = new HashSet<tIV_Saldos>();
            this.tIV_Transacciones = new HashSet<tIV_Transacciones>();
        }
    
        public int IdArticulo { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoArticulo { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public string Descripcion { get; set; }
        public int MaxDias { get; set; }
        public int MinDias { get; set; }
        public decimal MaxCantidad { get; set; }
        public decimal MinCantidad { get; set; }
        public int IdUnidadStock { get; set; }
        public decimal CostoUnitario { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Ajustes> tIV_Ajustes { get; set; }
        public virtual tIV_Bodegas tIV_Bodegas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleRecepciones> tIV_DetalleRecepciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleSolicitudes> tIV_DetalleSolicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Fisico> tIV_Fisico { get; set; }
        public virtual tIV_TiposArticulos tIV_TiposArticulos { get; set; }
        public virtual tIV_UnidadesMedida tIV_UnidadesMedida { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Saldos> tIV_Saldos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Transacciones> tIV_Transacciones { get; set; }
    }
}
