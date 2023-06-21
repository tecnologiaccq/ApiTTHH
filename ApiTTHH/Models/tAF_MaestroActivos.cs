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
    
    public partial class tAF_MaestroActivos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tAF_MaestroActivos()
        {
            this.mAF_Depreciacion = new HashSet<mAF_Depreciacion>();
            this.mAF_MaestroActivos = new HashSet<mAF_MaestroActivos>();
            this.tAF_AnexoMaestro = new HashSet<tAF_AnexoMaestro>();
            this.tAF_Depreciacion = new HashSet<tAF_Depreciacion>();
            this.tAF_Desincorporaciones = new HashSet<tAF_Desincorporaciones>();
            this.tAF_Incorporaciones = new HashSet<tAF_Incorporaciones>();
            this.tAF_MaestroActivos1 = new HashSet<tAF_MaestroActivos>();
            this.tAF_Movimientos = new HashSet<tAF_Movimientos>();
        }
    
        public int IdActivo { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> CodigoActivo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdTipoActivo { get; set; }
        public Nullable<int> IdClase { get; set; }
        public Nullable<int> IdUbicacion { get; set; }
        public Nullable<int> VidaUtil { get; set; }
        public Nullable<int> PeriodosDepreciados { get; set; }
        public Nullable<decimal> ValorOriginal { get; set; }
        public Nullable<decimal> DepreciacionAcumulada { get; set; }
        public string FechaUltimaDepreciacion { get; set; }
        public Nullable<decimal> ValorAlicuota { get; set; }
        public Nullable<decimal> ValorRescate { get; set; }
        public string FechaIncorporacion { get; set; }
        public Nullable<int> IdActivoAsociado { get; set; }
        public Nullable<int> IdColor { get; set; }
        public Nullable<int> IdMarca { get; set; }
        public string Serial { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string FacturaCompra { get; set; }
        public string FechaCompra { get; set; }
        public string NombreProveedorGarantia { get; set; }
        public string FechaVencimientoGarantia { get; set; }
        public string FechaDesincorporacion { get; set; }
        public string EmpresaAseguradora { get; set; }
        public string NumeroPoliza { get; set; }
        public string FechaVencimientoPoliza { get; set; }
        public Nullable<decimal> ValorPrimaSeguro { get; set; }
        public Nullable<decimal> ValorAsegurado { get; set; }
        public Nullable<int> IdSituacion { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdMotivoBaja { get; set; }
        public string CreadoPor { get; set; }
        public string FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public string UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdCentroCostos { get; set; }
        public string Colores { get; set; }
        public string Marca { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAF_Depreciacion> mAF_Depreciacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mAF_MaestroActivos> mAF_MaestroActivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_AnexoMaestro> tAF_AnexoMaestro { get; set; }
        public virtual tAF_Clases tAF_Clases { get; set; }
        public virtual tAF_Colores tAF_Colores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Depreciacion> tAF_Depreciacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Desincorporaciones> tAF_Desincorporaciones { get; set; }
        public virtual tAF_Estados tAF_Estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Incorporaciones> tAF_Incorporaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_MaestroActivos> tAF_MaestroActivos1 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos2 { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tAF_MotivosBaja tAF_MotivosBaja { get; set; }
        public virtual tCP_Proveedores tCP_Proveedores { get; set; }
        public virtual tAF_Situaciones tAF_Situaciones { get; set; }
        public virtual tAF_TiposActivos tAF_TiposActivos { get; set; }
        public virtual tAF_Ubicaciones tAF_Ubicaciones { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos11 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos3 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos12 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos4 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos13 { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos5 { get; set; }
        public virtual tAF_Marcas tAF_Marcas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Movimientos> tAF_Movimientos { get; set; }
    }
}