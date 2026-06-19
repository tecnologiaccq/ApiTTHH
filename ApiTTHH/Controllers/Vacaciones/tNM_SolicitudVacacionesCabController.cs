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
using ApiTTHH.Comun.Permisos;

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
                string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaborador.IdPersona && x.IdMedioContacto == 13).Contacto;
                SeriLog.GuardarLogApplicacionSerilog(correoElectronicoJefe, Enumeraciones.EnumNivelesSeriLog.INFORMATION);
                SeriLog.GuardarLogApplicacionSerilog(correoElectronicoCol, Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                correoElectronicoCol = correoElectronicoCol?.Trim();
                bool correoColaboradorInvalido = string.IsNullOrWhiteSpace(correoElectronicoCol);
                if (count > 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tiene solicitudes pendientes de aprobación por jefatura. No se puede enviar solicitud");
                }
                correoElectronicoJefe = correoElectronicoJefe?.Trim();

                bool correoJefeInvalido = string.IsNullOrWhiteSpace(correoElectronicoJefe);

                if (correoJefeInvalido )
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del supervisor no existe. Por favor, regularice el tema con talento humano. ";
                    SeriLog.GuardarLogApplicacionSerilog("no valido el correo del jefe", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }

                if (correoColaboradorInvalido)
                {
                    string errorMensaje = "No se pudo enviar la solicitud: ";
                    if (correoJefeInvalido) errorMensaje += "correo electrónico del colaborador no existe. Por favor, regularice el tema con talento humano. ";
                    SeriLog.GuardarLogApplicacionSerilog("no valido correo colaborador", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMensaje.Trim());
                }


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

                        var colaboradorSol = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == solicitud.IdColaborador);
                        solicitud.IdSupervisor = colaboradorSol.IdSupervisor;

                        db.tNM_SolicitudVacacionesCab.Add(solicitud);

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
                            Detalle = y.tNM_SolicitudVacacionesDet.Select(z => new { diasPeriodo = z.DiasADisfrutarPeriodo, anio = z.tNM_HistorialVacaciones.Periodo, z.tNM_HistorialVacaciones.FechaInicial, z.tNM_HistorialVacaciones.FechaFinal }),
                            reemplazo  = colaboradorReemplazo.ApellidosNombres.ToUpper(),
                            empresa = y.tNM_Colaboradores.tGN_Empresas.Descripcion.ToUpper(),
                            ruc_empresa = y.tNM_Colaboradores.tGN_Empresas.RUC
                        
                        }).FirstOrDefault();
                        var jsonSolicitud = JsonConvert.SerializeObject(res);
                        List<string> resultSolicitudFile = GenerarFormatoSolicitudes.GeneraSolicitudFileVacaciones(jsonSolicitud, solicitud.IdSolicitudVacaciones, solicitud.IdColaborador.Value);
                        solicitud.UrlSolicitud = resultSolicitudFile[0];
                        SeriLog.GuardarLogApplicacionSerilog(solicitud.UrlSolicitud, Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        db.SaveChanges();
                        dbTransaction.Commit();
                        SeriLog.GuardarLogApplicacionSerilog("TRANSACCIÓN COMMIT REALIZADA", Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres : colaboradorSol.nickname;
                       
                        
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


                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaVacaciones(correoElectronicoJefe, NombreCol, "", "", "", solicitud.IdTipoAusencia.Value, tipoAusencia, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), nombreReemplazo, adjunto);

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

                    }
                    catch (Exception ex)
                    {
                        var message = ex.ToString(); // o ex.InnerException?.Message ?? ex.Message
                        SeriLog.GuardarLogApplicacionSerilog(message, Enumeraciones.EnumNivelesSeriLog.ERROR);
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);

                    }
                }

            }
            catch (Exception ex)
            {
                var message = ex.ToString(); 
                SeriLog.GuardarLogApplicacionSerilog(message, Enumeraciones.EnumNivelesSeriLog.ERROR);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
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

                if (correoJefeInvalido)
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

                        solicitud.IdSupervisor = colaboradorSol.IdSupervisor;
                        solicitud.IdEstadoAprob = 1;
                        db.tNM_SolicitudPermiso.Add(solicitud);
                        db.SaveChanges();

                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres.Split(' ')[2] : colaboradorSol.nickname;
                        string area = db.tNM_Areas.FirstOrDefault(x => x.IdArea == colaboradorSol.IdArea).Descripcion;
                        string departamento = db.tNM_Departamentos.FirstOrDefault(x => x.IdDepartamento == colaboradorSol.IdDepartamento).Descripcion;
                        string cargo = db.tNM_Cargos.FirstOrDefault(x => x.IdCargo == colaboradorSol.IdCargo).Descripcion;
                        string nombreJefe = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == colaboradorSol.IdSupervisor).ApellidosNombres;
                        string fechaSolicitud = DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es"));
                        string nombresEmpleado = colaboradorSol.ApellidosNombres;
                        string CI = colaboradorSol.Identificacion;
                        string motivo = tipoAusencia.Nombre;
                        string fechaHoraDesde = solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitud.HoraInicio.Value.ToString("HH:mm");
                        string fechaHoraHasta = solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitud.HoraFin.Value.ToString("HH:mm");
                        string totalHorasDias = solicitud.NumeroHoras.ToString();
                        int idSolicitud = solicitud.IdSolicitudPermiso;
                        int? idColaborador = solicitud.Idcolaborador;
                        int? idTipoAusencia = solicitud.IdTipoAusencia;
                        string observaciones = solicitud.Observaciones;
                        string empresa = db.tGN_Empresas.FirstOrDefault(x => x.IdEmpresa == colaboradorSol.IdEmpresa).Descripcion;


                        List<string> resultSolicitudFile = GenerarFormatoSolicitudes.GeneraSolicitudFilePermisos(fechaSolicitud, nombresEmpleado, area, departamento, cargo, CI, motivo, fechaHoraDesde, fechaHoraHasta, totalHorasDias, nombreJefe, idSolicitud, idColaborador, idTipoAusencia, observaciones,empresa);

                        solicitud.UrlSolicitud = resultSolicitudFile[0];


                        db.SaveChanges();
                        dbTransaction.Commit();


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


                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaPermisos(correoElectronicoJefe, NombreCol, "", solicitud.HoraInicio.Value.ToString("HH:mm"), solicitud.HoraFin.Value.ToString("HH:mm"), solicitud.IdTipoAusencia.Value, tipoAusencia.Nombre, solicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), adjunto);

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

                    }
                    catch (Exception ex)
                    {
                        if (dbTransaction.UnderlyingTransaction.Connection != null)
                            dbTransaction.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-permisos-otros")]
        public async Task<HttpResponseMessage> PostPermisosOtros()
        {
            if (!Request.Content.IsMimeMultipartContent())
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Formato no válido");

            var provider = await Request.Content.ReadAsMultipartAsync();

            try
            {
                // ========================
                // 1. CABECERA JSON
                // ========================
                string solicitudCabjson = await provider.Contents[0].ReadAsStringAsync();
                provider.Contents.RemoveAt(0);

                tNM_SolicitudPermiso solicitudPermiso =
                    JsonConvert.DeserializeObject<tNM_SolicitudPermiso>(solicitudCabjson);

                // ========================
                // 2. CORREOS
                // ========================
                string correoJefe = db.tNM_Colaboradores
                    .First(x => x.IdColaborador == solicitudPermiso.IdSupervisor)
                    .tGN_Personas.tGN_ContactoPersona
                    .First(x => x.IdMedioContacto == 13).Contacto?.Trim();

                string correoSolicitante = db.tNM_Colaboradores
                    .First(x => x.IdColaborador == solicitudPermiso.Idcolaborador)
                    .tGN_Personas.tGN_ContactoPersona
                    .First(x => x.IdMedioContacto == 13).Contacto?.Trim();

                if (string.IsNullOrWhiteSpace(correoJefe) || string.IsNullOrWhiteSpace(correoSolicitante))
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "No se pudo enviar la solicitud: correo del jefe o solicitante no registrado."
                    );

                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Find(solicitudPermiso.Idcolaborador);

                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ========================
                        // 3. ESTADO INICIAL
                        // ========================
                        tNM_TiposAusencia tipo = db.tNM_TiposAusencia.Find(solicitudPermiso.IdTipoAusencia);

                       


                        if (tipo.ApruebaJefe == true)
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PAJ").IDEstado;
                        else if (tipo.ApruebaTTHH == true)
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PATTH").IDEstado;

                        db.tNM_SolicitudPermiso.Add(solicitudPermiso);
                        db.SaveChanges();

                        // ========================
                        // 4. LEER Y GUARDAR ARCHIVOS EN MEMORIA
                        // ========================
                        List<(byte[] datos, string nombre, HttpContent content)> archivosEnMemoria = new List<(byte[], string, HttpContent)>();

                        foreach (var file in provider.Contents)
                        {
                            byte[] fileBytes = await file.ReadAsByteArrayAsync();
                            string nombreArchivo = file.Headers.ContentDisposition.FileName.Replace("\"", "").Trim();
                            archivosEnMemoria.Add((fileBytes, nombreArchivo, file));
                        }

                        // ========================
                        // 5. ADJUNTOS (BD + AZURE)
                        // ========================
                        List<tNM_AdjuntoSolicitudPermiso> adjuntosDB = new List<tNM_AdjuntoSolicitudPermiso>();

                        foreach (var archivo in archivosEnMemoria)
                        {
                            string url = await SubirArchivosAzure.getUrlAzurePermisos(archivo.content, solicitudPermiso.Idcolaborador.Value);

                            adjuntosDB.Add(new tNM_AdjuntoSolicitudPermiso
                            {
                                IdSolicitudPermiso = solicitudPermiso.IdSolicitudPermiso,
                                UrlAdjunto = url,
                                NombreArchivo = archivo.nombre
                            });
                        }

                        if (adjuntosDB.Any())
                        {
                            db.tNM_AdjuntoSolicitudPermiso.AddRange(adjuntosDB);
                            db.SaveChanges();
                        }

                        // ========================
                        // 6. GENERAR PDF
                        // ========================

                        string motivo = null;
                        if (solicitudPermiso.IdTipoCalamidadDomestica != null && solicitudPermiso.IdTipoAusencia == 6)
                        {
                            tNM_TiposCalamidadDomestica tipoCalamidadDomestica = db.tNM_TiposCalamidadDomestica.Find(solicitudPermiso.IdTipoCalamidadDomestica);
                            motivo = tipo.Nombre + "-" + tipoCalamidadDomestica.Descripcion;
                        }
                        else 
                        if(solicitudPermiso.IdMotivoSolicitudPermiso != null && solicitudPermiso.IdTipoAusencia == 11)
                        {
                            tNM_MotivoSolicitudPermisos motivoSolicitudPermisos = db.tNM_MotivoSolicitudPermisos.Find(solicitudPermiso.IdMotivoSolicitudPermiso);
                            motivo = tipo.Nombre + "-" + motivoSolicitudPermisos.Descripcion;
                        }
                        else
                        {
                            motivo = tipo.Nombre;
                        }

                        string empresa = db.tGN_Empresas.FirstOrDefault(x => x.IdEmpresa == colaborador.IdEmpresa).Descripcion;


                            List<string> archivoSolicitud = GenerarFormatoSolicitudes.GeneraSolicitudFilePermisos(
                                DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                                colaborador.ApellidosNombres,
                                db.tNM_Areas.Find(colaborador.IdArea)?.Descripcion,
                                db.tNM_Departamentos.Find(colaborador.IdDepartamento)?.Descripcion,
                                db.tNM_Cargos.Find(colaborador.IdCargo)?.Descripcion,
                                colaborador.Identificacion,
                                motivo,
                                solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                                solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                                solicitudPermiso.DiasSolicitados.ToString(),
                                db.tNM_Colaboradores.Find(colaborador.IdSupervisor)?.ApellidosNombres,
                                solicitudPermiso.IdSolicitudPermiso,
                                solicitudPermiso.Idcolaborador,
                                solicitudPermiso.IdTipoAusencia,
                                solicitudPermiso.Observaciones,
                                empresa
                            );

                        solicitudPermiso.UrlSolicitud = archivoSolicitud[0];
                        db.SaveChanges();

                        // ========================
                        // 7. ARMAR ADJUNTOS CORREO
                        // ========================
                        List<Adjunto> adjuntosCorreo = new List<Adjunto>();

                        // PDF
                        string pathPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_")
                            + solicitudPermiso.IdSolicitudPermiso + "_" + solicitudPermiso.Idcolaborador + ".pdf";

                        if (File.Exists(pathPDF))
                        {
                            adjuntosCorreo.Add(new Adjunto
                            {
                                Archivo = Convert.ToBase64String(File.ReadAllBytes(pathPDF)),
                                Nombre = Path.GetFileName(pathPDF)
                            });

                            File.Delete(pathPDF);
                        }

                        // Archivos subidos (USAR BYTES GUARDADOS EN MEMORIA)
                        foreach (var archivo in archivosEnMemoria)
                        {
                            adjuntosCorreo.Add(new Adjunto
                            {
                                Archivo = Convert.ToBase64String(archivo.datos),
                                Nombre = archivo.nombre
                            });
                        }

                        // ========================
                        // 8. ENVIAR CORREO
                        // ========================
                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaOtros(
                            correoSolicitante,
                            colaborador.ApellidosNombres,
                            motivo,
                            solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            correoJefe,
                            solicitudPermiso.IdTipoAusencia,
                            "",
                            "",
                            adjuntosCorreo,
                            tipo.ApruebaTTHH
                        );

                        if (!enviado)
                            throw new Exception("No se pudo enviar el correo.");

                        trans.Commit();

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
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

                        // ========================
                        // LEER Y GUARDAR ARCHIVOS EN MEMORIA
                        // ========================
                        List<(byte[] datos, string nombre, HttpContent content)> archivosEnMemoria = new List<(byte[], string, HttpContent)>();

                        foreach (var file in provider.Contents)
                        {
                            byte[] fileBytes = await file.ReadAsByteArrayAsync();
                            string nombreArchivo = file.Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();
                            archivosEnMemoria.Add((fileBytes, nombreArchivo, file));
                        }

                        // ========================
                        // ADJUNTOS (BD + AZURE)
                        // ========================
                        List<tNM_AdjuntoSolicitudPermiso> adjuntosDB = new List<tNM_AdjuntoSolicitudPermiso>();
                        foreach (var archivo in archivosEnMemoria)
                        {
                            tNM_AdjuntoSolicitudPermiso tNM_AdjuntoSolicitudPermiso = new tNM_AdjuntoSolicitudPermiso();
                            tNM_AdjuntoSolicitudPermiso.IdSolicitudPermiso = solicitudPermiso.IdSolicitudPermiso;
                            var url = SubirArchivosAzure.getUrlAzurePermisos(archivo.content, solicitudPermiso.Idcolaborador.Value).Result;
                            tNM_AdjuntoSolicitudPermiso.UrlAdjunto = url;
                            tNM_AdjuntoSolicitudPermiso.NombreArchivo = archivo.nombre;

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
                        string CI = colaborador.Identificacion;
                        string motivo = tNM_TiposAusencia.Nombre;
                        string fechaHoraDesde = solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitudPermiso.HoraInicio.Value.ToString("HH:mm");
                        string fechaHoraHasta = solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")) + " " + solicitudPermiso.HoraFin.Value.ToString("HH:mm");
                        string totalHorasDias = solicitudPermiso.NumeroHoras.ToString();
                        int idSolicitud = solicitudPermiso.IdSolicitudPermiso;
                        int? idColaborador = solicitudPermiso.Idcolaborador;
                        int? idTipoAusencia = solicitudPermiso.IdTipoAusencia;
                        string observaciones = solicitudPermiso.Observaciones;
                        string empresa = db.tGN_Empresas.FirstOrDefault(x => x.IdEmpresa == colaborador.IdEmpresa).Descripcion;
                        
                        if (solicitudPermiso.IdMotivoSolicitudPermiso != null)
                        {
                            tNM_MotivoSolicitudPermisos motivoSolicitud = db.tNM_MotivoSolicitudPermisos.Find(solicitudPermiso.IdMotivoSolicitudPermiso);
                            motivo = motivo + "-" + motivoSolicitud.Descripcion;
                        }

                        List<string> resultSolicitudFile = GenerarFormatoSolicitudes.GeneraSolicitudFilePermisos(fechaSolicitud, nombresEmpleado, area, departamento, cargo, CI, motivo, fechaHoraDesde, fechaHoraHasta, totalHorasDias, nombreJefe, idSolicitud, idColaborador, idTipoAusencia, observaciones,empresa);

                        solicitudPermiso.UrlSolicitud = resultSolicitudFile[0];

                        db.SaveChanges();
                        dbTransaction.Commit();

                        // ========================
                        // ARMAR ADJUNTOS CORREO
                        // ========================
                        List<Adjunto> list = new List<Adjunto>();

                        // PDF generado
                        string pathArchivoPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                        Debug.WriteLine(pathArchivoPDF);
                        FileInfo filePDFToSend = new FileInfo(pathArchivoPDF);

                        if (filePDFToSend.Exists)
                        {
                            byte[] bytes = File.ReadAllBytes(pathArchivoPDF);
                            string file64 = Convert.ToBase64String(bytes);

                            list.Add(new Adjunto
                            {
                                Archivo = file64,
                                Nombre = filePDFToSend.Name
                            });

                            System.IO.File.Delete(pathArchivoPDF);
                        }

                        // Archivos subidos (USAR BYTES GUARDADOS EN MEMORIA)
                        foreach (var archivo in archivosEnMemoria)
                        {
                            list.Add(new Adjunto
                            {
                                Archivo = Convert.ToBase64String(archivo.datos),
                                Nombre = archivo.nombre
                            });
                        }

                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, motivo, solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), " ", correoJefe, solicitudPermiso.IdTipoAusencia, solicitudPermiso.HoraInicio.Value.ToString("HH:mm"), solicitudPermiso.HoraFin.Value.ToString("HH:mm"), list, tNM_TiposAusencia.ApruebaTTHH);

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

        //APROBAR VACACIONES POR JEFATURA
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
                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", "", "", solicitudCabUpdate.IdTipoAusencia.Value, motivo, tipoAusencia, solicitudCabUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudCabUpdate.IdEstadoAprob.Value, estadoAprob, nombreReemplazo, " ");

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

        //APROBAR PERMISOS POR TALENTO HUMANO
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

                            enviado = await EnviarNotificacionEmail.sendEmailAprobacionRechazoAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), " ", correoJefe, solicitud.RespuestaTalentoHumano == null ? "" : solicitud.RespuestaTalentoHumano, estadosFlujoAusencias.Descripcion, permisoSolicitud.IdTipoAusencia, permisoSolicitud.HoraInicio.Value.ToString("HH:mm"), permisoSolicitud.HoraFin.Value.ToString("HH:mm"));

                        }
                        else
                        {
                            enviado = await EnviarNotificacionEmail.sendEmailAprobacionRechazoAusenciaOtros(correoSolicitante, colaborador.ApellidosNombres, tNM_TiposAusencia.Nombre, permisoSolicitud.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), permisoSolicitud.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), correoJefe, solicitud.RespuestaTalentoHumano == null ? "" : solicitud.RespuestaTalentoHumano, estadosFlujoAusencias.Descripcion,permisoSolicitud.IdTipoAusencia, " "," ");
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

        //APROBAR PERMISOS POR JEFATURA
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
                 
                        string NombreCol = colaboradorSol.nickname == null ? colaboradorSol.ApellidosNombres.Split(' ')[2] : colaboradorSol.nickname;
                        string correoElectronicoCol = db.tGN_ContactoPersona.FirstOrDefault(x => x.IdPersona == colaboradorSol.IdPersona && x.IdMedioContacto == 13).Contacto;
                        string motivo = solicitudUpdate.RespuestaSupervisor == null ? "" : solicitudUpdate.RespuestaSupervisor;
                        string estadoAprob = db.tNM_EstadosFlujoAusencias.FirstOrDefault(x => x.IDEstado == solicitudUpdate.IdEstadoAprob).Descripcion;
                        bool enviado = false;

                        if (solicitudUpdate.IdTipoAusencia != 2 && solicitudUpdate.IdTipoAusencia != 10 && solicitudUpdate.IdTipoAusencia != 7 )
                        {
                            enviado = await EnviarNotificacionEmail.sendEmailAprobacionRechazoAusenciaOtros(correoElectronicoCol, NombreCol, tipoAusencia.Nombre, solicitudUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), solicitudUpdate.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", motivo, estadoAprob, solicitudUpdate.IdTipoAusencia.Value, "", "");
                        }
                        else
                        {
                            enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaAprobRech(correoElectronicoCol, NombreCol, "", solicitudUpdate.HoraInicio.Value.ToString("HH:mm"), solicitudUpdate.HoraFin.Value.ToString("HH:mm"), solicitudUpdate.IdTipoAusencia.Value, motivo, tipoAusencia.Nombre, solicitudUpdate.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")), "", solicitudUpdate.IdEstadoAprob.Value, estadoAprob, "", "");
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
        [HttpGet]
        [Route("api/solicitudespermisosTTHH")]
        public HttpResponseMessage GetSolicitudesPermisosTTHH()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosTTHHColaborador());
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }


        #region TELETRABAJO

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudespermisosteletrabajo/{idColaborador}")]
        public HttpResponseMessage GetSolicitudesPermisosTeletrabajoColaborador(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosTeletrabajoColaborador(idColaborador));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudespermisosteletrabajosupervisor/{idSupervisor}")]
        public HttpResponseMessage GetSolicitudesPermisosTeletrabajoSupervisor(int idSupervisor)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosTeletrabajoSupervisorColaborador(idSupervisor));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/solicitudespermisosTeletrabajoTTHH")]
        public HttpResponseMessage GetSolicitudesPermisosTeletrabajoTTHH()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_NMsolicitudesPermisosTeletrabajoTTHHColaborador());
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }





        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-permisos-maternidad-paternidad")]
        public async Task<HttpResponseMessage> PostPermisosMaternidadPaternidad()
        {
            if (!Request.Content.IsMimeMultipartContent())
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Formato no válido");

            var provider = await Request.Content.ReadAsMultipartAsync();

            try
            {
                // ========================
                // 1. CABECERA JSON
                // ========================
                string solicitudCabjson = await provider.Contents[0].ReadAsStringAsync();
                provider.Contents.RemoveAt(0);

                tNM_SolicitudPermiso solicitudPermiso =
                    JsonConvert.DeserializeObject<tNM_SolicitudPermiso>(solicitudCabjson);

                // ========================
                // 2. CORREOS
                // ========================
                string correoJefe = db.tNM_Colaboradores
                    .First(x => x.IdColaborador == solicitudPermiso.IdSupervisor)
                    .tGN_Personas.tGN_ContactoPersona
                    .First(x => x.IdMedioContacto == 13).Contacto?.Trim();

                string correoSolicitante = db.tNM_Colaboradores
                    .First(x => x.IdColaborador == solicitudPermiso.Idcolaborador)
                    .tGN_Personas.tGN_ContactoPersona
                    .First(x => x.IdMedioContacto == 13).Contacto?.Trim();

                string nombreReemplazo = db.tNM_Colaboradores.First(x => x.IdColaborador == solicitudPermiso.IdColaboradorReemplazo).ApellidosNombres;

                if (string.IsNullOrWhiteSpace(correoJefe) || string.IsNullOrWhiteSpace(correoSolicitante))
                    return Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "No se pudo enviar la solicitud: correo del jefe o solicitante no registrado."
                    );

                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Find(solicitudPermiso.Idcolaborador);

                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        // ========================
                        // 3. ESTADO INICIAL
                        // ========================
                        tNM_TiposAusencia tipo = db.tNM_TiposAusencia.Find(solicitudPermiso.IdTipoAusencia);




                        if (tipo.ApruebaJefe == true)
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PAJ").IDEstado;
                        else if (tipo.ApruebaTTHH == true)
                            solicitudPermiso.IdEstadoAprob = db.tNM_EstadosFlujoAusencias.First(x => x.CodigoEstado == "PATTH").IDEstado;

                        db.tNM_SolicitudPermiso.Add(solicitudPermiso);
                        db.SaveChanges();

                        // ========================
                        // 4. LEER Y GUARDAR ARCHIVOS EN MEMORIA
                        // ========================
                        List<(byte[] datos, string nombre, HttpContent content)> archivosEnMemoria = new List<(byte[], string, HttpContent)>();

                        foreach (var file in provider.Contents)
                        {
                            byte[] fileBytes = await file.ReadAsByteArrayAsync();
                            string nombreArchivo = file.Headers.ContentDisposition.FileName.Replace("\"", "").Trim();
                            archivosEnMemoria.Add((fileBytes, nombreArchivo, file));
                        }

                        // ========================
                        // 5. ADJUNTOS (BD + AZURE)
                        // ========================
                        List<tNM_AdjuntoSolicitudPermiso> adjuntosDB = new List<tNM_AdjuntoSolicitudPermiso>();

                        foreach (var archivo in archivosEnMemoria)
                        {
                            string url = await SubirArchivosAzure.getUrlAzurePermisos(archivo.content, solicitudPermiso.Idcolaborador.Value);

                            adjuntosDB.Add(new tNM_AdjuntoSolicitudPermiso
                            {
                                IdSolicitudPermiso = solicitudPermiso.IdSolicitudPermiso,
                                UrlAdjunto = url,
                                NombreArchivo = archivo.nombre
                            });
                        }

                        if (adjuntosDB.Any())
                        {
                            db.tNM_AdjuntoSolicitudPermiso.AddRange(adjuntosDB);
                            db.SaveChanges();
                        }

                        // ========================
                        // 6. GENERAR PDF
                        // ========================

                        string motivo = null;
                        motivo = tipo.Nombre;
                        //if (solicitudPermiso.IdTipoCalamidadDomestica != null && solicitudPermiso.IdTipoAusencia == 6)
                        //{
                        //    tNM_TiposCalamidadDomestica tipoCalamidadDomestica = db.tNM_TiposCalamidadDomestica.Find(solicitudPermiso.IdTipoCalamidadDomestica);
                        //    motivo = tipo.Nombre + "-" + tipoCalamidadDomestica.Descripcion;
                        //}
                        //else
                        //if (solicitudPermiso.IdMotivoSolicitudPermiso != null && solicitudPermiso.IdTipoAusencia == 11)
                        //{
                        //    tNM_MotivoSolicitudPermisos motivoSolicitudPermisos = db.tNM_MotivoSolicitudPermisos.Find(solicitudPermiso.IdMotivoSolicitudPermiso);
                        //    motivo = tipo.Nombre + "-" + motivoSolicitudPermisos.Descripcion;
                        //}
                        //else
                        //{
                        //    motivo = tipo.Nombre;
                        //}



                        List<string> archivoSolicitud = GenerarFormatoSolicitudes.GeneraSolicitudFilePermisosMaternidadPaternidad(
                            DateTime.Now.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            colaborador.ApellidosNombres,
                            db.tNM_Areas.Find(colaborador.IdArea)?.Descripcion,
                            db.tNM_Departamentos.Find(colaborador.IdDepartamento)?.Descripcion,
                            db.tNM_Cargos.Find(colaborador.IdCargo)?.Descripcion,
                            colaborador.Identificacion,
                            motivo,
                            solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            solicitudPermiso.DiasSolicitados.ToString(),
                            db.tNM_Colaboradores.Find(colaborador.IdSupervisor)?.ApellidosNombres,
                            solicitudPermiso.IdSolicitudPermiso,
                            solicitudPermiso.Idcolaborador,
                            solicitudPermiso.IdTipoAusencia,
                            solicitudPermiso.Observaciones,
                            nombreReemplazo
                        );

                        solicitudPermiso.UrlSolicitud = archivoSolicitud[0];
                        db.SaveChanges();

                        // ========================
                        // 7. ARMAR ADJUNTOS CORREO
                        // ========================
                        List<Adjunto> adjuntosCorreo = new List<Adjunto>();

                        // PDF
                        string pathPDF = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_")
                            + solicitudPermiso.IdSolicitudPermiso + "_" + solicitudPermiso.Idcolaborador + ".pdf";

                        if (File.Exists(pathPDF))
                        {
                            adjuntosCorreo.Add(new Adjunto
                            {
                                Archivo = Convert.ToBase64String(File.ReadAllBytes(pathPDF)),
                                Nombre = Path.GetFileName(pathPDF)
                            });

                            File.Delete(pathPDF);
                        }

                        // Archivos subidos (USAR BYTES GUARDADOS EN MEMORIA)
                        foreach (var archivo in archivosEnMemoria)
                        {
                            adjuntosCorreo.Add(new Adjunto
                            {
                                Archivo = Convert.ToBase64String(archivo.datos),
                                Nombre = archivo.nombre
                            });
                        }

                        // ========================
                        // 8. ENVIAR CORREO
                        // ========================
                        bool enviado = await EnviarNotificacionEmail.sendEmailSolicitudAusenciaOtros(
                            correoSolicitante,
                            colaborador.ApellidosNombres,
                            motivo,
                            solicitudPermiso.FechaInicio.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            solicitudPermiso.FechaFin.Value.ToString("MMMM dd, yyyy", CultureInfo.CreateSpecificCulture("es")),
                            correoJefe,
                            solicitudPermiso.IdTipoAusencia,
                            "",
                            "",
                            adjuntosCorreo,
                            tipo.ApruebaTTHH
                        );

                        if (!enviado)
                            throw new Exception("No se pudo enviar el correo.");

                        trans.Commit();

                        return Request.CreateResponse(HttpStatusCode.OK, new
                        {
                            mensaje = "Solicitud enviada correctamente",
                            correoEnviado = true
                        });
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        #endregion




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