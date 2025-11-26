using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiTTHH.Models;
using ApiTTHH.Models.Custom;
using ApiTTHH.Reportes;
using DevExpress.DataAccess.Json;
using DevExpress.UIAutomation;
using iTextSharp.text.pdf.parser;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Newtonsoft.Json;
using OnLineCCQ.ApiEnvioCorreoAlphaTech;
using Path = System.IO.Path;
using Serilog;
using ApiTTHH.Utils;
using System.Windows.Forms;

namespace ApiTTHH.Controllers.Vacaciones
{
    public class tNM_SolicitudVacacionesCabController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();
        private INTEGRACIONESEntities espaciosDB = new INTEGRACIONESEntities();

        // GET: api/tNM_SolicitudVacacionesCab
        public IQueryable<tNM_SolicitudVacacionesCab> GettNM_SolicitudVacacionesCab()
        {
            return db.tNM_SolicitudVacacionesCab;
        }

        // GET: api/tNM_SolicitudVacacionesCab/5
        [ResponseType(typeof(tNM_SolicitudVacacionesCab))]
        public async Task<IHttpActionResult> GettNM_SolicitudVacacionesCab(int id)
        {
            tNM_SolicitudVacacionesCab tNM_SolicitudVacacionesCab = await db.tNM_SolicitudVacacionesCab.FindAsync(id);
            if (tNM_SolicitudVacacionesCab == null)
            {
                return NotFound();
            }

            return Ok(tNM_SolicitudVacacionesCab);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-solictud")]
        public async Task<HttpResponseMessage> PostSolicitudVacacionesCol(tNM_SolicitudVacacionesCab solicitud)
        {

            SeriLog.GuardarLogApplicacionSerilog("INICIO", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

            try
            {
                db.Configuration.LazyLoadingEnabled = false;

                int count = db.tNM_SolicitudVacacionesCab.Where(x => x.IdEstadoAprob == 1 && x.IdColaborador == solicitud.IdColaborador).Count();
                var jefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdSupervisor);
                var colaborador = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaborador);
                var colaboradorReemplazo = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaboradorReemplazo);
                string correoElectronicoJefe = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == jefe.IdPersona && x.IdMedioContacto == 13).Contacto;
                //string correoElectronicoReemplazo = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorReemplazo.IdPersona && x.IdMedioContacto == 13).Contacto;
                string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaborador.IdPersona && x.IdMedioContacto == 13).Contacto;
                SeriLog.GuardarLogApplicacionSerilog(correoElectronicoJefe, Enumeraciones.EnumNivelesSeriLog.INFORMATION);
               // SeriLog.GuardarLogApplicacionSerilog(correoElectronicoReemplazo, Enumeraciones.EnumNivelesSeriLog.INFORMATION);
                SeriLog.GuardarLogApplicacionSerilog(correoElectronicoCol, Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                correoElectronicoCol = correoElectronicoCol?.Trim();
                bool correoColaboradorInvalido = string.IsNullOrWhiteSpace(correoElectronicoCol);
                if (count > 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tiene solicitudes pendientes de aprobación por jefatura. No se puede enviar solicitud");
                }
                correoElectronicoJefe = correoElectronicoJefe?.Trim();
                //correoElectronicoReemplazo = correoElectronicoReemplazo?.Trim();

                bool correoJefeInvalido = string.IsNullOrWhiteSpace(correoElectronicoJefe);
                //bool correoReemplazoInvalido = string.IsNullOrWhiteSpace(correoElectronicoReemplazo);

                if (correoJefeInvalido )
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del supervisor no existe. Por favor, regularice el tema con talento humano. ";
                   // if (correoReemplazoInvalido) errorMensaje += "correo electrónico del reemplazo no existe. Por favor, regularice el tema con talento humano. ";
                    SeriLog.GuardarLogApplicacionSerilog("no valido el correo del jefe o reemplazo", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }

                if (correoColaboradorInvalido)
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del colaborador no existe. Por favor, regularice el tema con talento humano. ";
                    SeriLog.GuardarLogApplicacionSerilog("no valido correo colaborador", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }

                Debug.WriteLine("-------------------CORREO ELECTRONICO COLABORADOR-------------------------");
                Debug.WriteLine(correoElectronicoCol);

                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        List<tNM_SolicitudVacacionesDet> detallesperiodos = new List<tNM_SolicitudVacacionesDet>();
                        var periodos = db.sp_tnmDiasVacacionesColaborador(solicitud.IdColaborador);
                        decimal diasDescontar = solicitud.DiasSolicitados.Value;
                        foreach (var periodo in periodos)
                        {
                            tNM_SolicitudVacacionesDet detalle = new tNM_SolicitudVacacionesDet();
                            if (diasDescontar > 0)
                            {
                                if (periodo.DiasPendientes >= diasDescontar)
                                {
                                    detalle.DiasADisfrutarPeriodo = diasDescontar;
                                    detalle.IdHistorialVacaciones = periodo.IdHistorialVacaciones;
                                    diasDescontar = 0;
                                }
                                else
                                {
                                    detalle.DiasADisfrutarPeriodo = periodo.DiasPendientes;
                                    detalle.IdHistorialVacaciones = periodo.IdHistorialVacaciones;
                                    diasDescontar = diasDescontar - (decimal)periodo.DiasPendientes;
                                }
                                detallesperiodos.Add(detalle);
                            }

                        }
                        solicitud.tNM_SolicitudVacacionesDet = detallesperiodos;
                        solicitud.FechaSolicitud = DateTime.Now;
                        solicitud.IdEstadoAprob = 1;

                        //solicitud.FechaInicio = DateTime.Parse(solicitud.FechaInicio);

                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaborador);
                        solicitud.IdSupervisor = colaboradorSol.IdSupervisor;
                        //solicitud.tNM_Colaboradores.ApellidosNombres = colaboradorSol.ApellidosNombres;

                        db.tNM_SolicitudVacacionesCab.Add(solicitud);
                        //var jsonSolicitud = JsonConvert.SerializeObject(solicitud);

                        db.SaveChanges();
                        SeriLog.GuardarLogApplicacionSerilog(solicitud.ToString(), Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        var res = db.tNM_SolicitudVacacionesCab.Where(x => x.IdSolicitudVacaciones == solicitud.IdSolicitudVacaciones).Select(y => new
                        {
                            Fecha = y.FechaSolicitud,
                            Dias = y.DiasSolicitados,
                            fechaInicio = y.FechaInicio,
                            fechafin = y.FechaFin,
                            nombre = y.tNM_Colaboradores.ApellidosNombres,
                            cargo = y.tNM_Colaboradores.tNM_Cargos.Descripcion,
                            nombreJefe = y.tNM_Colaboradores1.ApellidosNombres,
                            Detalle = y.tNM_SolicitudVacacionesDet.Select(z => new { diasPeriodo = z.DiasADisfrutarPeriodo, anio = z.tNM_HistorialVacaciones.Periodo, z.tNM_HistorialVacaciones.FechaInicial, z.tNM_HistorialVacaciones.FechaFinal })
                        }).FirstOrDefault();
                        var jsonSolicitud = JsonConvert.SerializeObject(res);
                        List<string> resultSolicitudFile = GeneraSolicitudFile(jsonSolicitud, solicitud.IdSolicitudVacaciones, solicitud.IdColaborador.Value);
                        solicitud.UrlSolicitud = resultSolicitudFile[0];
                        SeriLog.GuardarLogApplicacionSerilog(solicitud.UrlSolicitud, Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        db.SaveChanges();
                        dbTransaction.Commit();
                        SeriLog.GuardarLogApplicacionSerilog("TRANSACCIÓN COMMIT REALIZADA", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres : colaboradorSol.nickname;
                        /*List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitud.IdSupervisor).ToList();
                        foreach (AGET_TOKENS_USERS token in tOKENS_USERS)
                        {
                            dynamic data = new
                            {
                                to = token.Token, // Uncoment this if you want to test for single device
                                                  // registration_ids = singlebatch, // this is for multiple user 
                                notification = new
                                {
                                    title = NombreCol,     // Notification title
                                    body = "Ha realizado una solicitud de vacaciones",    // Notification body data,
                                    click_action = "FCM_PLUGIN_ACTIVITY",
                                    icon = "ic_launcher"
                                    //image= "https://storagebolsaempleo.blob.core.windows.net/archivos/BolsaEmpleo/Foto/1_F.jpg"                                                                                                    // When click on notification user redirect to this link
                                },
                                data = new
                                {
                                    ruta = "ausencias",

                                },
                                priority = "normal",
                            };

                            SendNotification(data);
                        }*/
                        
                        string nombreReemplazo = colaboradorReemplazo.ApellidosNombres;
                        
                        string tipoAusencia = db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitud.IdTipoAusencia).Nombre;




                        /*Carga de archivos*/

                        string pathArchivoPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudVacacion_") + solicitud.IdSolicitudVacaciones + "_" + solicitud.IdColaborador + ".pdf"; ;
                        FileInfo filePDFToSend = new FileInfo(pathArchivoPDF);
                        Adjunto adjunto = null;
                        if (filePDFToSend.Exists)
                        {
                            byte[] bytes = File.ReadAllBytes(pathArchivoPDF);
                            string file64 = Convert.ToBase64String(bytes);

                             adjunto = new Adjunto
                            {
                                Archivo = file64,
                                Nombre = filePDFToSend.Name
                            };
                            System.IO.File.Delete(pathArchivoPDF);
                        }
                       

                        bool enviado = await sendEmailSolicitudAusencia(correoElectronicoJefe, NombreCol, "", "", "", solicitud.IdTipoAusencia.Value, tipoAusencia, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), nombreReemplazo, adjunto);

                        SeriLog.GuardarLogApplicacionSerilog("CORREO ENVIADO: "+ enviado, Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });

                        //sendEmailSolicitudAusencia(correoElectronicoJefe, NombreCol, "", "", "", solicitud.IdTipoAusencia.Value, tipoAusencia, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), nombreReemplazo, correoElectronicoReemplazo, adjunto);

                        //return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        var message = ex.ToString(); // o ex.InnerException?.Message ?? ex.Message
                        SeriLog.GuardarLogApplicacionSerilog(message, Enumeraciones.EnumNivelesSeriLog.ERROR);
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);

                        //dbTransaction.Rollback();
                        //SeriLog.GuardarLogApplicacionSerilog(ex.Message, Enumeraciones.EnumNivelesSeriLog.ERROR);
                        //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();

            }
            catch (Exception ex)
            {
                var message = ex.ToString(); // o ex.InnerException?.Message ?? ex.Message
                SeriLog.GuardarLogApplicacionSerilog(message, Enumeraciones.EnumNivelesSeriLog.ERROR);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
                /*var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);*/
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/solictud-aprobarRechazar")]
        public async Task<HttpResponseMessage> PostSolicitudVacacioneesAprobarRechazar(tNM_SolicitudVacacionesCab solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;

            try
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {

                    try
                    {
                        tNM_SolicitudVacacionesCab solicitudCabUpdate = db.tNM_SolicitudVacacionesCab.FirstOrDefault(x => x.IdSolicitudVacaciones == solicitud.IdSolicitudVacaciones);
                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudCabUpdate.IdColaborador);
                        var colaboradorReemplazo = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudCabUpdate.IdColaboradorReemplazo);
                        //string correoElectronicoReemplazo = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorReemplazo.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;



                        solicitudCabUpdate.IdEstadoAprob = solicitud.IdEstadoAprob;
                        solicitudCabUpdate.RespuestaSupervisor = solicitud.RespuestaSupervisor;
                        solicitudCabUpdate.FechaAprobacionSupervisor = DateTime.Now;
                        var colaboradoSupe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaboradorSol.IdSupervisor);
                        if (solicitud.IdEstadoAprob == 2)
                        {
                            List<tNM_SolicitudVacacionesDet> detallesSolicitud = db.tNM_SolicitudVacacionesDet.Where(x => x.IdSolictudVacacionesCab == solicitudCabUpdate.IdSolicitudVacaciones).ToList();
                            foreach (tNM_SolicitudVacacionesDet detalle in detallesSolicitud)
                            {
                                tNM_DetalleVacaciones detallevacacionFin = new tNM_DetalleVacaciones();
                                tNM_HistorialVacaciones historialUpdate = db.tNM_HistorialVacaciones.FirstOrDefault(x => x.IdHistorialVacaciones == detalle.IdHistorialVacaciones);
                                int diasFinesSemana = 0;
                                detallevacacionFin.IdHistorialVacaciones = long.Parse(detalle.IdHistorialVacaciones.ToString());
                                detallevacacionFin.DiasDisfrutados = detalle.DiasADisfrutarPeriodo + diasFinesSemana;
                                detallevacacionFin.DiasCancelados = detalle.DiasADisfrutarPeriodo + diasFinesSemana;
                                detallevacacionFin.FechaSalida = solicitudCabUpdate.FechaInicio;
                                detallevacacionFin.FechaReintegro = solicitudCabUpdate.FechaFin;

                                historialUpdate.DiasPendientesDisfrute = historialUpdate.DiasPendientesDisfrute - detalle.DiasADisfrutarPeriodo - diasFinesSemana;
                                historialUpdate.DiasPendientesCancelar = historialUpdate.DiasPendientesCancelar - detalle.DiasADisfrutarPeriodo - diasFinesSemana;
                                historialUpdate.DiasDisfrutados = historialUpdate.DiasDisfrutados != null ? historialUpdate.DiasDisfrutados + detalle.DiasADisfrutarPeriodo + diasFinesSemana : detalle.DiasADisfrutarPeriodo + diasFinesSemana;
                                historialUpdate.DiasCancelados = historialUpdate.DiasCancelados != null ? historialUpdate.DiasCancelados + detalle.DiasADisfrutarPeriodo + diasFinesSemana : detalle.DiasADisfrutarPeriodo + diasFinesSemana;
                                historialUpdate.FinesSemana = 2;
                                db.tNM_DetalleVacaciones.Add(detallevacacionFin);

                            }
                        }
                        db.SaveChanges();
                        dbTransaction.Commit();
                        string body = solicitud.IdEstadoAprob == 2 ? "Ha aprobado su solicitud de vacaciones." : "Ha rechazado su solicitud de vacaciones." + solicitud.RespuestaSupervisor;
                       /* List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitudCabUpdate.IdColaborador).ToList();
                        foreach (AGET_TOKENS_USERS token in tOKENS_USERS)
                        {
                            dynamic data = new
                            {
                                to = token.Token, // Uncoment this if you want to test for single device
                                                  // registration_ids = singlebatch, // this is for multiple user 
                                notification = new
                                {
                                    title = colaboradoSupe.nickname == null ? colaboradoSupe.ApellidosNombres.Split(' ')[2] : colaboradoSupe.nickname,     // Notification title
                                    body = body,    // Notification body data,
                                    click_action = "FCM_PLUGIN_ACTIVITY",
                                    icon = "ic_launcher"
                                    //image= "https://storagebolsaempleo.blob.core.windows.net/archivos/BolsaEmpleo/Foto/1_F.jpg"                                                                                                    // When click on notification user redirect to this link
                                },
                                data = new
                                {
                                    ruta = "ausencias",

                                },
                                priority = "normal",
                            };

                            SendNotification(data);
                        }*/

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres : colaboradorSol.nickname;
                        string tipoAusencia = db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitudCabUpdate.IdTipoAusencia).Nombre;
                        string motivo = solicitudCabUpdate.RespuestaSupervisor == null ? "" : solicitudCabUpdate.RespuestaSupervisor;
                        string estadoAprob = db.tNM_EstadosFlujoAusencias.FirstOrDefault(x => x.IDEstado == solicitudCabUpdate.IdEstadoAprob).Descripcion;
                        string nombreReemplazo = colaboradorReemplazo.ApellidosNombres;
                        bool enviado = await sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", "", "", solicitudCabUpdate.IdTipoAusencia.Value, motivo, tipoAusencia, solicitudCabUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.IdEstadoAprob.Value, estadoAprob, nombreReemplazo, " ");

                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });


                        //return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();

            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/solicitud-aprobarRechazar-permisotthh")]
        public async Task<HttpResponseMessage> PostSolicitudPermisoAprobarRechazar(tNM_SolicitudPermiso solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;

            try
            {
                tNM_SolicitudPermiso permisoSolicitud = db.tNM_SolicitudPermiso.Find(solicitud.IdSolicitudPermiso);
                tNM_Colaboradores jefe = db.tNM_Colaboradores.First(x => x.IdColaborador == permisoSolicitud.IdSupervisor);
                string correoJefe = db.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13 && x.IdPersona==jefe.IdPersona).Contacto;
                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Find(permisoSolicitud.Idcolaborador);
                string correoSolicitante = db.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13 && x.IdPersona==colaborador.IdPersona).Contacto;
                tNM_TiposAusencia tNM_TiposAusencia = db.tNM_TiposAusencia.Find(permisoSolicitud.IdTipoAusencia);
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                         permisoSolicitud = db.tNM_SolicitudPermiso.Find(solicitud.IdSolicitudPermiso);
                       
                        if (solicitud.RespuestaTalentoHumano == null || solicitud.RespuestaTalentoHumano.Trim()=="")
                        {
                            permisoSolicitud.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "APR").IDEstado;
                            permisoSolicitud.RespuestaTalentoHumano = null;
                        }
                        else
                        {
                            permisoSolicitud.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "RETTH").IDEstado;
                            permisoSolicitud.RespuestaTalentoHumano = solicitud.RespuestaTalentoHumano;
                        }
                        tNM_EstadosFlujoAusencias estadosFlujoAusencias = db.tNM_EstadosFlujoAusencias.Find(permisoSolicitud.IdEstadoAprob);
                        db.SaveChanges();
                        dbTransaction.Commit();

                        bool enviado = false;
                        if (permisoSolicitud.IdTipoAusencia == 7)
                        {
                            /* Debug.WriteLine("ausencia 7");
                              Debug.WriteLine(correoSolicitante);
                              Debug.WriteLine(colaborador.ApellidosNombres);
                              Debug.WriteLine(tNM_TiposAusencia.Nombre);
                              Debug.WriteLine(permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")));
                              Debug.WriteLine(correoJefe);
                              Debug.WriteLine(permisosolicitud.RespuestaTalentoHumano);
                              Debug.WriteLine(estadosFlujoAusencias.Descripcion);
                              Debug.WriteLine(solicitud.IdTipoAusencia);
                              Debug.WriteLine(solicitud.HoraInicio.Value.ToString("HH:mm"));
                              Debug.WriteLine(solicitud.HoraFin.Value.ToString("HH:mm"));*/

                            enviado = await sendEmailAprobacionRechazoAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), " ", correoJefe, solicitud.RespuestaTalentoHumano == null ? "" : solicitud.RespuestaTalentoHumano, estadosFlujoAusencias.Descripcion, permisoSolicitud.IdTipoAusencia, permisoSolicitud.HoraInicio.Value.ToString("HH:mm"), permisoSolicitud.HoraFin.Value.ToString("HH:mm"));

                        }
                        else
                        {
                            enviado = await sendEmailAprobacionRechazoAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), permisoSolicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), correoJefe, solicitud.RespuestaTalentoHumano == null ? "" : solicitud.RespuestaTalentoHumano, estadosFlujoAusencias.Descripcion,permisoSolicitud.IdTipoAusencia, " "," ");
                        }

                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });
                       // return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();

            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudesvacaciones/{idColaborador}")]
        public HttpResponseMessage GetSolicitudesVacacionesColaborador(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesVacacionesColaborador(idColaborador));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudespermisos/{idColaborador}")]
        public HttpResponseMessage GetSolicitudesPermisosColaborador(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosColaborador(idColaborador));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudesvacacionessupervisor/{idSupervisor}")]
        public HttpResponseMessage GetSolicitudesVacacionesSupervisor(int idSupervisor)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesVacacionesAprobJefe(idSupervisor));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudespermisossupervisor/{idSupervisor}")]
        public HttpResponseMessage GetSolicitudesPermisosSupervisor(int idSupervisor)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosSupervisorColaborador(idSupervisor));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-solicitudpermiso")]
        public async Task<HttpResponseMessage> PostSolicitudPermisoCol(tNM_SolicitudPermiso solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;
            decimal countPermisosHoras = 0;
            var tipoAusencia = this.db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitud.IdTipoAusencia);
            if (tipoAusencia.AplicaSoloDia == true && (tipoAusencia.AplicaRangoFechas == null || tipoAusencia.AplicaRangoFechas == false) && tipoAusencia.AplicaHoras == true)
            {
                if (db.tNM_SolicitudPermiso.Where(x => x.Idcolaborador == solicitud.Idcolaborador && x.FechaInicio == solicitud.FechaInicio && (x.IdEstadoAprob == 1 || x.IdEstadoAprob == 2)).Count() > 0)
                    countPermisosHoras = db.tNM_SolicitudPermiso.Where(x => x.Idcolaborador == solicitud.Idcolaborador && x.FechaInicio == solicitud.FechaInicio && (x.IdEstadoAprob == 1 || x.IdEstadoAprob == 2)).Sum(s => s.NumeroHoras).Value;
                //var permiso = db.tNM_SolicitudPermiso.FirstOrDefault(x => x.Idcolaborador == solicitud.Idcolaborador && x.FechaInicio == solicitud.FechaInicio && (x.IdEstadoAprob==1 || x.IdEstadoAprob == 2));
                //if (permiso != null)
                countPermisosHoras = countPermisosHoras + solicitud.NumeroHoras.Value;
                if (countPermisosHoras > tipoAusencia.MaximaHorasPermitidasDia)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Límite de horas permitidas de permiso por día es " + tipoAusencia.MaximaHorasPermitidasDia);
            }
           


            try
            {
                var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.Idcolaborador);
                var jefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaboradorSol.IdSupervisor);
                var reemplazo = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaboradorReemplazo);
                string correoElectronicoJefe = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == jefe.IdPersona && x.IdMedioContacto == 13).Contacto;
                string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;

                correoElectronicoJefe = correoElectronicoJefe?.Trim();
                bool correoJefeInvalido = string.IsNullOrWhiteSpace(correoElectronicoJefe);
                correoElectronicoCol = correoElectronicoCol?.Trim();
                bool correoColaboradorInvalido = string.IsNullOrWhiteSpace(correoElectronicoCol);

                Debug.WriteLine(correoElectronicoJefe);
                Debug.WriteLine(correoElectronicoCol);

                if (correoJefeInvalido )
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del supervisor no existe. Por favor, regularice el tema con talento humano. ";
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }
                if (correoColaboradorInvalido)
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del colaborador no existe. Por favor, regularice el tema con talento humano. ";
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }


                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        //solicitud.FechaInicio = DateTime.Parse(solicitud.FechaInicio);
                        solicitud.IdSupervisor = colaboradorSol.IdSupervisor;
                        solicitud.IdEstadoAprob = 1;
                        db.tNM_SolicitudPermiso.Add(solicitud);
                        db.SaveChanges();
                        //dbTransaction.Commit();

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres.Split(' ')[2] : colaboradorSol.nickname;
                        //List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == colaboradorSol.IdSupervisor).ToList();
                        //foreach (AGET_TOKENS_USERS token in tOKENS_USERS)
                        //{
                        //    dynamic data = new
                        //    {
                        //        to = token.Token, // Uncoment this if you want to test for single device
                        //                          // registration_ids = singlebatch, // this is for multiple user 
                        //        notification = new
                        //        {
                        //            title = NombreCol,     // Notification title
                        //            body = "Ha realizado una solicitud de " + tipoAusencia.Nombre,    // Notification body data,
                        //            click_action = "FCM_PLUGIN_ACTIVITY",
                        //            icon = "ic_launcher"
                        //            //image= "https://storagebolsaempleo.blob.core.windows.net/archivos/BolsaEmpleo/Foto/1_F.jpg"                                                                                                    // When click on notification user redirect to this link
                        //        },
                        //        data = new
                        //        {
                        //            ruta = "ausencias",

                        //        },
                        //        priority = "normal",
                        //    };

                        //    SendNotification(data);
                        //}


                        string area = db.tNM_Areas.FirstOrDefault(x => x.IdArea == colaboradorSol.IdArea).Descripcion;

                        string departamento = db.tNM_Departamentos.FirstOrDefault(x => x.IdDepartamento == colaboradorSol.IdDepartamento).Descripcion;

                        string cargo = db.tNM_Cargos.FirstOrDefault(x => x.IdCargo == colaboradorSol.IdCargo).Descripcion;
                        string nombreJefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaboradorSol.IdSupervisor).ApellidosNombres;


                        string fechaSolicitud = DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string nombresEmpleado = colaboradorSol.ApellidosNombres;
                        //string area= "Administrativa";
                        //string departamento = "Tecnología";
                        //string cargo = "Programadora de Software";
                        string CI = colaboradorSol.Identificacion;
                        string motivo = tipoAusencia.Nombre;
                        string fechaHoraDesde = solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitud.HoraInicio.Value.ToString("HH:mm");
                        string fechaHoraHasta = solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitud.HoraFin.Value.ToString("HH:mm");
                        string totalHorasDias = solicitud.NumeroHoras.ToString();
                        //string nombreJefe= "Luis Guairacaja";
                        int idSolicitud = solicitud.IdSolicitudPermiso;
                        int? idColaborador = solicitud.Idcolaborador;
                        int? idTipoAusencia = solicitud.IdTipoAusencia;
                        string observaciones = solicitud.Observaciones;

                        Debug.WriteLine(fechaSolicitud);
                        Debug.WriteLine(nombresEmpleado);
                        Debug.WriteLine(area);
                        Debug.WriteLine(departamento);
                        Debug.WriteLine(cargo);
                        Debug.WriteLine(CI);
                        Debug.WriteLine(motivo);
                        Debug.WriteLine(fechaHoraDesde);
                        Debug.WriteLine(fechaHoraHasta);
                        Debug.WriteLine(totalHorasDias);
                        Debug.WriteLine(nombreJefe);
                        Debug.WriteLine(idSolicitud);
                        Debug.WriteLine(idColaborador);

                        List<string> resultSolicitudFile = GeneraSolicitudFilePermisos(fechaSolicitud, nombresEmpleado, area, departamento, cargo, CI, motivo, fechaHoraDesde, fechaHoraHasta, totalHorasDias, nombreJefe, idSolicitud, idColaborador, idTipoAusencia, observaciones);

                        solicitud.UrlSolicitud = resultSolicitudFile[0];


                        db.SaveChanges();
                        dbTransaction.Commit();

                        Debug.WriteLine("--------------------------------");

                        Debug.WriteLine("RUTA AZURE: " + resultSolicitudFile[0]);


                        /*Carga de archivos*/

                        string pathArchivoPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                        Debug.WriteLine(pathArchivoPDF);
                        FileInfo filePDFToSend = new FileInfo(pathArchivoPDF);
                        Adjunto adjunto = null;
                        if (filePDFToSend.Exists)
                        {
                            byte[] bytes = File.ReadAllBytes(pathArchivoPDF);
                            string file64 = Convert.ToBase64String(bytes);

                            adjunto = new Adjunto
                            {
                                Archivo = file64,
                                Nombre = filePDFToSend.Name
                            };
                            System.IO.File.Delete(pathArchivoPDF);
                        }


                        bool enviado= await sendEmailSolicitudAusencia(correoElectronicoJefe, NombreCol, "", solicitud.HoraInicio.Value.ToString("HH:mm"), solicitud.HoraFin.Value.ToString("HH:mm"), solicitud.IdTipoAusencia.Value, tipoAusencia.Nombre, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", "", adjunto);

                        Debug.WriteLine(enviado);
                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });

                        //return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        if (dbTransaction.UnderlyingTransaction.Connection != null)
                            dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();

            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-solicitudpermisoaprobsup")]
        public async Task<HttpResponseMessage> PostSolicitudAprobPermisoCol(tNM_SolicitudPermiso solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;

            try
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var solicitudUpdate = db.tNM_SolicitudPermiso.FirstOrDefault(x => x.IdSolicitudPermiso == solicitud.IdSolicitudPermiso);
                        var tipoAusencia = this.db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitudUpdate.IdTipoAusencia);
                        //solicitud.FechaInicio = DateTime.Parse(solicitud.FechaInicio);
                        solicitudUpdate.IdEstadoAprob = solicitud.IdEstadoAprob;
                        solicitudUpdate.RespuestaSupervisor = solicitud.RespuestaSupervisor;
                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudUpdate.Idcolaborador);
                        var colaboradoSupe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudUpdate.IdSupervisor);
                        db.SaveChanges();
                        dbTransaction.Commit();
                        string body = solicitud.IdEstadoAprob == 2 ? "Ha aprobado su solicitud de " + tipoAusencia.Nombre.ToLower() + "." : "Ha rechazado su solicitud de " + tipoAusencia.Nombre.ToLower() + " " + solicitud.RespuestaSupervisor + ".";
                        /* List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitud.IdSupervisor).ToList();
                         foreach (AGET_TOKENS_USERS token in tOKENS_USERS)
                         {
                             dynamic data = new
                             {
                                 to = token.Token, // Uncoment this if you want to test for single device
                                                   // registration_ids = singlebatch, // this is for multiple user 
                                 notification = new
                                 {
                                     title = colaboradoSupe.nickname == null ? colaboradoSupe.ApellidosNombres.Split(' ')[2] : colaboradoSupe.nickname,     // Notification title
                                     body = body,    // Notification body data,
                                     click_action = "FCM_PLUGIN_ACTIVITY",
                                     icon = "ic_launcher"
                                     //image= "https://storagebolsaempleo.blob.core.windows.net/archivos/BolsaEmpleo/Foto/1_F.jpg"                                                                                                    // When click on notification user redirect to this link
                                 },
                                 data = new
                                 {
                                     ruta = "ausencias",

                                 },
                                 priority = "normal",
                             };

                             SendNotification(data);
                         }*/
                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres.Split(' ')[2] : colaboradorSol.nickname;
                        string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string motivo = solicitudUpdate.RespuestaSupervisor == null ? "" : solicitudUpdate.RespuestaSupervisor;
                        string estadoAprob = db.tNM_EstadosFlujoAusencias.FirstOrDefault(x => x.IDEstado == solicitudUpdate.IdEstadoAprob).Descripcion;



                        bool enviado = await sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", solicitudUpdate.HoraInicio.Value.ToString("HH:mm"), solicitudUpdate.HoraFin.Value.ToString("HH:mm"), solicitudUpdate.IdTipoAusencia.Value, motivo, tipoAusencia.Nombre, solicitudUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", solicitudUpdate.IdEstadoAprob.Value, estadoAprob, "", "");

                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();

            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
         


        public async Task<bool> sendEmailSolicitudAusencia(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string tipoAusencia, string fechaDesde, string FechaHasta, string nombreReemplazo, Adjunto adjunto)
        {
            try
            {
                //Call the api
                Correo correo = new Correo();
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                /*if (correoElectronicoreemplazo != string.Empty) {
                    correo.Listado_CC.Add(correoElectronicoreemplazo);
                }*/
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";
                List<Adjunto> listadoArchivosAdjuntos = new List<Adjunto>();
                if (adjunto != null)
                {
                    listadoArchivosAdjuntos.Add(adjunto);

                }


                var pathArchivoPlantilla = idTipoAusencia == 1 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_VACACIONES"].ToString() : idTipoAusencia == 2 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS"].ToString() : ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_APROB_RECH"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                if (idTipoAusencia == 1)
                {
                    //List<ArchivoAdjunto> adjuntos = new List<ArchivoAdjunto>();
                  /*  ArchivoAdjunto adjuntoSolicitud = new ArchivoAdjunto();
                    adjuntoSolicitud.ContenidoArchivoCodificadoBase64 = adjunto.Archivo;
                    adjuntoSolicitud.NombreArchivo = "Solicitud de Vacaciones.pdf";
                    Debug.WriteLine("--------------ARCHIVO BASE 64--------------");
                    Debug.WriteLine(adjuntoSolicitud.ContenidoArchivoCodificadoBase64);
                    adjuntos.Add(adjuntoSolicitud);*/
                    correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                    cuerpo = cuerpo.Replace("[REEMPLAZO]", nombreReemplazo);
                }
                if (idTipoAusencia == 2)
                {
                    correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                }
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
                    return false ;
                }


                //using (var context = new TALENTO_HUMANOEntities())
                //{
                //    BEMPL_DATOSPOSTULANTE postulante = context.BEMPL_DATOSPOSTULANTE.Find(idPostulante);
                //    postulante.IsEnviadoEmailCandidato = true;
                //    postulante.FechaHoraEnviadoEmailCandidato = DateTime.Now;
                //    context.SaveChanges();
                //}
                return true ;
                //Console.WriteLine($"Candidato {nombresFinal} procesado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion no controlada: {ex.ToString()}");
                return false ;
            }

        }
        public async Task<bool> sendEmailSolicitudAusenciaAprobRech(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string motivo, string tipoAusencia, string fechaDesde, string FechaHasta, int idEstadoAprobacion, string estadoAutorizacion, string nombreReemplazo, string correoElectronicoreemplazo)
        {

            try
            {
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

                var pathArchivoPlantilla = idTipoAusencia == 1 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_VACACIONES"].ToString() : idTipoAusencia == 2 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_PERMISOS"].ToString() : idTipoAusencia == 7 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_MEDICO_HORAS_APROBACION_RECHAZO"].ToString() : ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS_APROBACION_RECHAZO"].ToString();
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
                if (idTipoAusencia == 2)
                {
                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                }
                if(idTipoAusencia == 7)
                {
                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", HoraFin);
                }
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
        public async Task<bool>  sendEmailSolicitudAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe, int? idTipoAusencia, string horaIni, string horaFin, Adjunto adjunto)
        {
            try
            {
                //Call the api
                Correo correo = new Correo();
                //string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";
                string cuerpo;
               correo.Listado_TO.Add(correojefe);
                //if (correoElectronicoreemplazo != string.Empty) {
                    correo.Listado_CC.Add(correoUsuario);
                   // correo.Listado_CC.Add(correoTalentoHumano);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";
                if(idTipoAusencia != null && idTipoAusencia == 7)
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;

                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", horaFin);
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

                List<Adjunto> listadoArchivosAdjuntos = new List<Adjunto>();
                if (adjunto != null)
                {
                    listadoArchivosAdjuntos.Add(adjunto);

                }

                correo.ListadoArchivosAdjuntos = listadoArchivosAdjuntos;
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
        public async Task<bool> sendEmailAprobacionRechazoAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe,string motivo,string estadoAutorizacion, int? idTipoAusencia,string horaIni, string horaFin)
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

                if (idTipoAusencia != null && idTipoAusencia == 7)
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_PERMISOS"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;

                    cuerpo = cuerpo.Replace("[FECHA]", fechaDesde);
                    cuerpo = cuerpo.Replace("[HORA_INI]", horaIni);
                    cuerpo = cuerpo.Replace("[HORA_FIN]", horaFin);
                }
                else
                {
                    var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS_APROBACION_RECHAZO"].ToString();
                    cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                    cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                    cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                }
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
        public List<string> GeneraSolicitudFile(string json, int idSolicitud, int idColaborador)
        {
            List<string> results = new List<string>();
            try
            {

                SolicitudVacacion reportSolicitud = new SolicitudVacacion();

                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudVacacion_") + idSolicitud + "_" + idColaborador + ".pdf";
                JsonDataSource jsd = new JsonDataSource();
                jsd.JsonSource = new CustomJsonSource(json);
                jsd.Fill();
                reportSolicitud.DataSource = jsd;
                reportSolicitud.ExportToPdf(path);
                results = getUrlAzure(path);

                SeriLog.GuardarLogApplicacionSerilog("URL SOLICITUD: " + results[0] , Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                // System.IO.File.Delete(path);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
            }
            return results;
        }


        public List<string> GeneraSolicitudFilePermisos(string fechaSolicitud, string nombresEmpleado, string area, string departamento, string cargo, string CI, string motivo, string fechaHoraDesde, string fechaHoraHasta, string totalHorasDias, string nombreJefe, int idSolicitud, int? idColaborador, int? idTipoAusencia, string observaciones)
        {
            List<string> results = new List<string>();
            try
            {
                SolicitudPermiso reportSolicitud = new SolicitudPermiso();

                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                Debug.WriteLine("Iniciando generacion de documento.");
                Debug.WriteLine("PATH: "+ path);
                string directory = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                reportSolicitud.xrFechaSolicitud.Text = fechaSolicitud ?? string.Empty;
                reportSolicitud.xrNombresEmpleado.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrArea.Text = area ?? string.Empty;
                reportSolicitud.xrDepartamento.Text = departamento ?? string.Empty;
                reportSolicitud.xrCargo.Text = cargo ?? string.Empty;
                reportSolicitud.xrCI.Text = CI ?? string.Empty;
                reportSolicitud.xrMotivo.Text = motivo ?? string.Empty;
                reportSolicitud.xrDesde.Text = fechaHoraDesde ?? string.Empty;
                reportSolicitud.xrHasta.Text = fechaHoraHasta ?? string.Empty;
                reportSolicitud.xrTableTituloTotalHorasDias.Text = idTipoAusencia == 7 || idTipoAusencia == 2 ? "Total horas" : "Total días";
                reportSolicitud.xrTotalDiasHoras.Text = totalHorasDias ?? string.Empty;
                reportSolicitud.xrNombreTrabajador.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrNombreJefe.Text = nombreJefe ?? string.Empty;
                reportSolicitud.xrObservaciones.Text = observaciones ?? string.Empty;

                Debug.WriteLine("Exportando a PDF...");
                reportSolicitud.ExportToPdf(path);
                Debug.WriteLine("PDF generado exitosamente en: " + path);

                results = getUrlAzure(path);
            }
            catch (DevExpress.XtraReports.DataRetrievalException dex)
            {
                Debug.WriteLine("Error de recuperación de datos DevExpress: " + dex.Message);
                Debug.WriteLine("InnerException: " + (dex.InnerException?.Message ?? "None"));
                throw new Exception("Error al recuperar datos para el reporte: " + dex.Message, dex);
            }
            catch (System.Data.Entity.Core.EntityException eex)
            {
                Debug.WriteLine("Error de Entity Framework: " + eex.Message);
                Debug.WriteLine("InnerException: " + (eex.InnerException?.Message ?? "None"));
                throw new Exception("Error de base de datos: " + eex.Message, eex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error general: " + ex.Message);
                Debug.WriteLine("InnerException: " + (ex.InnerException?.Message ?? "None"));
                Debug.WriteLine("StackTrace: " + ex.StackTrace);
                throw;
            }
            return results;
        }
        public List<string> getUrlAzure(string path)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string url = "";
            List<string> results = new List<string>();
            string filename = Path.GetFileName(path);
            string extension = Path.GetExtension(filename);
            string contentType = "application/pdf";//Path. provider.Contents[index].Headers.ContentType.MediaType;
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccountCCQ"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("ccq");

            CloudBlobDirectory directory = container.GetDirectoryReference("erp/Nomina/SolicitudesVacaciones");
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                string key = filename;
                CloudBlockBlob b = directory.GetBlockBlobReference(key);
                b.Properties.ContentType = contentType;
                b.UploadFromByteArray(bytes, 0, bytes.Length);
                url = b.StorageUri.PrimaryUri.AbsoluteUri;
                results.Add(url);
                results.Add(Convert.ToBase64String(bytes));
            }
            catch (StorageException ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
                //return thr;
            }
            return results;
        }



        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-permisos-otros")]
        async public Task<HttpResponseMessage> PostPermisosOtros()
        {

            try
            {
                tNM_SolicitudPermiso solicitudPermiso = new tNM_SolicitudPermiso();
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }
                var provider = await Request.Content.ReadAsMultipartAsync();
                string solicitudCabjson = await provider.Contents[0].ReadAsStringAsync();

                provider.Contents.Remove(provider.Contents[0]);
                solicitudPermiso = JsonConvert.DeserializeObject<tNM_SolicitudPermiso>(solicitudCabjson);
                string correoJefe = db.tNM_Colaboradores.First(x => x.IdColaborador == solicitudPermiso.IdSupervisor).tGN_Personas.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13).Contacto;
                string correoSolicitante = db.tNM_Colaboradores.First(x => x.IdColaborador == solicitudPermiso.Idcolaborador).tGN_Personas.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13).Contacto;

                correoJefe = correoJefe?.Trim();
                correoSolicitante = correoSolicitante?.Trim();

                bool correoJefeInvalido = string.IsNullOrWhiteSpace(correoJefe);
                bool correoSolicitanteInvalido = string.IsNullOrWhiteSpace(correoSolicitante);
                if (correoJefeInvalido || correoSolicitanteInvalido)
                {
                    Debug.WriteLine("CAMPOS VACIOS");

                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del supervisor no existe. Por favor, regularice el tema con talento humano. ";
                    if (correoSolicitanteInvalido) errorMensaje += "correo electrónico del solicitante no existe. Por favor, regularice el tema con talento humano. ";

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }

                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Find(solicitudPermiso.Idcolaborador);
                //CodigosValidacion codigoValidacion = db.CodigosValidacion.FirstOrDefault(x => x.Código == formulario.Codigo && x.GUID == formulario.GUID);
                //if (codigoValidacion == null)
                //{
                //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código de validación incorrecto.");
                //}
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tNM_TiposAusencia tNM_TiposAusencia = db.tNM_TiposAusencia.Find(solicitudPermiso.IdTipoAusencia);
                        if (tNM_TiposAusencia.ApruebaJefe.Value)
                        {
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PAJ").IDEstado;
                        }
                        else
                        {
                            if (tNM_TiposAusencia.ApruebaTTHH.Value)
                                solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PATTH").IDEstado;
                        }
                        db.tNM_SolicitudPermiso.Add(solicitudPermiso);
                        db.SaveChanges();

                        List<tNM_AdjuntoSolicitudPermiso> adjuntosDB = new List<tNM_AdjuntoSolicitudPermiso>();
                        foreach (var file in provider.Contents)
                        {
                            tNM_AdjuntoSolicitudPermiso tNM_AdjuntoSolicitudPermiso = new tNM_AdjuntoSolicitudPermiso();
                            tNM_AdjuntoSolicitudPermiso.IdSolicitudPermiso = solicitudPermiso.IdSolicitudPermiso;
                            var url = getUrlAzurePermisos(file, solicitudPermiso.Idcolaborador.Value).Result;
                            tNM_AdjuntoSolicitudPermiso.UrlAdjunto = url;
                            tNM_AdjuntoSolicitudPermiso.NombreArchivo = file.Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();

                            adjuntosDB.Add(tNM_AdjuntoSolicitudPermiso);
                        }
                        if (adjuntosDB.Count > 0)
                        {
                            db.tNM_AdjuntoSolicitudPermiso.AddRange(adjuntosDB);
                            db.SaveChanges();
                        }


                        string area = db.tNM_Areas.FirstOrDefault(x => x.IdArea == colaborador.IdArea).Descripcion;

                        string departamento = db.tNM_Departamentos.FirstOrDefault(x => x.IdDepartamento == colaborador.IdDepartamento).Descripcion;

                        string cargo = db.tNM_Cargos.FirstOrDefault(x => x.IdCargo == colaborador.IdCargo).Descripcion;
                        string nombreJefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaborador.IdSupervisor).ApellidosNombres;


                        string fechaSolicitud = DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string nombresEmpleado = colaborador.ApellidosNombres;
                        //string area= "Administrativa";
                        //string departamento = "Tecnología";
                        //string cargo = "Programadora de Software";
                        string CI = colaborador.Identificacion;
                        string motivo = tNM_TiposAusencia.Nombre;
                        string fechaHoraDesde = solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string fechaHoraHasta = solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string totalHorasDias = solicitudPermiso.DiasSolicitados.ToString();
                        //string nombreJefe= "Luis Guairacaja";
                        int idSolicitud = solicitudPermiso.IdSolicitudPermiso;
                        int? idColaborador = solicitudPermiso.Idcolaborador;
                        int? idTipoAusencia = solicitudPermiso.IdTipoAusencia;
                        string observaciones = solicitudPermiso.Observaciones;

                        Debug.WriteLine(fechaSolicitud);
                        Debug.WriteLine(nombresEmpleado);
                        Debug.WriteLine(area);
                        Debug.WriteLine(departamento);
                        Debug.WriteLine(cargo);
                        Debug.WriteLine(CI);
                        Debug.WriteLine(motivo);
                        Debug.WriteLine(fechaHoraDesde);
                        Debug.WriteLine(fechaHoraHasta);
                        Debug.WriteLine(totalHorasDias);
                        Debug.WriteLine(nombreJefe);
                        Debug.WriteLine(idSolicitud);
                        Debug.WriteLine(idColaborador);

                        List<string> resultSolicitudFile = GeneraSolicitudFilePermisos(fechaSolicitud, nombresEmpleado, area, departamento, cargo, CI, motivo, fechaHoraDesde, fechaHoraHasta, totalHorasDias, nombreJefe, idSolicitud, idColaborador, idTipoAusencia, observaciones);

                        solicitudPermiso.UrlSolicitud = resultSolicitudFile[0];


                        db.SaveChanges();
                       //dbTransaction.Commit();

                        Debug.WriteLine("--------------------------------");

                        Debug.WriteLine("RUTA AZURE: " + resultSolicitudFile[0]);


                        /*Carga de archivos*/

                        string pathArchivoPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                        Debug.WriteLine(pathArchivoPDF);
                        FileInfo filePDFToSend = new FileInfo(pathArchivoPDF);
                        Adjunto adjunto = null;
                        if (filePDFToSend.Exists)
                        {
                            byte[] bytes = File.ReadAllBytes(pathArchivoPDF);
                            string file64 = Convert.ToBase64String(bytes);

                            adjunto = new Adjunto
                            {
                                Archivo = file64,
                                Nombre = filePDFToSend.Name
                            };
                            System.IO.File.Delete(pathArchivoPDF);
                        }

                        bool enviado = await sendEmailSolicitudAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), correoJefe, solicitudPermiso.IdTipoAusencia, "", "", adjunto);
                        dbTransaction.Commit();


                        Debug.WriteLine(enviado);
                        if (!enviado)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                        }

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });
                        //BuzonCCQTiposFeedBack tipos = db.BuzonCCQTiposFeedBack.FirstOrDefault(x => x.IdTipoFeedBack == formularioDB.IdTipoFeedBack);
                        //formularioDB.BuzonCCQTiposFeedBack = tipos;
                        //sendEmailUserInterno(formularioDB);
                        //sendEmailUser(formularioDB.Nombres, formularioDB.Correo);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }


        //PERMISO MÉDICO POR HORAS
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-permisos-medico-horas")]
        async public Task<HttpResponseMessage> PostPermisosMedicoHoras()
        {

            try
            {
                tNM_SolicitudPermiso solicitudPermiso = new tNM_SolicitudPermiso();
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }
                var provider = await Request.Content.ReadAsMultipartAsync();
                string solicitudCabjson = await provider.Contents[0].ReadAsStringAsync();

                provider.Contents.Remove(provider.Contents[0]);
                solicitudPermiso = JsonConvert.DeserializeObject<tNM_SolicitudPermiso>(solicitudCabjson);
                string correoJefe = db.tNM_Colaboradores.First(x => x.IdColaborador == solicitudPermiso.IdSupervisor).tGN_Personas.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13).Contacto;
                string correoSolicitante = db.tNM_Colaboradores.First(x => x.IdColaborador == solicitudPermiso.Idcolaborador).tGN_Personas.tGN_ContactoPersona.First(x => x.IdMedioContacto == 13).Contacto;

                correoJefe = correoJefe?.Trim();
                correoSolicitante = correoSolicitante?.Trim();

                bool correoJefeInvalido = string.IsNullOrWhiteSpace(correoJefe);
                bool correoSolicitanteInvalido = string.IsNullOrWhiteSpace(correoSolicitante);
                if (correoJefeInvalido || correoSolicitanteInvalido)
                {
                    Debug.WriteLine("CAMPOS VACIOS");

                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del supervisor no existe. Por favor, regularice el tema con talento humano. ";
                    if (correoSolicitanteInvalido) errorMensaje += "correo electrónico del solicitante no existe. Por favor, regularice el tema con talento humano. ";

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }

                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Find(solicitudPermiso.Idcolaborador);
                //CodigosValidacion codigoValidacion = db.CodigosValidacion.FirstOrDefault(x => x.Código == formulario.Codigo && x.GUID == formulario.GUID);
                //if (codigoValidacion == null)
                //{
                //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Código de validación incorrecto.");
                //}
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tNM_TiposAusencia tNM_TiposAusencia = db.tNM_TiposAusencia.Find(solicitudPermiso.IdTipoAusencia);
                        if (tNM_TiposAusencia.ApruebaJefe.Value)
                        {
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PAJ").IDEstado;
                        }
                        else
                        {
                            if (tNM_TiposAusencia.ApruebaTTHH.Value)
                                solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PATTH").IDEstado;
                        }
                        db.tNM_SolicitudPermiso.Add(solicitudPermiso);
                        db.SaveChanges();

                        List<tNM_AdjuntoSolicitudPermiso> adjuntosDB = new List<tNM_AdjuntoSolicitudPermiso>();
                        foreach (var file in provider.Contents)
                        {
                            tNM_AdjuntoSolicitudPermiso tNM_AdjuntoSolicitudPermiso = new tNM_AdjuntoSolicitudPermiso();
                            tNM_AdjuntoSolicitudPermiso.IdSolicitudPermiso = solicitudPermiso.IdSolicitudPermiso;
                            var url = getUrlAzurePermisos(file, solicitudPermiso.Idcolaborador.Value).Result;
                            tNM_AdjuntoSolicitudPermiso.UrlAdjunto = url;
                            tNM_AdjuntoSolicitudPermiso.NombreArchivo = file.Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();

                            adjuntosDB.Add(tNM_AdjuntoSolicitudPermiso);
                        }
                        if (adjuntosDB.Count > 0)
                        {
                            db.tNM_AdjuntoSolicitudPermiso.AddRange(adjuntosDB);
                            db.SaveChanges();
                        }

                        //dbTransaction.Commit();


                        string area = db.tNM_Areas.FirstOrDefault(x => x.IdArea == colaborador.IdArea).Descripcion;

                        string departamento = db.tNM_Departamentos.FirstOrDefault(x => x.IdDepartamento == colaborador.IdDepartamento).Descripcion;

                        string cargo = db.tNM_Cargos.FirstOrDefault(x => x.IdCargo == colaborador.IdCargo).Descripcion;
                        string nombreJefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaborador.IdSupervisor).ApellidosNombres;


                        string fechaSolicitud = DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string nombresEmpleado = colaborador.ApellidosNombres;
                        //string area= "Administrativa";
                        //string departamento = "Tecnología";
                        //string cargo = "Programadora de Software";
                        string CI = colaborador.Identificacion;
                        string motivo = tNM_TiposAusencia.Nombre;
                        string fechaHoraDesde = solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitudPermiso.HoraInicio.Value.ToString("HH:mm");
                        string fechaHoraHasta = solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitudPermiso.HoraFin.Value.ToString("HH:mm");
                        string totalHorasDias = solicitudPermiso.NumeroHoras.ToString();
                        //string nombreJefe= "Luis Guairacaja";
                        int idSolicitud = solicitudPermiso.IdSolicitudPermiso;
                        int? idColaborador = solicitudPermiso.Idcolaborador;
                        int? idTipoAusencia = solicitudPermiso.IdTipoAusencia;
                        string observaciones= solicitudPermiso.Observaciones;

                        Debug.WriteLine(fechaSolicitud);
                        Debug.WriteLine(nombresEmpleado);
                        Debug.WriteLine(area);
                        Debug.WriteLine(departamento);
                        Debug.WriteLine(cargo);
                        Debug.WriteLine(CI);
                        Debug.WriteLine(motivo);
                        Debug.WriteLine(fechaHoraDesde);
                        Debug.WriteLine(fechaHoraHasta);
                        Debug.WriteLine(totalHorasDias);
                        Debug.WriteLine(nombreJefe);
                        Debug.WriteLine(idSolicitud);
                        Debug.WriteLine(idColaborador);

                        List<string> resultSolicitudFile = GeneraSolicitudFilePermisos(fechaSolicitud, nombresEmpleado, area, departamento, cargo, CI, motivo, fechaHoraDesde, fechaHoraHasta, totalHorasDias, nombreJefe, idSolicitud, idColaborador, idTipoAusencia, observaciones);

                        solicitudPermiso.UrlSolicitud = resultSolicitudFile[0];

                        
                        db.SaveChanges();
                        dbTransaction.Commit();

                        Debug.WriteLine("--------------------------------");

                        Debug.WriteLine("RUTA AZURE: " + resultSolicitudFile[0]);


                        /*Carga de archivos*/

                        string pathArchivoPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                        Debug.WriteLine(pathArchivoPDF);
                        FileInfo filePDFToSend = new FileInfo(pathArchivoPDF);
                        Adjunto adjunto = null;
                        if (filePDFToSend.Exists)
                        {
                            byte[] bytes = File.ReadAllBytes(pathArchivoPDF);
                            string file64 = Convert.ToBase64String(bytes);

                            adjunto = new Adjunto
                            {
                                Archivo = file64,
                                Nombre = filePDFToSend.Name
                            };
                            System.IO.File.Delete(pathArchivoPDF);
                        }

                        bool enviado = await sendEmailSolicitudAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), " ", correoJefe, solicitudPermiso.IdTipoAusencia, solicitudPermiso.HoraInicio.Value.ToString("HH:mm"), solicitudPermiso.HoraFin.Value.ToString("HH:mm"), adjunto);


                        Debug.WriteLine(enviado);
                        if (!enviado)
                         {
                             return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No se pudo enviar el correo.");
                         }

                         return Request.CreateResponse(HttpStatusCode.OK, new
                         {
                             mensaje = "Solicitud enviada correctamente",
                             correoEnviado = true
                         });

                        
                        //db.SaveChanges();
                        //return Request.CreateResponse(HttpStatusCode.OK, "OK");
                        //BuzonCCQTiposFeedBack tipos = db.BuzonCCQTiposFeedBack.FirstOrDefault(x => x.IdTipoFeedBack == formularioDB.IdTipoFeedBack);
                        //formularioDB.BuzonCCQTiposFeedBack = tipos;
                        //sendEmailUserInterno(formularioDB);
                        //sendEmailUser(formularioDB.Nombres, formularioDB.Correo);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        public async Task<string> getUrlAzurePermisos(HttpContent provider, int idColaborador)
        {
            string url = "";
            Stream fileStream = await provider.ReadAsStreamAsync();
            string filename = provider.Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();
            string extension = Path.GetExtension(filename);
            string contentType = provider.Headers.ContentType.MediaType;
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccountCCQ"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("ccq");

            CloudBlobDirectory directory = container.GetDirectoryReference("erp/Nomina/SolicitudesPermisos/" + idColaborador);
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                string key = filename;
                CloudBlockBlob b = directory.GetBlockBlobReference(key);
                b.Properties.ContentType = contentType;
                b.UploadFromStream(fileStream);
                url = b.StorageUri.PrimaryUri.AbsoluteUri;
            }
            catch (StorageException ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
                //return thr;
            }
            //List<string> results = new List<string>();
            //results.Add(url);
            //results.Add(filename);
            return url;
        }
        // PUT: api/tNM_SolicitudVacacionesCab/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_SolicitudVacacionesCab(int id, tNM_SolicitudVacacionesCab tNM_SolicitudVacacionesCab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_SolicitudVacacionesCab.IdSolicitudVacaciones)
            {
                return BadRequest();
            }

            db.Entry(tNM_SolicitudVacacionesCab).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_SolicitudVacacionesCabExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tNM_SolicitudVacacionesCab
        [ResponseType(typeof(tNM_SolicitudVacacionesCab))]
        public async Task<IHttpActionResult> PosttNM_SolicitudVacacionesCab(tNM_SolicitudVacacionesCab tNM_SolicitudVacacionesCab)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_SolicitudVacacionesCab.Add(tNM_SolicitudVacacionesCab);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_SolicitudVacacionesCab.IdSolicitudVacaciones }, tNM_SolicitudVacacionesCab);
        }

        // DELETE: api/tNM_SolicitudVacacionesCab/5
        [ResponseType(typeof(tNM_SolicitudVacacionesCab))]
        public async Task<IHttpActionResult> DeletetNM_SolicitudVacacionesCab(int id)
        {
            tNM_SolicitudVacacionesCab tNM_SolicitudVacacionesCab = await db.tNM_SolicitudVacacionesCab.FindAsync(id);
            if (tNM_SolicitudVacacionesCab == null)
            {
                return NotFound();
            }

            db.tNM_SolicitudVacacionesCab.Remove(tNM_SolicitudVacacionesCab);
            await db.SaveChangesAsync();

            return Ok(tNM_SolicitudVacacionesCab);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_SolicitudVacacionesCabExists(int id)
        {
            return db.tNM_SolicitudVacacionesCab.Count(e => e.IdSolicitudVacaciones == id) > 0;
        }
    }
}