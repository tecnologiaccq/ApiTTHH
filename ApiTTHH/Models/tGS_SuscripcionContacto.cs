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
    
    public partial class tGS_SuscripcionContacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGS_SuscripcionContacto()
        {
            this.tGS_HistoricoSuscripcionContacto = new HashSet<tGS_HistoricoSuscripcionContacto>();
        }
    
        public int IdSuscripcionContacto { get; set; }
        public int IdContactoPersona { get; set; }
        public int IdTipoSuscripcion { get; set; }
        public bool ActivarEnvio { get; set; }
        public string Comentario { get; set; }
        public string eMailValidacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public Nullable<int> IdCliente { get; set; }
    
        public virtual tCC_Clientes tCC_Clientes { get; set; }
        public virtual tGN_ContactoPersona tGN_ContactoPersona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_HistoricoSuscripcionContacto> tGS_HistoricoSuscripcionContacto { get; set; }
        public virtual tGS_TipoSuscripcion tGS_TipoSuscripcion { get; set; }
    }
}
