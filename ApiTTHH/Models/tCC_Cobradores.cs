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
    
    public partial class tCC_Cobradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCC_Cobradores()
        {
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_CargosCab1 = new HashSet<tCC_CargosCab>();
            this.tCC_Clientes = new HashSet<tCC_Clientes>();
            this.tCC_Clientes1 = new HashSet<tCC_Clientes>();
            this.tCC_CobradoresCajas = new HashSet<tCC_CobradoresCajas>();
            this.tCC_CruceDocumentos = new HashSet<tCC_CruceDocumentos>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCC_DescargosCabRelacionPagoTemp = new HashSet<tCC_DescargosCabRelacionPagoTemp>();
            this.tCC_TempTransaccionesComerciales = new HashSet<tCC_TempTransaccionesComerciales>();
            this.tGN_BancosCCQ = new HashSet<tGN_BancosCCQ>();
            this.tGN_TarjetaCredito = new HashSet<tGN_TarjetaCredito>();
            this.tGS_AuditoriaSocio = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_AuditoriaSocio1 = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_Cuotas = new HashSet<tGS_Cuotas>();
            this.tGS_CuotasAfiliacion = new HashSet<tGS_CuotasAfiliacion>();
            this.tGS_Socios = new HashSet<tGS_Socios>();
            this.tGS_Socios1 = new HashSet<tGS_Socios>();
            this.tGS_SociosPreregistro = new HashSet<tGS_SociosPreregistro>();
            this.tGS_SociosPreregistro1 = new HashSet<tGS_SociosPreregistro>();
        }
    
        public int IdCobrador { get; set; }
        public Nullable<int> IdPersonas { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdTipoCobrador { get; set; }
        public string TipoRelacion { get; set; }
        public string TelefonoConvencional { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }
        public Nullable<short> RutaCobranzas { get; set; }
        public Nullable<short> MetodoComision { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string cod_cobrador { get; set; }
        public Nullable<int> CodigoCobrador { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes1 { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tCC_TiposCobrador tCC_TiposCobrador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CobradoresCajas> tCC_CobradoresCajas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CruceDocumentos> tCC_CruceDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCabRelacionPagoTemp> tCC_DescargosCabRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TempTransaccionesComerciales> tCC_TempTransaccionesComerciales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_BancosCCQ> tGN_BancosCCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_TarjetaCredito> tGN_TarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Cuotas> tGS_Cuotas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_CuotasAfiliacion> tGS_CuotasAfiliacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro1 { get; set; }
    }
}
