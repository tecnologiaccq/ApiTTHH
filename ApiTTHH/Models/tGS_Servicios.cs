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
    
    public partial class tGS_Servicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGS_Servicios()
        {
            this.tGS_Beneficiario = new HashSet<tGS_Beneficiario>();
            this.tGS_ProductosServicios = new HashSet<tGS_ProductosServicios>();
            this.tGS_ServiciosClientes = new HashSet<tGS_ServiciosClientes>();
        }
    
        public int IdServicio { get; set; }
        public int IdAreaGestion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string AplicaTipoCliente { get; set; }
    
        public virtual tGS_AreasGestion tGS_AreasGestion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Beneficiario> tGS_Beneficiario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_ProductosServicios> tGS_ProductosServicios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_ServiciosClientes> tGS_ServiciosClientes { get; set; }
    }
}