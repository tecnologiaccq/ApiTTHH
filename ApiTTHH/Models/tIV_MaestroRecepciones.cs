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
    
    public partial class tIV_MaestroRecepciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tIV_MaestroRecepciones()
        {
            this.tIV_DetalleRecepciones = new HashSet<tIV_DetalleRecepciones>();
            this.tIV_Transacciones = new HashSet<tIV_Transacciones>();
        }
    
        public int IdMaestroRecepciones { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> Idproveedor { get; set; }
        public System.DateTime FechaRecepcion { get; set; }
        public string OrdenCompra { get; set; }
        public Nullable<int> Factura { get; set; }
        public Nullable<System.DateTime> FechaProceso { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoTransaccion { get; set; }
        public int Situacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdAsientoContableCab { get; set; }
    
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_DetalleRecepciones> tIV_DetalleRecepciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Transacciones> tIV_Transacciones { get; set; }
    }
}
