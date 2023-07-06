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
    
    public partial class tCEC_Instructores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCEC_Instructores()
        {
            this.tCEC_EventosCursosXDictar = new HashSet<tCEC_EventosCursosXDictar>();
            this.tCEC_HabilidadesInstructores = new HashSet<tCEC_HabilidadesInstructores>();
            this.tCEC_HistorialNovedadesInstructor = new HashSet<tCEC_HistorialNovedadesInstructor>();
        }
    
        public int IdInstructor { get; set; }
        public int IdPersona { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<System.DateTime> FechaInicioActividades { get; set; }
        public Nullable<int> IdTipoDiscapacidad { get; set; }
        public Nullable<int> IdCondicionDiscapacidad { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidad { get; set; }
        public string NumeroCarnetConadis { get; set; }
        public Nullable<int> IdModalidadesContratacion { get; set; }
        public Nullable<short> cod_instructor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_EventosCursosXDictar> tCEC_EventosCursosXDictar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_HabilidadesInstructores> tCEC_HabilidadesInstructores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_HistorialNovedadesInstructor> tCEC_HistorialNovedadesInstructor { get; set; }
        public virtual tCEC_Instructores tCEC_Instructores1 { get; set; }
        public virtual tCEC_Instructores tCEC_Instructores2 { get; set; }
        public virtual tCEC_ModalidadesContratacion tCEC_ModalidadesContratacion { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tNM_CondicionDiscapacidad tNM_CondicionDiscapacidad { get; set; }
        public virtual tNM_TiposDiscapacidad tNM_TiposDiscapacidad { get; set; }
    }
}
