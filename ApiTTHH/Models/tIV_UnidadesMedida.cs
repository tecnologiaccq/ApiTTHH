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
    
    public partial class tIV_UnidadesMedida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tIV_UnidadesMedida()
        {
            this.tIV_Articulos = new HashSet<tIV_Articulos>();
            this.tIV_ConversionUnidades = new HashSet<tIV_ConversionUnidades>();
            this.tIV_ConversionUnidades1 = new HashSet<tIV_ConversionUnidades>();
            this.tIV_DetalleRecepciones = new HashSet<tIV_DetalleRecepciones>();
            this.tIV_DetalleRecepciones1 = new HashSet<tIV_DetalleRecepciones>();
            this.tIV_DetalleSolicitudes = new HashSet<tIV_DetalleSolicitudes>();
            this.tIV_DetalleSolicitudes1 = new HashSet<tIV_DetalleSolicitudes>();
        }
    
        public int IdUnidadMedida { get; set; }
        public string UM { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Articulos> tIV_Articulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_ConversionUnidades> tIV_ConversionUnidades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_ConversionUnidades> tIV_ConversionUnidades1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleRecepciones> tIV_DetalleRecepciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleRecepciones> tIV_DetalleRecepciones1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleSolicitudes> tIV_DetalleSolicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleSolicitudes> tIV_DetalleSolicitudes1 { get; set; }
    }
}
