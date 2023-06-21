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
    
    public partial class tNM_Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_Empleados()
        {
            this.tAF_Incorporaciones = new HashSet<tAF_Incorporaciones>();
            this.tCC_CajaSolicitudesEgresos = new HashSet<tCC_CajaSolicitudesEgresos>();
            this.tCC_DescargosCab = new HashSet<tCC_DescargosCab>();
            this.tCG_AsientosContableDet = new HashSet<tCG_AsientosContableDet>();
            this.tCP_CargosDet = new HashSet<tCP_CargosDet>();
            this.tCP_CuentasContablesDescargos = new HashSet<tCP_CuentasContablesDescargos>();
            this.tCP_DescargosCab = new HashSet<tCP_DescargosCab>();
            this.tCP_DescargosDet = new HashSet<tCP_DescargosDet>();
            this.tNM_Empleados1 = new HashSet<tNM_Empleados>();
        }
    
        public int IdEmpleado { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdTipoDiscapacidad { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidad { get; set; }
        public Nullable<int> IdTipoColaborador { get; set; }
        public Nullable<int> IdTurno { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdSupervisor { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdTipoCuenta { get; set; }
        public Nullable<int> NumeroCuenta { get; set; }
        public Nullable<int> IdMedioPago { get; set; }
        public Nullable<int> IdTipoContrato { get; set; }
        public string Usuario { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public bool EsSupervisor { get; set; }
        public bool ApruebaTH { get; set; }
        public Nullable<bool> EsNominista { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAF_Incorporaciones> tAF_Incorporaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaSolicitudesEgresos> tCC_CajaSolicitudesEgresos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_DescargosCab> tCC_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCG_AsientosContableDet> tCG_AsientosContableDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CargosDet> tCP_CargosDet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_CuentasContablesDescargos> tCP_CuentasContablesDescargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosCab> tCP_DescargosCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCP_DescargosDet> tCP_DescargosDet { get; set; }
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Cargos tGN_Cargos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Empleados> tNM_Empleados1 { get; set; }
        public virtual tNM_Empleados tNM_Empleados2 { get; set; }
    }
}