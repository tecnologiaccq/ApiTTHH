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
    
    public partial class Lpd_SuscripcionNuevoContacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lpd_SuscripcionNuevoContacto()
        {
            this.Lpd_HistoricoSuscripcionNuevoContacto = new HashSet<Lpd_HistoricoSuscripcionNuevoContacto>();
        }
    
        public int IdSuscripcionNuevoContacto { get; set; }
        public int IdContactoNuevo { get; set; }
        public int IdTipoSuscripcion { get; set; }
        public bool ActivarEnvio { get; set; }
        public string Comentario { get; set; }
        public string EmailValidation { get; set; }
        public string CreadoPor { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public bool Estado { get; set; }
    
        public virtual Lpd_ContactoNuevo Lpd_ContactoNuevo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lpd_HistoricoSuscripcionNuevoContacto> Lpd_HistoricoSuscripcionNuevoContacto { get; set; }
        public virtual tGS_TipoSuscripcion tGS_TipoSuscripcion { get; set; }
    }
}
