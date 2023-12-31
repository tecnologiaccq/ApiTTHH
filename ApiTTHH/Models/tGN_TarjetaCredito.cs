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
    
    public partial class tGN_TarjetaCredito
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_TarjetaCredito()
        {
            this.tCC_CajaIngresoTarjetaCredito = new HashSet<tCC_CajaIngresoTarjetaCredito>();
            this.tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp = new HashSet<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp>();
            this.tCC_Clientes = new HashSet<tCC_Clientes>();
            this.tCC_ConfirmacionTarjetasAuxiliar = new HashSet<tCC_ConfirmacionTarjetasAuxiliar>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCC_FallosDebitoTarjetas = new HashSet<tCC_FallosDebitoTarjetas>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tGS_AuditoriaSocio = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_AuditoriaSocio1 = new HashSet<tGS_AuditoriaSocio>();
            this.tGS_Socios = new HashSet<tGS_Socios>();
            this.tGS_SociosPreregistro = new HashSet<tGS_SociosPreregistro>();
        }
    
        public int IdTarjetaCredito { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdCobrador { get; set; }
        public Nullable<int> IdPlanCuentaEmpresa { get; set; }
        public Nullable<int> IdPlanCuentaEmpresaBancoDebitoAut { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Numero { get; set; }
        public int NumeroVoucherActual { get; set; }
        public Nullable<int> IdModuloErp { get; set; }
        public Nullable<decimal> DescuentoEnPago { get; set; }
        public Nullable<bool> AplicaDebitoAutomatico { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdPlanCuentaEmpresaComision { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCredito> tCC_CajaIngresoTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp> tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes { get; set; }
        public virtual tCC_Clientes tCC_Clientes1 { get; set; }
        public virtual tCC_Cobradores tCC_Cobradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_ConfirmacionTarjetasAuxiliar> tCC_ConfirmacionTarjetasAuxiliar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_FallosDebitoTarjetas> tCC_FallosDebitoTarjetas { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa1 { get; set; }
        public virtual tCG_PlanCuentasEmpresa tCG_PlanCuentasEmpresa2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_ModulosErp tGN_ModulosErp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_AuditoriaSocio> tGS_AuditoriaSocio1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro { get; set; }
    }
}
