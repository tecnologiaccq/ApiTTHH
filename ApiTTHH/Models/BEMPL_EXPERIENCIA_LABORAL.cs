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
    
    public partial class BEMPL_EXPERIENCIA_LABORAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BEMPL_EXPERIENCIA_LABORAL()
        {
            this.BEMPL_REFERENCIAS_LABORA = new HashSet<BEMPL_REFERENCIAS_LABORA>();
        }
    
        public int IdExperiencia { get; set; }
        public Nullable<int> IdPostulante { get; set; }
        public string Empresa { get; set; }
        public Nullable<int> MesIni { get; set; }
        public Nullable<int> AnioInicio { get; set; }
        public Nullable<int> MesFin { get; set; }
        public Nullable<int> AnioFin { get; set; }
        public string MesInicioDesc { get; set; }
        public string MesFinDesc { get; set; }
        public Nullable<bool> AlPresente { get; set; }
        public string ResumenActividades { get; set; }
        public Nullable<int> PersonasACargo { get; set; }
        public string Puesto { get; set; }
        public Nullable<bool> PresupuestoVentasMensual { get; set; }
    
        public virtual BEMPL_DATOSPOSTULANTE BEMPL_DATOSPOSTULANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BEMPL_REFERENCIAS_LABORA> BEMPL_REFERENCIAS_LABORA { get; set; }
    }
}