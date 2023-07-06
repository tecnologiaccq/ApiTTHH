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
    
    public partial class tNM_ProyectosColaboradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_ProyectosColaboradores()
        {
            this.tNM_CalendarioNominas = new HashSet<tNM_CalendarioNominas>();
            this.tNM_Colaboradores = new HashSet<tNM_Colaboradores>();
            this.tNM_ColaboradoresAuditoria = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_ColaboradoresAuditoria1 = new HashSet<tNM_ColaboradoresAuditoria>();
        }
    
        public int IdProyectoColaborador { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CalendarioNominas> tNM_CalendarioNominas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Colaboradores> tNM_Colaboradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria1 { get; set; }
    }
}
