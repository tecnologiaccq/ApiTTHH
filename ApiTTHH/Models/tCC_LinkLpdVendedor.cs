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
    
    public partial class tCC_LinkLpdVendedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCC_LinkLpdVendedor()
        {
            this.Lpd_ContactoNuevo = new HashSet<Lpd_ContactoNuevo>();
            this.tGN_ContactoPersona = new HashSet<tGN_ContactoPersona>();
        }
    
        public int IdLinkLpdVendedor { get; set; }
        public int IdVendedor { get; set; }
        public int CodigoSeguridad { get; set; }
        public string NormalLink { get; set; }
        public string ShortLink { get; set; }
        public bool Estado { get; set; }
        public System.DateTime FechaGeneracion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lpd_ContactoNuevo> Lpd_ContactoNuevo { get; set; }
        public virtual tCC_Vendedores tCC_Vendedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_ContactoPersona> tGN_ContactoPersona { get; set; }
    }
}
