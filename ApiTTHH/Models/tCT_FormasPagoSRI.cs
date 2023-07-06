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
    
    public partial class tCT_FormasPagoSRI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCT_FormasPagoSRI()
        {
            this.tCC_CajaIngresoCheque = new HashSet<tCC_CajaIngresoCheque>();
            this.tCC_CajaIngresoChequeGarantia = new HashSet<tCC_CajaIngresoChequeGarantia>();
            this.tCC_CajaIngresoChequeRelacionPagoTemp = new HashSet<tCC_CajaIngresoChequeRelacionPagoTemp>();
            this.tCC_CajaIngresoDepositoTransferencia = new HashSet<tCC_CajaIngresoDepositoTransferencia>();
            this.tCC_CajaIngresoDepositoTransferenciaRelacionPagoTemp = new HashSet<tCC_CajaIngresoDepositoTransferenciaRelacionPagoTemp>();
            this.tCC_CajaIngresoEfectivo = new HashSet<tCC_CajaIngresoEfectivo>();
            this.tCC_CajaIngresoEfectivoRelacionPagoTemp = new HashSet<tCC_CajaIngresoEfectivoRelacionPagoTemp>();
            this.tCC_CajaIngresoTarjetaCredito = new HashSet<tCC_CajaIngresoTarjetaCredito>();
            this.tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp = new HashSet<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp>();
            this.tCC_Clientes = new HashSet<tCC_Clientes>();
            this.tGS_Socios = new HashSet<tGS_Socios>();
            this.tGS_SociosPreregistro = new HashSet<tGS_SociosPreregistro>();
        }
    
        public int IdFormaPagoSRI { get; set; }
        public string CodigoFormaPagoSRI { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoCheque> tCC_CajaIngresoCheque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoChequeGarantia> tCC_CajaIngresoChequeGarantia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoChequeRelacionPagoTemp> tCC_CajaIngresoChequeRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoDepositoTransferencia> tCC_CajaIngresoDepositoTransferencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoDepositoTransferenciaRelacionPagoTemp> tCC_CajaIngresoDepositoTransferenciaRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoEfectivo> tCC_CajaIngresoEfectivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoEfectivoRelacionPagoTemp> tCC_CajaIngresoEfectivoRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCredito> tCC_CajaIngresoTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp> tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_Clientes> tCC_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Socios> tGS_Socios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_SociosPreregistro> tGS_SociosPreregistro { get; set; }
    }
}
