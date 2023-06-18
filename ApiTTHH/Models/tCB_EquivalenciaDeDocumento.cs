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
    
    public partial class tCB_EquivalenciaDeDocumento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCB_EquivalenciaDeDocumento()
        {
            this.tCB_EstadoCuentaBancoGeneral = new HashSet<tCB_EstadoCuentaBancoGeneral>();
        }
    
        public int IdEquivalenciaDeDocumento { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public string CodigoBanco { get; set; }
        public Nullable<int> CodigoInterno { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCB_CodigosConciliacion tCB_CodigosConciliacion { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_EstadoCuentaBancoGeneral> tCB_EstadoCuentaBancoGeneral { get; set; }
    }
}
