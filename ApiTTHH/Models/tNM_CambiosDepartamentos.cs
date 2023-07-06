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
    
    public partial class tNM_CambiosDepartamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_CambiosDepartamentos()
        {
            this.tNM_HistoriaLaboral = new HashSet<tNM_HistoriaLaboral>();
        }
    
        public long IdCambioDepartamento { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<int> IdDepartamentoAnterior { get; set; }
        public Nullable<int> IdDepartamentoNuevo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tNM_Departamentos tNM_Departamentos { get; set; }
        public virtual tNM_Departamentos tNM_Departamentos1 { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_HistoriaLaboral> tNM_HistoriaLaboral { get; set; }
    }
}
