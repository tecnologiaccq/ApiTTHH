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
    
    public partial class tGN_TiposDirecciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_TiposDirecciones()
        {
            this.tGN_Direcciones = new HashSet<tGN_Direcciones>();
        }
    
        public int IdTipoDireccion { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string Nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Direcciones> tGN_Direcciones { get; set; }
    }
}
