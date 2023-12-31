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
    
    public partial class tCG_PlanCuentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCG_PlanCuentas()
        {
            this.tAF_AsientosContables = new HashSet<tAF_AsientosContables>();
            this.tCG_PlanCuentasEmpresa = new HashSet<tCG_PlanCuentasEmpresa>();
        }
    
        public int IdPlanCuentas { get; set; }
        public int IdGrupoCuenta { get; set; }
        public string CodigoCuenta { get; set; }
        public string Descripcion { get; set; }
        public string CuentaDe { get; set; }
        public string MetodoDistribucion { get; set; }
        public Nullable<int> IdObjetoCosto1 { get; set; }
        public Nullable<int> IdObjetoCosto2 { get; set; }
        public Nullable<int> IdObjetoCosto3 { get; set; }
        public Nullable<int> IdCategoria1 { get; set; }
        public Nullable<int> IdCategoria2 { get; set; }
        public Nullable<int> IdCategoria3 { get; set; }
        public string CodigoDescripcion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string CCQ { get; set; }
        public string CEC { get; set; }
        public string MIO { get; set; }
        public bool EsCuentaConciliacion { get; set; }
        public Nullable<bool> EsEditableEnPresupuesto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_AsientosContables> tAF_AsientosContables { get; set; }
        public virtual tCG_GrupoCuentas tCG_GrupoCuentas { get; set; }
        public virtual tCG_ObjetosCostos tCG_ObjetosCostos { get; set; }
        public virtual tCG_ObjetosCostos tCG_ObjetosCostos1 { get; set; }
        public virtual tCG_ObjetosCostos tCG_ObjetosCostos2 { get; set; }
        public virtual tCT_Categoria1 tCT_Categoria1 { get; set; }
        public virtual tCT_Categoria2 tCT_Categoria2 { get; set; }
        public virtual tCT_Categoria3 tCT_Categoria3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_PlanCuentasEmpresa> tCG_PlanCuentasEmpresa { get; set; }
    }
}
