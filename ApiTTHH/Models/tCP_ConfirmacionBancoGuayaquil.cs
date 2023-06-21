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
    
    public partial class tCP_ConfirmacionBancoGuayaquil
    {
        public int IdConfirmacionBancoGuayaquil { get; set; }
        public Nullable<int> Id_Orden { get; set; }
        public Nullable<decimal> Id_Item { get; set; }
        public string Referencia { get; set; }
        public string Pais { get; set; }
        public string Banco { get; set; }
        public string FormaPago { get; set; }
        public string Cuenta { get; set; }
        public Nullable<decimal> ContraPartida { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<decimal> Valor_Pro { get; set; }
        public Nullable<decimal> Valor_Env { get; set; }
        public string Moneda { get; set; }
        public Nullable<System.DateTime> FechaProceso { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> No_ReferBCO { get; set; }
        public string TipoPago { get; set; }
        public string No_Documento { get; set; }
        public string Estado_Documento { get; set; }
        public Nullable<int> Secuencial_Cobro { get; set; }
        public Nullable<int> Numero_Comprobante { get; set; }
        public string ReferenciaAdicional { get; set; }
        public string Empresa { get; set; }
        public Nullable<int> CodigoOficina { get; set; }
        public Nullable<System.DateTime> FechaProcesoDate { get; set; }
        public string CondicionProcesoMov { get; set; }
        public Nullable<System.DateTime> HoraProceso { get; set; }
        public Nullable<decimal> CuentaItems { get; set; }
        public Nullable<decimal> ReferenciaItemCero { get; set; }
        public string Nombre { get; set; }
        public string ReferenciaTransaccion { get; set; }
        public string BancoEmisor { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public string IdentificacionProveedor { get; set; }
        public string NumeroComprobante { get; set; }
        public Nullable<bool> InsertarInterfaz { get; set; }
        public Nullable<System.DateTime> FechaOrden { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> NumeroOrdenProcesoBanco { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public string Item { get; set; }
        public string Codigo { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<decimal> ValorProcesado { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string IdCargo { get; set; }
        public string CreadoPor { get; set; }
    }
}