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
    
    public partial class tCEC_DireccionesEventosCursos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCEC_DireccionesEventosCursos()
        {
            this.tCEC_UbicacionesEventosCursos = new HashSet<tCEC_UbicacionesEventosCursos>();
        }
    
        public int IdDireccionEventoCurso { get; set; }
        public string CallePrincipal { get; set; }
        public string Numero { get; set; }
        public string Interseccion { get; set; }
        public string Referencia { get; set; }
        public string UrlDireccion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
        public string DireccionCompleta { get; set; }
        public Nullable<short> cod_direccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCEC_UbicacionesEventosCursos> tCEC_UbicacionesEventosCursos { get; set; }
    }
}
