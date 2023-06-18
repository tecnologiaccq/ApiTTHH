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
    
    public partial class HADES_tGS_Socios
    {
        public Nullable<int> IdSocio { get; set; }
        public int CodigoSocio { get; set; }
        public string Identificacion { get; set; }
        public Nullable<int> IdEstadoSocio { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public int IdMedioPago { get; set; }
        public Nullable<int> IdNotariaSocio { get; set; }
        public Nullable<int> IdAsesor { get; set; }
        public Nullable<int> IdCobrador { get; set; }
        public Nullable<int> IdConsorcio { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdTipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> IdTarjetaCredito { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjetaCredito { get; set; }
        public Nullable<System.DateTime> FechaCaducidadTarjeta { get; set; }
        public Nullable<System.DateTime> FechaInicioDebito { get; set; }
        public Nullable<int> IdFormaPagoSri { get; set; }
        public string NombreComercial { get; set; }
        public string RazonSocial { get; set; }
        public Nullable<System.DateTime> FechaConstitucion { get; set; }
        public decimal Capital { get; set; }
        public decimal ValorCuota { get; set; }
        public Nullable<int> ValorDescuentoAcuerdo { get; set; }
        public int IdFrecuenciaGeneracionCuota { get; set; }
        public string FechaUltimaGeneracionCuota { get; set; }
        public string CodigoRegistroMercantil { get; set; }
        public Nullable<System.DateTime> FechaInscripcionRegistroMercantil { get; set; }
        public Nullable<int> ValorActivos { get; set; }
        public Nullable<int> NumeroEmpleados { get; set; }
        public Nullable<decimal> ValorVentas { get; set; }
        public System.DateTime FechaAfiliacion { get; set; }
        public Nullable<int> IdCobradorSecundario { get; set; }
        public string tamanio { get; set; }
    }
}
