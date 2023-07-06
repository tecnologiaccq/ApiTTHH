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
    
    public partial class tGN_Bancos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_Bancos()
        {
            this.tCB_EquivalenciaDeDocumento = new HashSet<tCB_EquivalenciaDeDocumento>();
            this.tCC_AutorizacionesCheque = new HashSet<tCC_AutorizacionesCheque>();
            this.tCC_CajaIngresoCheque = new HashSet<tCC_CajaIngresoCheque>();
            this.tCC_CajaIngresoChequeGarantia = new HashSet<tCC_CajaIngresoChequeGarantia>();
            this.tCC_CajaIngresoChequeRelacionPagoTemp = new HashSet<tCC_CajaIngresoChequeRelacionPagoTemp>();
            this.tCC_CajaIngresoTarjetaCredito = new HashSet<tCC_CajaIngresoTarjetaCredito>();
            this.tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp = new HashSet<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp>();
            this.tCC_Clientes = new HashSet<tCC_Clientes>();
            this.tCP_Proveedores = new HashSet<tCP_Proveedores>();
            this.tGN_BancosCCQ = new HashSet<tGN_BancosCCQ>();
            this.tGN_MediosPagos = new HashSet<tGN_MediosPagos>();
            this.tGN_ParametrosBancos = new HashSet<tGN_ParametrosBancos>();
            this.tGN_TiposCuentas = new HashSet<tGN_TiposCuentas>();
            this.tGS_AuditoriaSocio = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_AuditoriaSocio1 = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_Socios = new HashSet<tGS_Socios>();
            this.tGS_SociosPreregistro = new HashSet<tGS_SociosPreregistro>();
            this.tNM_Colaboradores = new HashSet<tNM_Colaboradores>();
            this.tNM_ColaboradoresAuditoria = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_ColaboradoresAuditoria1 = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_Empleados = new HashSet<tNM_Empleados>();
        }
    
        public int IdBanco { get; set; }
        public string CodigoBanco { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> CodigoBancoCompensacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCB_EquivalenciaDeDocumento> tCB_EquivalenciaDeDocumento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AutorizacionesCheque> tCC_AutorizacionesCheque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoCheque> tCC_CajaIngresoCheque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoChequeGarantia> tCC_CajaIngresoChequeGarantia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoChequeRelacionPagoTemp> tCC_CajaIngresoChequeRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCredito> tCC_CajaIngresoTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp> tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_Proveedores> tCP_Proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_BancosCCQ> tGN_BancosCCQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_MediosPagos> tGN_MediosPagos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_ParametrosBancos> tGN_ParametrosBancos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_TiposCuentas> tGN_TiposCuentas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Colaboradores> tNM_Colaboradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Empleados> tNM_Empleados { get; set; }
    }
}
