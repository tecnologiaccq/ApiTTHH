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
    
    public partial class tNM_ColaboradoresAuditoria
    {
        public int IdColaboradorAuditoria { get; set; }
        public int IdColaborador { get; set; }
        public Nullable<int> IdDepartamentoAnterior { get; set; }
        public Nullable<int> IdDepartamentoNuevo { get; set; }
        public Nullable<int> IdTipoDiscapacidadAnterior { get; set; }
        public Nullable<int> IdTipoDiscapacidadNuevo { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidadAnterior { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidadNuevo { get; set; }
        public string NumeroDiscapacitadoAnterior { get; set; }
        public string NumeroDiscapacitadoNuevo { get; set; }
        public Nullable<int> IdTipoColaboradorAnterior { get; set; }
        public Nullable<int> IdTipoColaboradorNuevo { get; set; }
        public Nullable<int> IdClaseColaboradorAnterior { get; set; }
        public Nullable<int> IdClaseColaboradorNuevo { get; set; }
        public Nullable<int> IdCategoriaColaboradorAnterior { get; set; }
        public Nullable<int> IdCategoriaColaboradorNuevo { get; set; }
        public Nullable<int> IdGrupoColaboradorAnterior { get; set; }
        public Nullable<int> IdGrupoColaboradorNuevo { get; set; }
        public Nullable<int> IdProyectoColaboradorAnterior { get; set; }
        public Nullable<int> IdProyectoColaboradorNuevo { get; set; }
        public Nullable<int> IdProgramaColaboradorAnterior { get; set; }
        public Nullable<int> IdProgramaColaboradorNuevo { get; set; }
        public Nullable<int> IdTurnoAnterior { get; set; }
        public Nullable<int> IdTurnoNuevo { get; set; }
        public Nullable<System.DateTime> FechaIngresoAnterior { get; set; }
        public Nullable<System.DateTime> FechaIngresoNuevo { get; set; }
        public Nullable<int> IdEstadoAnterior { get; set; }
        public Nullable<int> IdEstadoNuevo { get; set; }
        public Nullable<int> IdSupervisorAnterior { get; set; }
        public Nullable<int> IdSupervisorNuevo { get; set; }
        public Nullable<int> IdBancoAnterior { get; set; }
        public Nullable<int> IdBancoNuevo { get; set; }
        public Nullable<int> IdTipoCuentaAnterior { get; set; }
        public Nullable<int> IdTipoCuentaNuevo { get; set; }
        public string NumeroCuentaAnterior { get; set; }
        public string NumeroCuentaNuevo { get; set; }
        public Nullable<int> IdMedioPagoAnterior { get; set; }
        public Nullable<int> IdMedioPagoNuevo { get; set; }
        public Nullable<int> IdTipoContratoAnterior { get; set; }
        public Nullable<int> IdTipoContratoNuevo { get; set; }
        public Nullable<int> IdCargoAnterior { get; set; }
        public Nullable<int> IdCargoNuevo { get; set; }
        public bool EsSupervisorAnterior { get; set; }
        public bool EsSupervisorNuevo { get; set; }
        public bool ApruebaTHAnterior { get; set; }
        public bool ApruebaTHNuevo { get; set; }
        public Nullable<bool> EsNoministaAnterior { get; set; }
        public Nullable<bool> EsNoministaNuevo { get; set; }
        public Nullable<int> IdSucursalAnterior { get; set; }
        public Nullable<int> IdSucursalNuevo { get; set; }
        public Nullable<int> IdSectorialIESSAnterior { get; set; }
        public Nullable<int> IdSectorialIESSNuevo { get; set; }
        public Nullable<int> IdTituloAnterior { get; set; }
        public Nullable<int> IdTituloNuevo { get; set; }
        public Nullable<int> IdAreaAnterior { get; set; }
        public Nullable<int> IdAreaNuevo { get; set; }
        public Nullable<int> IdMotivoEgresoAnterior { get; set; }
        public Nullable<int> IdMotivoEgresoNuevo { get; set; }
        public Nullable<System.DateTime> FechaEgresoAnterior { get; set; }
        public Nullable<System.DateTime> FechaEgresoNuevo { get; set; }
        public Nullable<int> IdCategoriaOcupacionalAnterior { get; set; }
        public Nullable<int> IdCategoriaOcupacionalNuevo { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tGN_Bancos tGN_Bancos { get; set; }
        public virtual tGN_Bancos tGN_Bancos1 { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas { get; set; }
        public virtual tGN_TiposCuentas tGN_TiposCuentas1 { get; set; }
        public virtual tNM_Areas tNM_Areas { get; set; }
        public virtual tNM_Areas tNM_Areas1 { get; set; }
        public virtual tNM_Cargos tNM_Cargos { get; set; }
        public virtual tNM_Cargos tNM_Cargos1 { get; set; }
        public virtual tNM_CategoriasColaboradores tNM_CategoriasColaboradores { get; set; }
        public virtual tNM_CategoriasColaboradores tNM_CategoriasColaboradores1 { get; set; }
        public virtual tNM_CategoriasOcupacionales tNM_CategoriasOcupacionales { get; set; }
        public virtual tNM_CategoriasOcupacionales tNM_CategoriasOcupacionales1 { get; set; }
        public virtual tNM_ClasesColaboradores tNM_ClasesColaboradores { get; set; }
        public virtual tNM_ClasesColaboradores tNM_ClasesColaboradores1 { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores1 { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores2 { get; set; }
        public virtual tNM_MotivosEgreso tNM_MotivosEgreso { get; set; }
        public virtual tNM_MotivosEgreso tNM_MotivosEgreso1 { get; set; }
        public virtual tNM_SectorialIESS tNM_SectorialIESS { get; set; }
        public virtual tNM_SectorialIESS tNM_SectorialIESS1 { get; set; }
        public virtual tNM_Titulos tNM_Titulos { get; set; }
        public virtual tNM_Titulos tNM_Titulos1 { get; set; }
        public virtual tNM_Departamentos tNM_Departamentos { get; set; }
        public virtual tNM_Departamentos tNM_Departamentos1 { get; set; }
        public virtual tNM_EstadosColaboradores tNM_EstadosColaboradores { get; set; }
        public virtual tNM_EstadosColaboradores tNM_EstadosColaboradores1 { get; set; }
        public virtual tNM_GruposColaboradores tNM_GruposColaboradores { get; set; }
        public virtual tNM_GruposColaboradores tNM_GruposColaboradores1 { get; set; }
        public virtual tNM_MediosPago tNM_MediosPago { get; set; }
        public virtual tNM_MediosPago tNM_MediosPago1 { get; set; }
        public virtual tNM_ProgramasColaboradores tNM_ProgramasColaboradores { get; set; }
        public virtual tNM_ProgramasColaboradores tNM_ProgramasColaboradores1 { get; set; }
        public virtual tNM_ProyectosColaboradores tNM_ProyectosColaboradores { get; set; }
        public virtual tNM_ProyectosColaboradores tNM_ProyectosColaboradores1 { get; set; }
        public virtual tNM_Sucursales tNM_Sucursales { get; set; }
        public virtual tNM_Sucursales tNM_Sucursales1 { get; set; }
        public virtual tNM_TiposColaboradores tNM_TiposColaboradores { get; set; }
        public virtual tNM_TiposColaboradores tNM_TiposColaboradores1 { get; set; }
        public virtual tNM_TiposContrato tNM_TiposContrato { get; set; }
        public virtual tNM_TiposContrato tNM_TiposContrato1 { get; set; }
        public virtual tNM_TiposDiscapacidad tNM_TiposDiscapacidad { get; set; }
        public virtual tNM_TiposDiscapacidad tNM_TiposDiscapacidad1 { get; set; }
    }
}
