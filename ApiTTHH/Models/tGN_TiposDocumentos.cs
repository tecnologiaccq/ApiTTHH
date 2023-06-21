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
    
    public partial class tGN_TiposDocumentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_TiposDocumentos()
        {
            this.ATS_Compras = new HashSet<ATS_Compras>();
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCC_DescargosCab1 = new HashSet<tCC_DescargosCab>();
            this.tCC_DescargosCabRelacionPagoTemp = new HashSet<tCC_DescargosCabRelacionPagoTemp>();
            this.tCC_TemporalCruceDoc = new HashSet<tCC_TemporalCruceDoc>();
            this.tCC_TempTransaccionesComerciales = new HashSet<tCC_TempTransaccionesComerciales>();
            this.tCP_CargosCab = new HashSet<tCP_CargosCab>();
            this.tCP_CargosCabReembolso = new HashSet<tCP_CargosCabReembolso>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tCP_DescargosCab1 = new HashSet<tCP_DescargosCab>();
            this.tCP_SustentoSRI = new HashSet<tCP_SustentoSRI>();
            this.tCP_TemporalCruceDoc = new HashSet<tCP_TemporalCruceDoc>();
            this.tGN_Secuenciales = new HashSet<tGN_Secuenciales>();
        }
    
        public int IdTipoDocumento { get; set; }
        public string CodigoDocumentoInterno { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> RegistroManual { get; set; }
        public string CodigoDocumentoSRI { get; set; }
        public Nullable<bool> EsCargo { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> IdGrupoComprobante { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public string TipoDocumentoInterno { get; set; }
        public Nullable<bool> NumeraAutomatico { get; set; }
        public Nullable<int> TipoImpuesto1 { get; set; }
        public Nullable<int> TipoImpuesto2 { get; set; }
        public Nullable<int> TipoImpuesto3 { get; set; }
        public Nullable<int> TipoImpuesto4 { get; set; }
        public string TipoDocumentoSRI { get; set; }
        public string TipoDocumentoProceso { get; set; }
        public Nullable<bool> EsSocietario { get; set; }
        public Nullable<int> IdCodigoConciliacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string TipoDocumento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATS_Compras> ATS_Compras { get; set; }
        public virtual tCB_CodigosConciliacion tCB_CodigosConciliacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCabRelacionPagoTemp> tCC_DescargosCabRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TemporalCruceDoc> tCC_TemporalCruceDoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TempTransaccionesComerciales> tCC_TempTransaccionesComerciales { get; set; }
        public virtual tCG_GrupoComprobantes tCG_GrupoComprobantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCab> tCP_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCabReembolso> tCP_CargosCabReembolso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_SustentoSRI> tCP_SustentoSRI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_TemporalCruceDoc> tCP_TemporalCruceDoc { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Secuenciales> tGN_Secuenciales { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos1 { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos2 { get; set; }
        public virtual tGN_TiposImpuestos tGN_TiposImpuestos3 { get; set; }
    }
}