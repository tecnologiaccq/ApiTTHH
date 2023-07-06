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
    
    public partial class tGS_Cuotas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGS_Cuotas()
        {
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_TempTransaccionesComerciales = new HashSet<tCC_TempTransaccionesComerciales>();
        }
    
        public int IdCuota { get; set; }
        public int IdSocio { get; set; }
        public Nullable<int> IdTipoCuota { get; set; }
        public Nullable<int> IdFactura { get; set; }
        public Nullable<int> IdNotaCredito { get; set; }
        public Nullable<int> IdMedioPago { get; set; }
        public Nullable<int> IdCobrador { get; set; }
        public Nullable<int> IdVendedor { get; set; }
        public Nullable<int> IdFrecuenciaGeneracionCuota { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public Nullable<int> NroMeses { get; set; }
        public Nullable<System.DateTime> FechaCuota { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<decimal> ValorBruto { get; set; }
        public Nullable<decimal> ValorCuota { get; set; }
        public Nullable<decimal> ValorDescuento { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<decimal> SaldoCuotaAnticipada { get; set; }
        public Nullable<decimal> ValorCuotaDevengar { get; set; }
        public Nullable<decimal> ValorDescuentoDevengar { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Anulada { get; set; }
        public Nullable<bool> FacturaGenerada { get; set; }
        public Nullable<bool> NCGenerada { get; set; }
        public Nullable<int> IdCuotaOriginal { get; set; }
        public Nullable<bool> EsCuotaDevengada { get; set; }
        public Nullable<System.DateTime> FechaCondonacion { get; set; }
        public string ObservacionCondonacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string InformacionAdicionalFactura { get; set; }
        public Nullable<int> IdAsientoContable { get; set; }
        public Nullable<bool> EsCuotaManual { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        public virtual tCC_CargosCab tCC_CargosCab1 { get; set; }
        public virtual tCC_Cobradores tCC_Cobradores { get; set; }
        public virtual tCC_DescargosCab tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TempTransaccionesComerciales> tCC_TempTransaccionesComerciales { get; set; }
        public virtual tCC_TiposDocumentosCCQ tCC_TiposDocumentosCCQ { get; set; }
        public virtual tCC_Vendedores tCC_Vendedores { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable { get; set; }
        public virtual tGN_MediosPagos tGN_MediosPagos { get; set; }
        public virtual tGS_FrecuenciaGeneracionCuotas tGS_FrecuenciaGeneracionCuotas { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
    }
}
