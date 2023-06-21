using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.ApiModel.Mail
{
    /// <summary>
    /// Modelo para Archivos Adjuntos
    /// </summary>
    public class AttachmentModel
    {
        /// <summary>
        /// Contenido en 64
        /// </summary>
        public string Archivo { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string Nombre { get; set; }

        //public Adjunto(string nombre = default(string), string archivo = default(string))
        //{
        //    this.Archivo= archivo;
        //    this.Nombre= nombre;
        //}

    }
}