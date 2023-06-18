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
    
    public partial class tGN_Direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_Direcciones()
        {
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
        }
    
        public int IdDireccion { get; set; }
        public int IdPersona { get; set; }
        public Nullable<int> IdTipoDireccion { get; set; }
        public Nullable<int> IdParroquia { get; set; }
        public Nullable<int> IdLocalidad { get; set; }
        public string CallePrincipal { get; set; }
        public string InterseccionPrincipal { get; set; }
        public string InterseccionSecundaria { get; set; }
        public string Numero { get; set; }
        public string NumeroReferencia { get; set; }
        public string Referencia { get; set; }
        public Nullable<bool> Principal { get; set; }
        public Nullable<double> Longitud { get; set; }
        public Nullable<double> Latitud { get; set; }
        public byte[] FotoCroquis { get; set; }
        public byte[] FotoLocal { get; set; }
        public Nullable<int> IdTipoCobro { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> cod_afil { get; set; }
        public string DireccionCompleta { get; set; }
        public Nullable<int> IdCRM { get; set; }
        public Nullable<int> IdZona { get; set; }
        public Nullable<bool> IsNewDesdeSync { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        public virtual tGN_Localidad tGN_Localidad { get; set; }
        public virtual tGN_Parroquias tGN_Parroquias { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tGN_TiposDirecciones tGN_TiposDirecciones { get; set; }
    }
}
