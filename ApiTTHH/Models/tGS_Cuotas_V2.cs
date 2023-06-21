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
    
    public partial class tGS_Cuotas_V2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGS_Cuotas_V2()
        {
            this.tCC_CargosCab = new HashSet<tCC_CargosCab>();
            this.tCC_CargosDet = new HashSet<tCC_CargosDet>();
            this.tCC_DescargosDet = new HashSet<tCC_DescargosDet>();
        }
    
        public int IdCuota { get; set; }
        public int IdSocio { get; set; }
        public int NumeroMeses { get; set; }
        public System.DateTime FechaCuota { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public decimal ValorCuota { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal ValorPorcentajeIva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorTotal { get; set; }
        public string Descripcion { get; set; }
        public bool ExcluidoParaFacturacionSocial { get; set; }
        public bool NoEstandarizada { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public bool FacturaGenerada { get; set; }
        public Nullable<int> IdAsientoContableDevengacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosCab> tCC_CargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CargosDet> tCC_CargosDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosDet> tCC_DescargosDet { get; set; }
        public virtual tCG_AsientosContableCab tCG_AsientosContableCab { get; set; }
        public virtual tGS_Socios tGS_Socios { get; set; }
    }
}