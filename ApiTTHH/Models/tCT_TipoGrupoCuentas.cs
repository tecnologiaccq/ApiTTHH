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
    
    public partial class tCT_TipoGrupoCuentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCT_TipoGrupoCuentas()
        {
            this.tCG_GrupoCuentas = new HashSet<tCG_GrupoCuentas>();
        }
    
        public int IdTipoGrupoCuenta { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_GrupoCuentas> tCG_GrupoCuentas { get; set; }
    }
}