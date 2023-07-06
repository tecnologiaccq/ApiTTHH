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
    
    public partial class tNM_BasesCalculadas
    {
        public long IdBaseCalculada { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdCalendarioNomina { get; set; }
        public Nullable<int> IdColaborador { get; set; }
        public Nullable<decimal> Sueldo { get; set; }
        public Nullable<decimal> SueldoHora { get; set; }
        public Nullable<decimal> SalarioBasicoUnificado { get; set; }
        public Nullable<decimal> SueldoBaseTotal { get; set; }
        public Nullable<decimal> AnticipoQuincena { get; set; }
        public Nullable<decimal> AdelantoSueldo { get; set; }
        public Nullable<decimal> IngresosGP { get; set; }
        public Nullable<decimal> IngresosAcumulados { get; set; }
        public Nullable<decimal> IngresosGPxDevengar { get; set; }
        public Nullable<decimal> IngresosProyectados { get; set; }
        public Nullable<decimal> OtrosIngresosGP { get; set; }
        public Nullable<decimal> GastosPersonales { get; set; }
        public Nullable<decimal> AporteIESSAcumulado { get; set; }
        public Nullable<decimal> AporteIESSxPagar { get; set; }
        public Nullable<decimal> AporteIESSProyectado { get; set; }
        public Nullable<decimal> AporteIESSMes { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidad { get; set; }
        public Nullable<decimal> PorcentajeBeneficioDiscapacidad { get; set; }
        public Nullable<decimal> BeneficioDiscapacidad { get; set; }
        public Nullable<decimal> BaseImponible { get; set; }
        public Nullable<decimal> ImpuestoRetenidoAcumulado { get; set; }
        public Nullable<decimal> ImpuestoARetener { get; set; }
        public Nullable<decimal> ImpuestoDelMes { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<decimal> Anticipo13 { get; set; }
        public Nullable<decimal> Anticipo14 { get; set; }
        public Nullable<decimal> Provision13 { get; set; }
        public Nullable<decimal> Provision14 { get; set; }
        public Nullable<decimal> SueldoTotal { get; set; }
        public Nullable<decimal> FactorProporcional { get; set; }
        public Nullable<decimal> BaseIESS { get; set; }
        public Nullable<decimal> ExoneracionTerceraEdad { get; set; }
        public Nullable<decimal> ExoneracionDiscapacidad { get; set; }
        public Nullable<decimal> ProporcionalFondoReserva { get; set; }
        public Nullable<bool> EMailEnviado { get; set; }
        public Nullable<int> DiasTrabajados { get; set; }
        public Nullable<decimal> UltimoSueldo { get; set; }
        public Nullable<decimal> UltimoIngreso { get; set; }
        public Nullable<int> AnosCompletos { get; set; }
        public Nullable<int> AnosIncompletos { get; set; }
        public Nullable<int> DiasFaltantes { get; set; }
        public Nullable<decimal> IngresoAnual { get; set; }
        public Nullable<decimal> MaximaRemuneracion { get; set; }
        public Nullable<decimal> IngresosUltimoAno { get; set; }
        public Nullable<decimal> DecimoAcumulado { get; set; }
        public Nullable<decimal> FondosReservaAcumulado { get; set; }
        public Nullable<decimal> ValorRentaBrutoAnual { get; set; }
        public Nullable<decimal> ReduccionGastosPersonales { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        public virtual tNM_CalendarioNominas tNM_CalendarioNominas { get; set; }
        public virtual tNM_Colaboradores tNM_Colaboradores { get; set; }
    }
}
