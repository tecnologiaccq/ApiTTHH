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
    
    public partial class tCC_CobroBancoGuayaquil
    {
        public int IdCobroBancoGuayaquil { get; set; }
        public Nullable<int> IdCargoCab { get; set; }
        public string CodigoOrientacion { get; set; }
        public string CuentaEmpresa { get; set; }
        public string Secuencial { get; set; }
        public string ComprobanteCobro { get; set; }
        public string Contrapartida { get; set; }
        public string Moneda { get; set; }
        public string Valor { get; set; }
        public string FormaCobro { get; set; }
        public string CodigoBanco { get; set; }
        public string TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoIdentificacionCliente { get; set; }
        public string NumeroIdentificacionCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string CiudadCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string LocalidadCobro { get; set; }
        public string Referencia { get; set; }
        public string ReferenciaAdicional { get; set; }
        public string NumeroFactura { get; set; }
        public string NombreArchivoGenerado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCC_CargosCab tCC_CargosCab { get; set; }
    }
}