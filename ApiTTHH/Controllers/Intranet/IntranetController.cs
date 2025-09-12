using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiTTHH.Models;
using System.Web.Http.Cors;
using ApiTTHH.Models.Custom;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApiTTHH.Controllers.Intranet
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/intranet")]
    public class IntranetController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        [Route("ObtenerCumpleanios")]
        [HttpGet]
        public IEnumerable<INTRANET_ObtenerCumpleanios_Result> GetBEMPL_CAT_CAPACITACIONES()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.INTRANET_ObtenerCumpleanios().ToList(); 
        }

        [Route("BuzonTransparencia")]
        [HttpPost]
        public async Task<IHttpActionResult> PostBuzonTransaparencia([FromBody] BuzonTransparencia model)
        {
            try
            {
                if (model == null || string.IsNullOrWhiteSpace(model.Asunto) || string.IsNullOrWhiteSpace(model.Mensaje))
                {
                    return BadRequest("Debe proporcionar un asunto y un mensaje.");
                }

                bool enviado = await senEmailBuzonTransaparencia(model.Asunto, model.Mensaje);
                if (enviado)
                {
                    return Ok(new { status = true, message = "Mensaje enviado correctamente." });
                }
                else
                {
                    return InternalServerError(new Exception("No se pudo enviar el correo."));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public async Task<bool> senEmailBuzonTransaparencia(string asunto, string mensaje)
        {
            try
            {
                Correo correo = new Correo();
                string correoDestino = ConfigurationManager.AppSettings["CORREO_BUZON_TRANSPARENCIA"];
                correo.CodigoAplicacionInterna = "01";
                string cuerpo;

                correo.Listado_TO.Add(correoDestino);
                correo.TituloSubject = "Buzón de Transparencia";

                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_BUZON_TRANSPARENCIA"].ToString();
                cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[ASUNTO]", asunto);
                cuerpo = cuerpo.Replace("[MENSAJE]", mensaje);

                correo.CuerpoMensaje = cuerpo;

                // Invocar API de envío de correo
                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);

                return response.IsSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex}");
                return false;
            }
        }
    }
}