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
    
    public partial class tAF_Desincorporaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tAF_Desincorporaciones()
        {
            this.tAF_AnexosDesincorporaciones = new HashSet<tAF_AnexosDesincorporaciones>();
        }
    
        public int IdDesincorporacion { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdActivo { get; set; }
        public Nullable<int> CodigoActivo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdTipoActivo { get; set; }
        public Nullable<int> IdCentroCostos { get; set; }
        public Nullable<int> PeriodosxDepreciar { get; set; }
        public Nullable<decimal> ValorActual { get; set; }
        public Nullable<decimal> ValorRescate { get; set; }
        public string Notaria { get; set; }
        public string NroDocumentoNotaria { get; set; }
        public Nullable<bool> Procesado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_AnexosDesincorporaciones> tAF_AnexosDesincorporaciones { get; set; }
        public virtual tAF_MaestroActivos tAF_MaestroActivos { get; set; }
        public virtual tGN_CentrosCostos tGN_CentrosCostos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tAF_TiposActivos tAF_TiposActivos { get; set; }
    }
}
