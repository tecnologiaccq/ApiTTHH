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
    
    public partial class EV_BoletoElectronico_Certificados
    {
        public int IdBoletoElectronico { get; set; }
        public Nullable<int> IdCargoCab { get; set; }
        public Nullable<int> IdEvento { get; set; }
        public string NombreAsistente { get; set; }
        public string CorreoElectronicoAsistente { get; set; }
        public string NumeroCelularAsistente { get; set; }
        public string GuiBoleto { get; set; }
        public string GuiBoletoEncriptado { get; set; }
        public string UrlEticket { get; set; }
        public Nullable<bool> EstaGeneradoQR { get; set; }
        public Nullable<bool> EstaEnviadoCorreoElectronico { get; set; }
        public Nullable<bool> EstaLeidoIngresoEvento { get; set; }
        public Nullable<System.DateTime> FechaHoraIngresoEvento { get; set; }
        public string UsuarioDispositivoMovilIngresoEvento { get; set; }
        public string PathArchivoImagenQRLocal { get; set; }
        public string PathArchivoEticketLocal { get; set; }
        public string Nota1 { get; set; }
        public string Nota2 { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string ModificadoPor { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<bool> ProcesarDemonioTempo { get; set; }
        public string Nota3 { get; set; }
        public Nullable<bool> CompradoEnPortalBotonPagos { get; set; }
        public string NotaSistemas { get; set; }
        public Nullable<bool> ParaEnviarCertificado { get; set; }
        public string UrlCertificadoAsistencia { get; set; }
        public Nullable<bool> EstaEnviadoCertificadoAsistencia { get; set; }
        public string Empresa { get; set; }
    }
}
