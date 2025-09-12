using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnLineCCQ.ApiEnvioCorreoAlphaTech;

namespace ApiTTHH.Models.Custom
{
    public class Correo
    {
        public string CodigoAplicacionInterna { get; set; }

        public List<string> Listado_TO { get; set; }

        public List<string> Listado_CC { get; set; }

        public List<string> Listado_CCO { get; set; }

        public string CuerpoMensaje { get; set; }

        public string TituloSubject { get; set; }

        public List<Adjunto> ListadoArchivosAdjuntos { get; set; }

        public Correo()
        {
            Listado_TO = new List<string>();
            Listado_CC = new List<string>();
            Listado_CCO = new List<string>();
            ListadoArchivosAdjuntos = new List<Adjunto>();
        }
    }
}