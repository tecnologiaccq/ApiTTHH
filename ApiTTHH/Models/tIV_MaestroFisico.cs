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
    
    public partial class tIV_MaestroFisico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tIV_MaestroFisico()
        {
            this.tIV_Ajustes = new HashSet<tIV_Ajustes>();
            this.tIV_Fisico = new HashSet<tIV_Fisico>();
            this.tIV_Transacciones = new HashSet<tIV_Transacciones>();
        }
    
        public int IdMaestroFisico { get; set; }
        public int IdEmpresa { get; set; }
        public int IdBodega { get; set; }
        public System.DateTime FechaFisico { get; set; }
        public Nullable<System.DateTime> FechaAplicacion { get; set; }
        public string Descripcion { get; set; }
        public int Situacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdAsientoContableCab { get; set; }
    
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Ajustes> tIV_Ajustes { get; set; }
        public virtual tIV_Bodegas tIV_Bodegas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Fisico> tIV_Fisico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Transacciones> tIV_Transacciones { get; set; }
    }
}
