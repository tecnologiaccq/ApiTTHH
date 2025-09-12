using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Threading;
using OnLineCCQ.ApiEnvioCorreoAlphaTech;
using System.Configuration;
using ApiTTHH.Models.Custom;

namespace ApiTTHH
{
    public class API_Service
    {
        public async Task<Response> API_EnviarCorreoApiAlphaV2(Correo correoElectronico)
        {
            #region Implementación
            try
            {
                string urlBase = ConfigurationManager.AppSettings["API_URL_BASE"];
                string metodoSendMail = ConfigurationManager.AppSettings["API_METODO_ENVIAR_CORREO"];

                // Crear opciones para el cliente RestSharp
                var options = new RestClientOptions($"{urlBase}");

                // Crear cliente RestSharp con las opciones
                var client = new RestClient(options);

                // Crear request (ahora se especifica el método al crear el request)
                var request = new RestRequest($"{metodoSendMail}", Method.Post);

                // Convertir objeto a JSON
                string jsonToSend = JsonConvert.SerializeObject(correoElectronico, Formatting.Indented);

                // Agregar headers y body al request
                request.AddHeader("Content-Type", "application/json");
                request.AddStringBody(jsonToSend, DataFormat.Json);

                // Ejecutar la solicitud de forma asíncrona
                var response = await client.ExecuteAsync(request);

                Console.WriteLine(response.Content);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.ErrorMessage ?? "Error al enviar correo electrónico",
                    };
                }

                // Deserializar respuesta
                var result2 = JsonConvert.DeserializeObject<CorreoElectronicoRetorno>(response.Content);

                return new Response
                {
                    IsSuccess = true,
                    FechaHoraRetornoAPI = DateTime.Now,
                    Result = result2,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            #endregion
        }
    } // end class
} // end namespace