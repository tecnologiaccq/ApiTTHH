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
    
    public partial class tPR_MaestroAjustes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPR_MaestroAjustes()
        {
            this.tPR_Ajustes = new HashSet<tPR_Ajustes>();
        }
    
        public int IdMaestroAjuste { get; set; }
        public int IdMaestroPresupuesto { get; set; }
        public string Descripcion { get; set; }
        public bool Procesado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPR_Ajustes> tPR_Ajustes { get; set; }
        public virtual tPR_MaestroPresupuesto tPR_MaestroPresupuesto { get; set; }
    }
}
