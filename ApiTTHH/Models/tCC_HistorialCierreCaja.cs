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
    
    public partial class tCC_HistorialCierreCaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCC_HistorialCierreCaja()
        {
            this.tCC_CajaIngresoCheque = new HashSet<tCC_CajaIngresoCheque>();
            this.tCC_CajaIngresoDepositoTransferencia = new HashSet<tCC_CajaIngresoDepositoTransferencia>();
            this.tCC_CajaIngresoEfectivo = new HashSet<tCC_CajaIngresoEfectivo>();
            this.tCC_CajaIngresoRetenciones = new HashSet<tCC_CajaIngresoRetenciones>();
            this.tCC_CajaIngresoTarjetaCredito = new HashSet<tCC_CajaIngresoTarjetaCredito>();
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
        }
    
        public int IdHistorialCierreCaja { get; set; }
        public int IdCaja { get; set; }
        public Nullable<int> IdAsientoContableCab { get; set; }
        public int IdGrupoComprobante { get; set; }
        public int NumeroComprobante { get; set; }
        public decimal ValorEfectivo { get; set; }
        public decimal ValorCheque { get; set; }
        public decimal ValorDeposito { get; set; }
        public decimal ValorTransferencia { get; set; }
        public decimal ValorTarjeta { get; set; }
        public decimal ValorRetencion { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public string NumeroDeposito { get; set; }
        public Nullable<bool> EsDepositoDefinitivo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<System.DateTime> FechaDeposito { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    
        public virtual tCC_Caja tCC_Caja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoCheque> tCC_CajaIngresoCheque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoDepositoTransferencia> tCC_CajaIngresoDepositoTransferencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoEfectivo> tCC_CajaIngresoEfectivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoRetenciones> tCC_CajaIngresoRetenciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCredito> tCC_CajaIngresoTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tCG_GrupoComprobantes tCG_GrupoComprobantes { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
    }
}
