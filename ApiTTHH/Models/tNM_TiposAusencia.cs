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
    
    public partial class tNM_TiposAusencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_TiposAusencia()
        {
            this.tNM_SolicitudPermiso = new HashSet<tNM_SolicitudPermiso>();
            this.tNM_SolicitudVacacionesCab = new HashSet<tNM_SolicitudVacacionesCab>();
        }
    
        public int IdAusencia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> ApruebaJefe { get; set; }
        public Nullable<bool> ApruebaTTHH { get; set; }
        public Nullable<bool> AplicaSoloDia { get; set; }
        public Nullable<bool> AplicaHoras { get; set; }
        public Nullable<int> MaximaHorasPermitidasDia { get; set; }
        public Nullable<bool> AplicaRangoFechas { get; set; }
        public Nullable<bool> IncluyeFinesDeSemana { get; set; }
        public Nullable<int> NumeroDiasFinSemanaPermitidos { get; set; }
        public Nullable<bool> RequiereJustificacion { get; set; }
        public Nullable<int> MinimoNumeroDeSoporte { get; set; }
        public Nullable<bool> AplicaRecuperacionHoras { get; set; }
        public Nullable<int> MaximoHorasARecuperarDia { get; set; }
        public Nullable<int> MaximoDiasSolicitarVacaciones { get; set; }
        public Nullable<int> MinimoDiasSolicitarVacaciones { get; set; }
        public Nullable<bool> AplicaDiasVacacionFeriado { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string ruta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudPermiso> tNM_SolicitudPermiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudVacacionesCab> tNM_SolicitudVacacionesCab { get; set; }
    }
}
