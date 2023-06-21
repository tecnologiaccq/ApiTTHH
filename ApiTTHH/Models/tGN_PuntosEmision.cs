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
    
    public partial class tGN_PuntosEmision
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_PuntosEmision()
        {
            this.tCC_Caja = new HashSet<tCC_Caja>();
            this.tGN_Secuenciales = new HashSet<tGN_Secuenciales>();
        }
    
        public int IdPuntoEmision { get; set; }
        public int IdEstablecimiento { get; set; }
        public string Alias { get; set; }
        public string Direccion { get; set; }
        public string PuntoEmision { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Caja> tCC_Caja { get; set; }
        public virtual tGN_Establecimientos tGN_Establecimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Secuenciales> tGN_Secuenciales { get; set; }
    }
}