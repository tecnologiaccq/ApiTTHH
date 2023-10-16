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
    
    public partial class tNM_Colaboradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNM_Colaboradores()
        {
            this.tNM_BasesCalculadas = new HashSet<tNM_BasesCalculadas>();
            this.tNM_BitacoraColaboradores = new HashSet<tNM_BitacoraColaboradores>();
            this.tNM_BitacoraColaboradores1 = new HashSet<tNM_BitacoraColaboradores>();
            this.tNM_CalendarioNominasEnvioMail = new HashSet<tNM_CalendarioNominasEnvioMail>();
            this.tNM_CambiosDepartamentos = new HashSet<tNM_CambiosDepartamentos>();
            this.tNM_CapacitacionColaborador = new HashSet<tNM_CapacitacionColaborador>();
            this.tNM_Colaboradores1 = new HashSet<tNM_Colaboradores>();
            this.tNM_ColaboradoresAuditoria = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_ColaboradoresAuditoria1 = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_ColaboradoresAuditoria2 = new HashSet<tNM_ColaboradoresAuditoria>();
            this.tNM_CompetenciasColaborador = new HashSet<tNM_CompetenciasColaborador>();
            this.tNM_ConceptosFijos = new HashSet<tNM_ConceptosFijos>();
            this.tNM_DatosBiometrico = new HashSet<tNM_DatosBiometrico>();
            this.tNM_Dependientes = new HashSet<tNM_Dependientes>();
            this.tNM_Distribucion = new HashSet<tNM_Distribucion>();
            this.tNM_EntradasSalidas = new HashSet<tNM_EntradasSalidas>();
            this.tNM_EstadosCuentaColaborador = new HashSet<tNM_EstadosCuentaColaborador>();
            this.tNM_FormularioGP = new HashSet<tNM_FormularioGP>();
            this.tNM_GruposArchivoBancoCalendarioNomina = new HashSet<tNM_GruposArchivoBancoCalendarioNomina>();
            this.tNM_HistoriaLaboral = new HashSet<tNM_HistoriaLaboral>();
            this.tNM_HistorialCargos = new HashSet<tNM_HistorialCargos>();
            this.tNM_HistorialConceptosFijos = new HashSet<tNM_HistorialConceptosFijos>();
            this.tNM_HistorialVacaciones = new HashSet<tNM_HistorialVacaciones>();
            this.tNM_IngresosBeneficiosColaborador = new HashSet<tNM_IngresosBeneficiosColaborador>();
            this.tNM_LiquidacionLaboral = new HashSet<tNM_LiquidacionLaboral>();
            this.tNM_NominaDefinitiva = new HashSet<tNM_NominaDefinitiva>();
            this.tNM_NominaPreliminar = new HashSet<tNM_NominaPreliminar>();
            this.tNM_PagosFueraNomina = new HashSet<tNM_PagosFueraNomina>();
            this.tNM_Solicitudes = new HashSet<tNM_Solicitudes>();
            this.tNM_Solicitudes1 = new HashSet<tNM_Solicitudes>();
            this.tNM_SolicitudPermiso = new HashSet<tNM_SolicitudPermiso>();
            this.tNM_SolicitudPermiso1 = new HashSet<tNM_SolicitudPermiso>();
            this.tNM_SolicitudVacacionesCab = new HashSet<tNM_SolicitudVacacionesCab>();
            this.tNM_SolicitudVacacionesCab1 = new HashSet<tNM_SolicitudVacacionesCab>();
            this.tNM_Vacaciones = new HashSet<tNM_Vacaciones>();
            this.tNM_Vacaciones1 = new HashSet<tNM_Vacaciones>();
            this.tNM_ValidacionNomina = new HashSet<tNM_ValidacionNomina>();
            this.tNM_Variaciones = new HashSet<tNM_Variaciones>();
        }
    
        public int IdColaborador { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdTipoDiscapacidad { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidad { get; set; }
        public Nullable<int> IdTipoColaborador { get; set; }
        public Nullable<int> IdClaseColaborador { get; set; }
        public Nullable<int> IdCategoriaColaborador { get; set; }
        public Nullable<int> IdGrupoColaborador { get; set; }
        public Nullable<int> IdProyectoColaborador { get; set; }
        public Nullable<int> IdProgramaColaborador { get; set; }
        public Nullable<int> IdTurno { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdSupervisor { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdTipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> IdMedioPago { get; set; }
        public Nullable<int> IdTipoContrato { get; set; }
        public string Usuario { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public bool EsSupervisor { get; set; }
        public bool ApruebaTH { get; set; }
        public Nullable<bool> EsNominista { get; set; }
        public Nullable<bool> EsFinanciero { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string NumeroDiscapacitado { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdSectorialIESS { get; set; }
        public Nullable<int> IdTitulo { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdMotivoEgreso { get; set; }
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public Nullable<bool> EsReelegible { get; set; }
        public Nullable<int> IdCategoriaOcupacional { get; set; }
        public Nullable<int> IdBiometrico { get; set; }
        public Nullable<long> HoraEntrada { get; set; }
        public Nullable<long> HoraSalida { get; set; }
        public Nullable<long> TiempoAlmuerzo { get; set; }
        public Nullable<int> IdCategoria1 { get; set; }
        public Nullable<int> IdCategoria2 { get; set; }
        public Nullable<int> IdCategoria3 { get; set; }
        public Nullable<int> IdCategoria4 { get; set; }
        public Nullable<int> IdCategoria5 { get; set; }
        public string Identificacion { get; set; }
        public string ApellidosNombres { get; set; }
        public string eMail { get; set; }
        public Nullable<decimal> HorasSemanalesJornadaParcial { get; set; }
        public Nullable<System.DateTime> FechaJubilacion { get; set; }
        public Nullable<bool> TieneBeneficioGalapagos { get; set; }
        public string CodigoEstablecimiento { get; set; }
        public Nullable<bool> ResideEnElExterior { get; set; }
        public Nullable<bool> TieneConvenioDobleImposicion { get; set; }
        public Nullable<int> CondicionDiscapacidad { get; set; }
        public Nullable<int> TipoIdDiscapacitado { get; set; }
        public string IdDiscapacitado { get; set; }
        public Nullable<bool> TieneSalarioNeto { get; set; }
        public Nullable<int> IdTipoRelacion { get; set; }
        public Nullable<System.DateTime> FechaDefuncion { get; set; }
        public Nullable<bool> EnviarCorreoRolPago { get; set; }
        public string nickname { get; set; }
        public Nullable<int> IdTipoSangre { get; set; }
        public string UrlFoto { get; set; }
        public int CargasLEFAM { get; set; }
        public string NumeroTelefonoAuth2F { get; set; }
        public bool SegundoFactor { get; set; }
    
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tGN_Personas tGN_Personas { get; set; }
        public virtual tGN_TipoSangre tGN_TipoSangre { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        public virtual tNM_Areas tNM_Areas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_BasesCalculadas> tNM_BasesCalculadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_BitacoraColaboradores> tNM_BitacoraColaboradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_BitacoraColaboradores> tNM_BitacoraColaboradores1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CalendarioNominasEnvioMail> tNM_CalendarioNominasEnvioMail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CambiosDepartamentos> tNM_CambiosDepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CapacitacionColaborador> tNM_CapacitacionColaborador { get; set; }
        public virtual tNM_Cargos tNM_Cargos { get; set; }
        public virtual tNM_CategoriasColaboradores tNM_CategoriasColaboradores { get; set; }
        public virtual tNM_CategoriasOcupacionales tNM_CategoriasOcupacionales { get; set; }
        public virtual tNM_ClasesColaboradores tNM_ClasesColaboradores { get; set; }
        public virtual tNM_MotivosEgreso tNM_MotivosEgreso { get; set; }
        public virtual tNM_SectorialIESS tNM_SectorialIESS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Colaboradores> tNM_Colaboradores1 { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores2 { get; set; }
        public virtual tNM_TiposRelacion tNM_TiposRelacion { get; set; }
        public virtual tNM_Titulos tNM_Titulos { get; set; }
        public virtual tNM_Departamentos tNM_Departamentos { get; set; }
        public virtual tNM_EstadosColaboradores tNM_EstadosColaboradores { get; set; }
        public virtual tNM_GruposColaboradores tNM_GruposColaboradores { get; set; }
        public virtual tNM_MediosPago tNM_MediosPago { get; set; }
        public virtual tNM_ProgramasColaboradores tNM_ProgramasColaboradores { get; set; }
        public virtual tNM_ProyectosColaboradores tNM_ProyectosColaboradores { get; set; }
        public virtual tNM_Sucursales tNM_Sucursales { get; set; }
        public virtual tNM_TiposColaboradores tNM_TiposColaboradores { get; set; }
        public virtual tNM_TiposContrato tNM_TiposContrato { get; set; }
        public virtual tNM_TiposDiscapacidad tNM_TiposDiscapacidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ColaboradoresAuditoria> tNM_ColaboradoresAuditoria2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_CompetenciasColaborador> tNM_CompetenciasColaborador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ConceptosFijos> tNM_ConceptosFijos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_DatosBiometrico> tNM_DatosBiometrico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Dependientes> tNM_Dependientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Distribucion> tNM_Distribucion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_EntradasSalidas> tNM_EntradasSalidas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_EstadosCuentaColaborador> tNM_EstadosCuentaColaborador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_FormularioGP> tNM_FormularioGP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_GruposArchivoBancoCalendarioNomina> tNM_GruposArchivoBancoCalendarioNomina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_HistoriaLaboral> tNM_HistoriaLaboral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_HistorialCargos> tNM_HistorialCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_HistorialConceptosFijos> tNM_HistorialConceptosFijos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_HistorialVacaciones> tNM_HistorialVacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_IngresosBeneficiosColaborador> tNM_IngresosBeneficiosColaborador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_LiquidacionLaboral> tNM_LiquidacionLaboral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_NominaDefinitiva> tNM_NominaDefinitiva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_NominaPreliminar> tNM_NominaPreliminar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_PagosFueraNomina> tNM_PagosFueraNomina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Solicitudes> tNM_Solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Solicitudes> tNM_Solicitudes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudPermiso> tNM_SolicitudPermiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudPermiso> tNM_SolicitudPermiso1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudVacacionesCab> tNM_SolicitudVacacionesCab { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_SolicitudVacacionesCab> tNM_SolicitudVacacionesCab1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Vacaciones> tNM_Vacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Vacaciones> tNM_Vacaciones1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_ValidacionNomina> tNM_ValidacionNomina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tNM_Variaciones> tNM_Variaciones { get; set; }
    }
}
