using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiTTHH.Models.Custom;

namespace ApiTTHH.Comun.Permisos
{
    public static class EnviarNotificacionEmail
    {
        public static async Task<bool> sendEmailSolicitudAusenciaVacaciones(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string tipoAusencia, string fechaDesde, string FechaHasta, string nombreReemplazo, Adjunto adjunto)
        {
            try
            {
                //Call the api
                Correo correo = new Correo();
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                //correo.Listado_CC.Add(correoElectronicoreemplazo);
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";
                List<Adjunto> listadoArchivosAdjuntos = new List<Adjunto>();
                if (adjunto != null)
                {
                    listadoArchivosAdjuntos.Add(adjunto);

                }

                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];

                var correosTH = correoTalentoHumano
                    .Split(';')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrEmpty(c));

                foreach (var correoTH in correosTH)
                {
                    correo.Listado_CC.Add(correoTH);
                }

                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_VACACIONES"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
                cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                cuerpo = cuerpo.Replace("[REEMPLAZO]", nombreReemplazo);

                 
                correo.CuerpoMensaje = cuerpo;

                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);
                if (!response.IsSuccess)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.Message}");
                    Console.ReadLine();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false;
            }

        }
        public static async Task<bool> sendEmailSolicitudAusenciaPermisos(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string tipoAusencia, string fechaDesde, Adjunto adjunto)
        {
            try
            {
                Correo correo = new Correo();
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";
                List<Adjunto> listadoArchivosAdjuntos = new List<Adjunto>();
                if (adjunto != null)
                {
                    listadoArchivosAdjuntos.Add(adjunto);

                }
                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];

                var correosTH = correoTalentoHumano
                    .Split(';')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrEmpty(c));

                foreach (var correoTH in correosTH)
                {
                    correo.Listado_CC.Add(correoTH);
                }


                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
                cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                correo.CuerpoMensaje = cuerpo;


                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);
                if (!response.IsSuccess)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.Message}");
                    Console.ReadLine();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false;
            }

        }
        
        public static async Task<bool> sendEmailSolicitudAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe, int? idTipoAusencia, string horaIni, string horaFin, List<Adjunto> adjuntos, bool? ApruebaTalentoHumano)
        {
            try
            {
                // Call the api
                Correo correo = new Correo();


                correo.CodigoAplicacionInterna = "01";
                string cuerpo;

                // TO principal
                correo.Listado_TO.Add(correojefe);

                // CC
                correo.Listado_CC.Add(correoUsuario);

                // Talento Humano (pueden ser varios)
                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];

                var correosTH = correoTalentoHumano
                    .Split(';')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrEmpty(c));

                foreach (var correoTH in correosTH)
                {
                    correo.Listado_CC.Add(correoTH);
                }
                

                // correo.Listado_CC.Add(correoTalentoHumano);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";
                if (idTipoAusencia != null && (idTipoAusencia == 7 || idTipoAusencia == 10))
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;

                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", horaFin);
                }else if(idTipoAusencia == 9)
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_LICENCIA_SIN_REMUNERACION"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                }
                else
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                }

                List<Adjunto> listadoArchivosAdjuntos = adjuntos;

                correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);
                if (!response.IsSuccess)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.Message}");
                    Console.ReadLine();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false;
            }

        }
        public static async Task<bool> sendEmailAprobacionRechazoAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe, string motivo, string estadoAutorizacion, int? idTipoAusencia, string horaIni, string horaFin)
        {
            try
            {
                //Call the api
                Correo correo = new Correo();
                // string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";

                correo.Listado_TO.Add(correoUsuario);
                //if (correoElectronicoreemplazo != string.Empty) {
                //correo.Listado_CC.Add(correoTalentoHumano);
                correo.Listado_CC.Add(correojefe);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";



                string cuerpo;

                //if (idTipoAusencia != null && (idTipoAusencia == 7))
                //{
                //    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_PERMISOS"].ToString();
                //    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                //    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                //    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;

                //    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                //    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                //    cuerpo = cuerpo.Replace("[HORA_FIN]", horaFin);
                //}
                //else
                //{
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS_APROBACION_RECHAZO"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
               // }
                cuerpo = cuerpo.Replace("[ESTADO_AUTORIZACION]", estadoAutorizacion.ToLower());
                cuerpo = cuerpo.Replace("[MOTIVO]", motivo);
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);
                //Response response = response_API_SendMail.Result;
                if (!response.IsSuccess)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.Message}");
                    Console.ReadLine();
                    return false;
                }

                return true;

                //using (var context = new TALENTO_HUMANOEntities())
                //{
                //    BEMPL_DATOSPOSTULANTE postulante = context.BEMPL_DATOSPOSTULANTE.Find(idPostulante);
                //    postulante.IsEnviadoEmailCandidato = true;
                //    postulante.FechaHoraEnviadoEmailCandidato = DateTime.Now;
                //    context.SaveChanges();
                //}

                //Console.WriteLine($"Candidato {nombresFinal} procesado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false;
            }

        }

        public static async Task<bool> sendEmailSolicitudAusenciaAprobRech(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string motivo, string tipoAusencia, string fechaDesde, string FechaHasta, int idEstadoAprobacion, string estadoAutorizacion, string nombreReemplazo, string correoElectronicoreemplazo)
        {

            try
            {
                Debug.WriteLine("----------------------------entrando a envio de correo-----------------------");
                //Call the api
                Correo correo = new Correo();
                //string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                /*if (correoElectronicoreemplazo != string.Empty)
                {
                    if (idEstadoAprobacion == 2)
                    {
                        correo.Listado_CC.Add(correoElectronicoreemplazo);
                    }
                }*/
                if (idEstadoAprobacion == 2)
                {
                    //correo.Listado_CC.Add(correoTalentoHumano);
                }
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";

                var pathArchivoPlantilla = idTipoAusencia == 1 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_VACACIONES"].ToString() : (idTipoAusencia == 2 || idTipoAusencia == 8) ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_PERMISOS"].ToString() : (idTipoAusencia == 7 || idTipoAusencia == 8) ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_MEDICO_HORAS_APROBACION_RECHAZO"].ToString() : ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS_APROBACION_RECHAZO"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower());
                cuerpo = cuerpo.Replace("[MOTIVO]", motivo);
                if (idTipoAusencia == 1)
                {
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                    cuerpo = cuerpo.Replace("[REEMPLAZO]", nombreReemplazo);
                }
                else 
                {
                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                }
                //if (idTipoAusencia == 7 )
                //{
                //    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                //    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                //    cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                //}
                cuerpo = cuerpo.Replace("[ESTADO_AUTORIZACION]", estadoAutorizacion.ToLower()); ;
                cuerpo = cuerpo.Replace("[MOTIVO]", motivo);
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                API_Service apiService = new API_Service();
                var response = await apiService.API_EnviarCorreoApiAlphaV2(correo);
                //Response response = response_API_SendMail.Result;
                if (!response.IsSuccess)
                {
                    Debug.WriteLine("ERROR EN EL RETORNO DEL API");
                    Debug.WriteLine($"{response.Message}");
                    //Debug.ReadLine();
                    return false;
                }
                return true;

                //using (var context = new TALENTO_HUMANOEntities())
                //{
                //    BEMPL_DATOSPOSTULANTE postulante = context.BEMPL_DATOSPOSTULANTE.Find(idPostulante);
                //    postulante.IsEnviadoEmailCandidato = true;
                //    postulante.FechaHoraEnviadoEmailCandidato = DateTime.Now;
                //    context.SaveChanges();
                //}

                //Console.WriteLine($"Candidato {nombresFinal} procesado.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false;
            }

        }
    }
}