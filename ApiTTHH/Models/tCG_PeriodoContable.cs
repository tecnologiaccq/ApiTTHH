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
    
    public partial class tCG_PeriodoContable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCG_PeriodoContable()
        {
            this.ATS_Compras = new HashSet<ATS_Compras>();
            this.tAF_Depreciacion = new HashSet<tAF_Depreciacion>();
            this.tCC_AsientosXCargos = new HashSet<tCC_AsientosXCargos>();
            this.tCC_AsientosXCruces = new HashSet<tCC_AsientosXCruces>();
            this.tCC_AsientosXDescargos = new HashSet<tCC_AsientosXDescargos>();
            this.tCC_AsientosXDescargosDevolucionesParcialesCAM = new HashSet<tCC_AsientosXDescargosDevolucionesParcialesCAM>();
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCC_DescargosCabRelacionPagoTemp = new HashSet<tCC_DescargosCabRelacionPagoTemp>();
            this.tCC_RelacionPago = new HashSet<tCC_RelacionPago>();
            this.tCC_TempTransaccionesComerciales = new HashSet<tCC_TempTransaccionesComerciales>();
            this.tCG_AsientosContableCab = new HashSet<tCG_AsientosContableCab>();
            this.tCG_IntAsientosContableCab = new HashSet<tCG_IntAsientosContableCab>();
            this.tCG_PeriodoContable1 = new HashSet<tCG_PeriodoContable>();
            this.tCG_SaldoMayor = new HashSet<tCG_SaldoMayor>();
            this.tCG_SecuencialesComprobantes = new HashSet<tCG_SecuencialesComprobantes>();
            this.tCP_AsientosXCargos = new HashSet<tCP_AsientosXCargos>();
            this.tCP_AsientosXCruces = new HashSet<tCP_AsientosXCruces>();
            this.tCP_AsientosXDescargos = new HashSet<tCP_AsientosXDescargos>();
            this.tCP_CargosCab = new HashSet<tCP_CargosCab>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tGN_Empresas1 = new HashSet<tGN_Empresas>();
            this.tGS_Cuotas = new HashSet<tGS_Cuotas>();
            this.tIV_Saldos = new HashSet<tIV_Saldos>();
        }
    
        public int IdPeriodoContable { get; set; }
        public int IdEmpresa { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string Descripcion { get; set; }
        public int IdEstadoPeriodoContable { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<System.DateTime> SecuencialPeriodo { get; set; }
        public Nullable<int> IdPeriodoContableAnterior { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATS_Compras> ATS_Compras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Depreciacion> tAF_Depreciacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXCargos> tCC_AsientosXCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXCruces> tCC_AsientosXCruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXDescargos> tCC_AsientosXDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_AsientosXDescargosDevolucionesParcialesCAM> tCC_AsientosXDescargosDevolucionesParcialesCAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCabRelacionPagoTemp> tCC_DescargosCabRelacionPagoTemp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_RelacionPago> tCC_RelacionPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_TempTransaccionesComerciales> tCC_TempTransaccionesComerciales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_AsientosContableCab> tCG_AsientosContableCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_IntAsientosContableCab> tCG_IntAsientosContableCab { get; set; }
        public virtual tCT_EstadoPeriodoContable tCT_EstadoPeriodoContable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_PeriodoContable> tCG_PeriodoContable1 { get; set; }
        public virtual tCG_PeriodoContable tCG_PeriodoContable2 { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_SaldoMayor> tCG_SaldoMayor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_SecuencialesComprobantes> tCG_SecuencialesComprobantes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXCargos> tCP_AsientosXCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXCruces> tCP_AsientosXCruces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_AsientosXDescargos> tCP_AsientosXDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosCab> tCP_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Empresas> tGN_Empresas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGS_Cuotas> tGS_Cuotas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tIV_Saldos> tIV_Saldos { get; set; }
    }
}
