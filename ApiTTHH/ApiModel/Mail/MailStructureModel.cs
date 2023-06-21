using System;
using System.Collections.Generic;

namespace ApiTTHH.ApiModel.Mail
{
    /// <summary>
    /// Modelo Estructura Correo Electrónico
    /// </summary>
    public class MailStructureModel
    {
        /// <summary>
        /// ID Doce
        /// </summary>
        public int IdDoce { get; set; }

        /// <summary>
        /// ID Socio
        /// </summary>
        public int IdSocio { get; set; }

        /// <summary>
        /// Clave de Acceso
        /// </summary>
        public string ClaveAcceso { get; set; }

        //public string CorreosElectronicos { get; set; }
        //public string PathPlantillaNotificacionDefecto { get; set; }

        /// <summary>
        /// Nombre del Comprador
        /// </summary>
        public string NombreComprador { get; set; }//

        /// <summary>
        /// Razón Social Emisor
        /// </summary>
        public string RazonSocialEmisor { get; set; }

        /// <summary>
        /// Nombre Comercial del Emisor
        /// </summary>
        public string NombreComercialEmisor { get; set; }

        /// <summary>
        /// Número del Documento
        /// </summary>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Tipo Comprobante Electrónico Descripción
        /// </summary>
        public string TipoComprobanteElectronicoDescripcion { get; set; }

        /// <summary>
        /// Correo Electrónico Socio Reply
        /// </summary>
        public string CorreoElectronicoSocioREPLY { get; set; }

        /// <summary>
        /// Ambiente
        /// </summary>
        public int Ambiente { get; set; }

        /// <summary>
        /// Correo Secundario
        /// </summary>
        public string CorreoSecundario { get; set; }

        //public bool DeseoRecibirCopiaDelEmailNotificacion { get; set; }

        /// <summary>
        /// Path Archivo PDF Documento Ingreso
        /// </summary>
        public String VFS_PathArchivoPDF_DocumentoIngreso { get; set; }

        /// <summary>
        /// Fecha Emisión
        /// </summary>
        public String VFS_FechaEmision { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public String VFS_Valor { get; set; }

        /// <summary>
        /// Código Aplicación Interna
        /// </summary>
        public string CodigoAplicacionInterna { get; set; }

        /// <summary>
        /// Listado Para
        /// </summary>
        public List<string> Listado_TO { get; set; }

        /// <summary>
        /// Listado con Copia
        /// </summary>
        public List<string> Listado_CC { get; set; }

        /// <summary>
        /// Listado con Copia Oculta
        /// </summary>
        public List<string> Listado_CCO { get; set; }

        /// <summary>
        /// Cuerpo Mensaje
        /// </summary>
        public string CuerpoMensaje { get; set; }

        /// <summary>
        /// Título
        /// </summary>
        public string TituloSubject { get; set; }

        public List<AttachmentModel> ListadoArchivosAdjuntos { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MailStructureModel()
        {
            Listado_TO = new List<string>();
            Listado_CC = new List<string>();
            Listado_CCO = new List<string>();
            ListadoArchivosAdjuntos = new List<AttachmentModel>();
        }
    }
}