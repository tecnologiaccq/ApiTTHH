using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
using ApiTTHH.ApiModel.Mail;
using ApiTTHH.Models;
using Ccq;
using DevExpress.DataAccess.Json;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Newtonsoft.Json;
using OnLineCCQ.ApiEnvioCorreoAlphaTech;
using RestSharp;

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
        public HttpResponseMessage PostSolicitudVacacionesCol(tNM_SolicitudVacacionesCab solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;

            int count = db.tNM_SolicitudVacacionesCab.Where(x => x.IdEstadoAprob == 1 && x.IdColaborador == solicitud.IdColaborador).Count();
            if (count > 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tiene solicitudes pendientes de aprobación por jefatura. No se puede enviar solicitud");
            }

            try
            {
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
                                    diasDescontar = diasDescontar - periodo.DiasPendientes;
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
                        db.SaveChanges();
                        dbTransaction.Commit();
                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres : colaboradorSol.nickname;
                        List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitud.IdSupervisor).ToList();
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
                        }
                        var jefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdSupervisor);
                        var colaboradorReemplazo = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaboradorReemplazo);
                        string nombreReemplazo = colaboradorReemplazo.ApellidosNombres;
                        string correoElectronicoJefe = "czapata@lacamaradequito.com"; //db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == jefe.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string correoElectronicoReemplazo = "czapata@lacamaradequito.com"; //db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorReemplazo.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string tipoAusencia = db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitud.IdTipoAusencia).Nombre;
                        sendEmailSolicitudAusencia(correoElectronicoJefe, NombreCol, "", "", "", solicitud.IdTipoAusencia.Value, tipoAusencia, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), nombreReemplazo, correoElectronicoReemplazo, resultSolicitudFile[1]);

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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/solictud-aprobarRechazar")]
        public HttpResponseMessage PostSolicitudVacacioneesAprobarRechazar(tNM_SolicitudVacacionesCab solicitud)
        {
            db.Configuration.LazyLoadingEnabled = false;

            try
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tNM_SolicitudVacacionesCab solicitudCabUpdate = db.tNM_SolicitudVacacionesCab.FirstOrDefault(x => x.IdSolicitudVacaciones == solicitud.IdSolicitudVacaciones);
                        solicitudCabUpdate.IdEstadoAprob = solicitud.IdEstadoAprob;
                        solicitudCabUpdate.RespuestaSupervisor = solicitud.RespuestaSupervisor;
                        solicitudCabUpdate.FechaAprobacionSupervisor = DateTime.Now;
                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudCabUpdate.IdColaborador);
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
                                //historialUpdate.FinesSemana = 2;
                                db.tNM_DetalleVacaciones.Add(detallevacacionFin);

                            }
                        }
                        db.SaveChanges();
                        dbTransaction.Commit();
                        string body = solicitud.IdEstadoAprob == 2 ? "Ha aprobado su solicitud de vacaciones." : "Ha rechazado su solicitud de vacaciones." + solicitud.RespuestaSupervisor;
                        List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitudCabUpdate.IdColaborador).ToList();
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
                        }

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres : colaboradorSol.nickname;
                        string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string tipoAusencia = db.tNM_TiposAusencia.FirstOrDefault(x => x.IdAusencia == solicitudCabUpdate.IdTipoAusencia).Nombre;
                        string motivo = solicitudCabUpdate.RespuestaSupervisor == null ? "" : solicitudCabUpdate.RespuestaSupervisor;
                        string estadoAprob = db.tNM_EstadosFlujoAusencias.FirstOrDefault(x => x.IDEstado == solicitudCabUpdate.IdEstadoAprob).Descripcion;
                        var colaboradorReemplazo = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitudCabUpdate.IdColaboradorReemplazo);
                        string nombreReemplazo = colaboradorReemplazo.ApellidosNombres;
                        string correoElectronicoReemplazo = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorReemplazo.IdPersona && x.IdMedioContacto == 13).Contacto;
                        sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", "", "", solicitudCabUpdate.IdTipoAusencia.Value, motivo, tipoAusencia, solicitudCabUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.IdEstadoAprob.Value, estadoAprob, nombreReemplazo, correoElectronicoReemplazo);


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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/solicitud-aprobarRechazar-permisotthh")]
        public HttpResponseMessage PostSolicitudPermisoAprobarRechazar(tNM_SolicitudPermiso solicitud)
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
                        sendEmailAprobacionRechazoAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), permisoSolicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), correoJefe, solicitud.RespuestaTalentoHumano == null ? "": solicitud.RespuestaTalentoHumano, estadosFlujoAusencias.Descripcion) ;
                        dbTransaction.Commit();
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
        public HttpResponseMessage PostSolicitudPermisoCol(tNM_SolicitudPermiso solicitud)
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
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        //solicitud.FechaInicio = DateTime.Parse(solicitud.FechaInicio);
                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.Idcolaborador);
                        solicitud.IdSupervisor = colaboradorSol.IdSupervisor;
                        solicitud.IdEstadoAprob = 1;
                        db.tNM_SolicitudPermiso.Add(solicitud);
                        db.SaveChanges();
                        dbTransaction.Commit();

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
                        var jefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaboradorSol.IdSupervisor);
                        string correoElectronicoJefe = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == jefe.IdPersona && x.IdMedioContacto == 13).Contacto;
                        sendEmailSolicitudAusencia(correoElectronicoJefe, NombreCol, "", solicitud.HoraInicio.Value.ToString("HH:mm"), solicitud.HoraFin.Value.ToString("HH:mm"), solicitud.IdTipoAusencia.Value, tipoAusencia.Nombre, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", "", "", "");

                        return Request.CreateResponse(HttpStatusCode.OK);
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
        public HttpResponseMessage PostSolicitudAprobPermisoCol(tNM_SolicitudPermiso solicitud)
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
                        List<AGET_TOKENS_USERS> tOKENS_USERS = espaciosDB.AGET_TOKENS_USERS.Where(x => x.IdColaborador == solicitud.IdSupervisor).ToList();
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
                        }
                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres.Split(' ')[2] : colaboradorSol.nickname;
                        string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string motivo = solicitudUpdate.RespuestaSupervisor == null ? "" : solicitudUpdate.RespuestaSupervisor;
                        string estadoAprob = db.tNM_EstadosFlujoAusencias.FirstOrDefault(x => x.IDEstado == solicitudUpdate.IdEstadoAprob).Descripcion;

                        sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", solicitudUpdate.HoraInicio.Value.ToString("HH:mm"), solicitudUpdate.HoraFin.Value.ToString("HH:mm"), solicitudUpdate.IdTipoAusencia.Value, motivo, tipoAusencia.Nombre, solicitudUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", solicitudUpdate.IdEstadoAprob.Value, estadoAprob, "", "");
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
        public void SendNotification(dynamic data)
        {
            try
            {


                //var serializer = new JavaScriptSerializer();
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                string SERVER_API_KEY = "AAAAio-zJ2I:APA91bE8bl1sRShB7Ue12jg31vK-r7qEaaB2yUx2ArD_uyvhRfKIUj2s5lXU_1uLfrIa79oKO4gzyxZ0DE3t0gji3JfYdfuM6nRwFNSAiSuCTob1p2ab8zwF0qXnNqQobWzk2fo3n32O";
                string SENDER_ID = "595116369762";

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void sendEmailSolicitudAusencia(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string tipoAusencia, string fechaDesde, string FechaHasta, string nombreReemplazo, string correoElectronicoreemplazo, string base64File)
        {
            try
            {
                //Call the api
                //Obtener Proveedor
                var result = db.Adm_ApiProvider.Where(p => p.IdApiProvider == (int)Enums.Proveedor.AlphaTech).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Error al obtener Proveedor");
                    return;
                }

                var urlBase = result.UrlBase;
                var metodoSendMail = result.Metodo;

                var client = new RestClient();
                var request = new RestRequest($"{urlBase}{metodoSendMail}", Method.Post);

                var correo = new MailStructureModel();
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                //if (correoElectronicoreemplazo != string.Empty) {
                //    correo.Listado_CC.Add(correoElectronicoreemplazo);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";

                var pathArchivoPlantilla = idTipoAusencia == 1 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_VACACIONES"].ToString() : idTipoAusencia == 2 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS"].ToString() : ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_APROB_RECH"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                if (idTipoAusencia == 1)
                {
                    List<AttachmentModel> adjuntos = new List<AttachmentModel>();
                    AttachmentModel adjuntoSolicitud = new AttachmentModel();
                    adjuntoSolicitud.Archivo = base64File;
                    adjuntoSolicitud.Nombre = "Solicitud de Vacaciones.pdf";
                    adjuntos.Add(adjuntoSolicitud);
                    correo.ListadoArchivosAdjuntos = adjuntos;
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
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API

                // Json to put.
                var jsonToSend = JsonConvert.SerializeObject(correo, Formatting.Indented);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/xml");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(jsonToSend);

                var response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.ErrorMessage}");
                    Console.ReadLine();
                    return;
                }

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
            }

        }
        public void sendEmailSolicitudAusenciaAprobRech(string correoUsuario, string nombres, string fecha, string horaIni, string HoraFin, int idTipoAusencia, string motivo, string tipoAusencia, string fechaDesde, string FechaHasta, int idEstadoAprobacion, string estadoAutorizacion, string nombreReemplazo, string correoElectronicoreemplazo)
        {
            try
            {
                //Obtener Proveedor
                var result = db.Adm_ApiProvider.Where(p => p.IdApiProvider == (int)Enums.Proveedor.AlphaTech).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Error al obtener Proveedor");
                    return;
                }

                var urlBase = result.UrlBase;
                var metodoSendMail = result.Metodo;

                var client = new RestClient();
                var request = new RestRequest($"{urlBase}{metodoSendMail}", Method.Post);

                var correo = new MailStructureModel();
                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                if (correoElectronicoreemplazo != string.Empty)
                {
                    if (idEstadoAprobacion == 2)
                    {
                        correo.Listado_CC.Add(correoElectronicoreemplazo);
                    }
                }
                if (idEstadoAprobacion == 2)
                {
                    correo.Listado_CC.Add(correoTalentoHumano);
                }
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";

                var pathArchivoPlantilla = idTipoAusencia == 1 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_VACACIONES"].ToString() : idTipoAusencia == 2 ? ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_JEFE_APROB_PERMISOS"].ToString() : ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_APROB_RECH"].ToString();
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
                cuerpo = cuerpo.Replace("[ESTADO_AUTORIZACION]", estadoAutorizacion.ToLower()); ;
                cuerpo = cuerpo.Replace("[MOTIVO]", motivo);
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                // Json to put.
                var jsonToSend = JsonConvert.SerializeObject(correo, Formatting.Indented);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/xml");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(jsonToSend);

                var response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.ErrorMessage}");
                    Console.ReadLine();
                    return;
                }

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
            }

        }
        public void sendEmailSolicitudAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe)
        {
            try
            {
                //Call the api
                //Obtener Proveedor
                var result = db.Adm_ApiProvider.Where(p => p.IdApiProvider == (int)Enums.Proveedor.AlphaTech).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Error al obtener Proveedor");
                    return;
                }

                var urlBase = result.UrlBase;
                var metodoSendMail = result.Metodo;

                var client = new RestClient();
                var request = new RestRequest($"{urlBase}{metodoSendMail}", Method.Post);

                var correo = new MailStructureModel();
                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";
                
                correo.Listado_TO.Add(correoTalentoHumano);
                //if (correoElectronicoreemplazo != string.Empty) {
                    correo.Listado_CC.Add(correoUsuario);
                    correo.Listado_CC.Add(correojefe);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";


                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;
                
                  
                    
                    cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                    cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                    
                
              
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                // Json to put.
                var jsonToSend = JsonConvert.SerializeObject(correo, Formatting.Indented);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/xml");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(jsonToSend);

                var response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.ErrorMessage}");
                    Console.ReadLine();
                    return;
                }

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
            }

        }
        public void sendEmailAprobacionRechazoAusenciaOtros(string correoUsuario, string nombres, string tipoAusencia, string fechaDesde, string FechaHasta, string correojefe,string motivo,string estadoAutorizacion)
        {
            try
            {
                //Call the api
                //Obtener Proveedor
                var result = db.Adm_ApiProvider.Where(p => p.IdApiProvider == (int)Enums.Proveedor.AlphaTech).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Error al obtener Proveedor");
                    return;
                }

                var urlBase = result.UrlBase;
                var metodoSendMail = result.Metodo;

                var client = new RestClient();
                var request = new RestRequest($"{urlBase}{metodoSendMail}", Method.Post);

                var correo = new MailStructureModel();
                string correoTalentoHumano = ConfigurationManager.AppSettings["CORREO_TALENTOHUMANO"];
                correo.CodigoAplicacionInterna = "01";

                correo.Listado_TO.Add(correoUsuario);
                //if (correoElectronicoreemplazo != string.Empty) {
                correo.Listado_CC.Add(correoTalentoHumano);
                correo.Listado_CC.Add(correojefe);
                //}
                correo.TituloSubject = "SOLICITUD DE AUSENCIA";


                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL_SOLIC_AUSENCIA_PERMISOS_OTROS_APROBACION_RECHAZO"].ToString();
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_COLABORADOR]", nombres);
                cuerpo = cuerpo.Replace("[TIPO_AUSENCIA]", tipoAusencia.ToLower()); ;



                cuerpo = cuerpo.Replace("[FECHA_DESDE]", fechaDesde);
                cuerpo = cuerpo.Replace("[FECHA_HASTA]", FechaHasta);
                cuerpo = cuerpo.Replace("[ESTADO_AUTORIZACION]", estadoAutorizacion.ToLower());
                cuerpo = cuerpo.Replace("[MOTIVO]", motivo);


                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                // Json to put.
                var jsonToSend = JsonConvert.SerializeObject(correo, Formatting.Indented);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/xml");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(jsonToSend);

                var response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.ErrorMessage}");
                    Console.ReadLine();
                    return;
                }

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
                System.IO.File.Delete(path);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
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
                        sendEmailSolicitudAusenciaOtros(correoSolicitante,colaborador.ApellidosNombres , tNM_TiposAusencia.Nombre, solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), correoJefe);
                        dbTransaction.Commit();
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
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
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