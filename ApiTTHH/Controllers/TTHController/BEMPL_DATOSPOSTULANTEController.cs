using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using OnLineCCQ.ApiEnvioCorreoAlphaTech;

namespace ApiTTHH.Controllers.TTHController
{
    public class BEMPL_DATOSPOSTULANTEController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/upload-file")]
        async public Task<HttpResponseMessage> MediaUpload()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }
                var provider = await Request.Content.ReadAsMultipartAsync();
                string idPostulante = await provider.Contents[1].ReadAsStringAsync();
                string tipoFile = await provider.Contents[2].ReadAsStringAsync();
                int idPostulanteIn = int.Parse(idPostulante);
                string urlFile = await getUrlAzure(provider, 0, idPostulante, tipoFile);
                db.Configuration.LazyLoadingEnabled = false;

                //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == idPostulanteIn);
                        if (tipoFile == "F")
                        {
                            postulanteUpdate.UrlImagenPerfil = urlFile;
                        }
                        if (tipoFile == "C")
                        {
                            postulanteUpdate.UrlDiscapacidad = urlFile;
                        }
                        if (tipoFile == "V")
                        {
                            postulanteUpdate.UrlVideo = urlFile;
                        }
                        if (tipoFile == "CV")
                        {
                            postulanteUpdate.UrlAdjuntoCV = urlFile;
                        }
                        db.SaveChanges();
                        dbTransaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        var message = string.Format(ex.Message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Registro realizado");
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        public async Task<string> getUrlAzure(MultipartMemoryStreamProvider provider, int index, string ruc, string tipo)
        {
            string url = "";
            Stream fileStream = await provider.Contents[index].ReadAsStreamAsync();
            string filename = provider.Contents[index].Headers.ContentDisposition.FileName.Replace('"', ' ').Trim();
            string extension = Path.GetExtension(filename);
            string contentType = provider.Contents[index].Headers.ContentType.MediaType;
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("archivos");
            string Foldertype = tipo == "C" ? "Certificados" : tipo == "F" ? "Foto" : tipo == "CV" ? "CVS" : "Videos";
            CloudBlobDirectory directory = container.GetDirectoryReference("BolsaEmpleo/" + Foldertype);
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                string key = ruc + "_" + tipo + extension;
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
            return url;
        }

        public void sendEmail(string correoUsuario, string nombres, int idUsuario)
        {
            try
            {
                //Call the api
                CorreoElectronico correo = new CorreoElectronico();
                correo.CodigoAplicacionInterna = "01";
                correo.Listado_TO.Add(correoUsuario);
                correo.TituloSubject = "EMPLEO.CCQ.EC Cambio de Contrase&#241;a";

                var pathArchivoPlantilla = ConfigurationManager.AppSettings["PATH_PLANTILLA_ENVIO_EMAIL"].ToString();
                var urlChangePassword = ConfigurationManager.AppSettings["URL_APP_EMPLEO"].ToString() + idUsuario;
                string cuerpo = File.ReadAllText(pathArchivoPlantilla, Encoding.UTF8);
                cuerpo = cuerpo.Replace("[NOMBRE_CANDIDATO]", nombres);
                cuerpo = cuerpo.Replace("[URL]", urlChangePassword);
                correo.CuerpoMensaje = cuerpo;

                //Invocacion al API
                API_Service apiService = new API_Service();
                var response_API_SendMail = apiService.API_EnviarCorreoApiAlpha(correo);
                Response response = response_API_SendMail.Result;
                if (!response.IsSuccess)
                {
                    Console.WriteLine("ERROR EN EL RETORNO DEL API");
                    Console.WriteLine($"{response.Message}");
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
        public void deleteFile(string file, string Foldertype)
        {
            string url = "";
            string conecctString = ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString;
            CloudStorageAccount sa = CloudStorageAccount.Parse(conecctString);
            CloudBlobClient bc = sa.CreateCloudBlobClient();
            CloudBlobContainer container = bc.GetContainerReference("archivos");

            CloudBlobDirectory directory = container.GetDirectoryReference("BolsaEmpleo/" + Foldertype);
            try
            {
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new NoRetry() };
                container.CreateIfNotExists(requestOptions, null);
                CloudBlob s = container.GetBlobReference("BolsaEmpleo/" + Foldertype + "/" + file);
                s.Delete();
            }
            catch (StorageException ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
                //return thr;
            }

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/informacion/{idUsuario}")]
        public HttpResponseMessage GetInformacion(int idUsuario)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                var result = (from info in db.BEMPL_DATOSPOSTULANTE.Where(x => x.IdUsuario == idUsuario)

                              select new
                              {
                                  info,
                                  tipoidentificacion = (from tipoIdentificacio in db.BEMPL_CAT_TIPO_IDENTIFICACION.Where(x => x.IdTipoIdentificacion == info.IdTipoIdentificacion)

                                                        select new
                                                        {
                                                            tipoIdentificacio.IdTipoIdentificacion,
                                                            tipoIdentificacio.Descripcion
                                                        }

                                                  ).FirstOrDefault(),
                                  genero = db.BEMPL_CAT_GENERO.Where(x => x.IdGenero == info.IdGenero).Select(x => new { x.IdGenero, x.Descripcion }).FirstOrDefault(),
                                  capacitacion = db.BEMPL_CAT_CAPACITACIONES.Where(x => x.IdCapacitacion == info.IdCapacitacion).Select(x => new { x.IdCapacitacion, x.Descripcion }).FirstOrDefault(),
                                  estadoCivil = db.BEMPL_CAT_ESTADO_CIVIL.Where(x => x.IdEstadoCivil == info.IdEstadoCivil).Select(x => new { x.IdEstadoCivil, x.Descripcion }).FirstOrDefault(),
                                  provincia = db.BEMPL_CAT_PROVINCIAS.Where(x => x.IdProvincia == info.IdProvincia).Select(x => new { x.IdProvincia, x.Provincia }).FirstOrDefault(),
                                  ciudad = db.BEMPL_CAT_CIUDAD.Where(x => x.IdCiudad == info.IdCiudad).Select(x => new { x.IdCiudad, x.Ciudad }).FirstOrDefault(),
                                  nacionalidad = db.BEMPL_CAT_NACIONALIDAD.Where(x => x.IdNacionalidad == info.IdNacionalidad).Select(x => new { x.IdNacionalidad, x.Descripcion }).FirstOrDefault(),
                                  estudios = db.BEMPL_DATOS_ACADEMICOS.Where(x => x.IdDatosPostulante == info.IdPostulante).Select(x => new
                                  {
                                      x.IdEstudio,
                                      x.IdDatosPostulante,
                                      x.Institucion,
                                      x.Titulo,
                                      x.IdNivelEstudio,
                                      x.IdEstadonivelAcademico,
                                      x.MesInicio,
                                      x.AnioInicio,
                                      x.MesFin,
                                      x.AnioFin,
                                      x.AlPresente,
                                      x.MesInicioDesc,
                                      x.MesFinDesc,
                                      nivelDesc = db.BEMPL_CAT_NIVEL_ESTUDIO.FirstOrDefault(y => y.IdNivelEstudio == x.IdNivelEstudio).NivelEstudioDescripcion,
                                      estadonivelDesc = db.BEMPL_CAT_NIVEL_ACADEMICO.FirstOrDefault(y => y.IdEstadoNivelAcademico == x.IdEstadonivelAcademico).DescripcionNivelAcademico
                                  }).OrderByDescending(x => x.AnioInicio).ToList(),
                                  experiencias = db.BEMPL_EXPERIENCIA_LABORAL.Where(x => x.IdPostulante == info.IdPostulante).Select(x => new
                                  {
                                      x.IdExperiencia,
                                      x.IdPostulante,
                                      x.Empresa,
                                      x.MesIni,
                                      x.AnioInicio,
                                      x.MesFin,
                                      x.AnioFin,
                                      x.AlPresente,
                                      x.MesInicioDesc,
                                      x.MesFinDesc,
                                      x.ResumenActividades,
                                      x.PersonasACargo,
                                      x.Puesto,
                                      x.PresupuestoVentasMensual
                                  }).OrderByDescending(x => x.AnioInicio).ToList(),
                                  idiomas = db.BEMPL_IDIOMAS_POSTULANTE.Where(x => x.IdPostulante == info.IdPostulante).Select(x => new
                                  {
                                      x.IdIdiomaPostulante,
                                      x.IdPostulante,
                                      x.IdIdioma,
                                      x.IdNivelIdiomaOral,
                                      x.IdNivelIdiomaEscrito,
                                      idiomaDesc = db.BEMPL_CAT_IDIOMAS.FirstOrDefault(y => y.IdIdioma == x.IdIdioma).IdiomaDescripcion,
                                      nivelIdiomaOral = db.BEMPL_CAT_NIVEL_IDIOMA.FirstOrDefault(y => y.IdNivelIdioma == x.IdNivelIdiomaOral).NivelIdiomaDescripcion,
                                      nivelIdiomaEscrito = db.BEMPL_CAT_NIVEL_IDIOMA.FirstOrDefault(y => y.IdNivelIdioma == x.IdNivelIdiomaEscrito).NivelIdiomaDescripcion,
                                  }).ToList(),
                                  referencias = db.BEMPL_REFERENCIAS_LABORA.Where(x => x.IdPostulante == info.IdPostulante).Select(x => new
                                  {
                                      x.IdReferencia,
                                      x.IdPostulante,
                                      x.IdRelacionReferenciaCat,
                                      x.Nombre,
                                      x.Apellido,
                                      x.Telefono,
                                      x.Correo,
                                      x.IdExperiencia,
                                      relaciondesc = db.BEMPL_RELACION_REF_CAT.FirstOrDefault(y => y.IdRelacionReferencia == x.IdRelacionReferenciaCat).Descripcion,
                                      experiencia = db.BEMPL_EXPERIENCIA_LABORAL.FirstOrDefault(y => y.IdExperiencia == x.IdExperiencia).Empresa,
                                      cargo = db.BEMPL_EXPERIENCIA_LABORAL.FirstOrDefault(y => y.IdExperiencia == x.IdExperiencia).Puesto,

                                  })
                              }

                            ).FirstOrDefault();

                int porcentDaPer = result.info.Identificacion == null ? 0 : 35;
                int porcentImagenPerfil = result.info.UrlImagenPerfil == null ? 0 : 5;
                int porcentEstudios = result.estudios.Count == 0 ? 0 : 10;
                int porcentExperiencia = result.experiencias.Count == 0 ? 0 : 10;
                int porcentIdiomas = result.idiomas.Count == 0 ? 0 : 5;
                int porcentHojaVida = result.info.UrlAdjuntoCV == null ? 0 : 35;

                int sumaPorceCV = porcentDaPer + porcentImagenPerfil + porcentEstudios + porcentExperiencia + porcentIdiomas + porcentHojaVida;

                db.Configuration.LazyLoadingEnabled = false;

                //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == result.info.IdPostulante);
                        if (sumaPorceCV > 0)
                        {
                            postulanteUpdate.PorcentajeHojaVida = sumaPorceCV;
                            db.SaveChanges();
                            dbTransaction.Commit();
                        }


                    }

                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        var message = string.Format(ex.Message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/informacion-experiencias/{idPostulante}")]
        public HttpResponseMessage GetExperiencias(int idPostulante)
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_EXPERIENCIA_LABORAL.Where(x => x.IdPostulante == idPostulante).Select(x => new { x.IdExperiencia, x.Empresa, x.Puesto }));
            ;
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/reset-password")]
        public HttpResponseMessage PostReseteoPassword(BEMPL_USUARIO bEMPL_USUARIO)
        {
            db.Configuration.LazyLoadingEnabled = false;
            BEMPL_USUARIO usuario = db.BEMPL_USUARIO.FirstOrDefault(x => x.CorreoUsuario == bEMPL_USUARIO.CorreoUsuario);
            if (usuario == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cuenta con el correo ingresado no existe.");
            }
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    usuario.IsRecuperaPassword = true;
                    sendEmail(bEMPL_USUARIO.CorreoUsuario, usuario.Nombres.ToUpperInvariant(), usuario.IdUsuario);
                    db.SaveChanges();
                    dbTransaction.Commit();

                }

                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error intente más tarde");
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
            ;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-informacion")]
        public HttpResponseMessage PostInfoSinFileCertificado(InformacionPostulanteCustom customInfo)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == customInfo.id);
                    postulanteUpdate.Apellidos = customInfo.apellidos;
                    postulanteUpdate.Nombres = customInfo.nombres;
                    postulanteUpdate.CarnetDiscapacidad = customInfo.discapacidad;
                    postulanteUpdate.Celular = customInfo.celular;
                    postulanteUpdate.Correo = customInfo.correo;
                    postulanteUpdate.DetalleDiscapacidades = customInfo.tiposDiscapacidades;
                    postulanteUpdate.FechaNacimiento = DateTime.Parse(customInfo.fechaPost);
                    postulanteUpdate.IdCiudad = customInfo.ciudad;
                    postulanteUpdate.Identificacion = customInfo.identificacion;
                    postulanteUpdate.IdEstadoCivil = customInfo.estadoCivil;
                    postulanteUpdate.IdGenero = customInfo.genero;
                    postulanteUpdate.IdNacionalidad = customInfo.nacionalidad;
                    postulanteUpdate.IdProvincia = customInfo.provincia;
                    postulanteUpdate.IdTipoIdentificacion = customInfo.tipoIdentificacion;
                    postulanteUpdate.MoilizacionPropia = customInfo.movilizacion;
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-salario")]
        public HttpResponseMessage PostInfoSAlario(InformacionPostulanteCustom customInfo)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == customInfo.id);
                    postulanteUpdate.AspiracionSalarial = customInfo.salario;

                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-capacitacion")]
        public HttpResponseMessage PostInfoCapacitacion(InformacionPostulanteCustom customInfo)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == customInfo.id);
                    postulanteUpdate.IdCapacitacion = customInfo.idCapacitacion;
                    if (postulanteUpdate.IdCapacitacion == 14)
                    {
                        postulanteUpdate.Otros = customInfo.otroDescripcion;
                    }
                    else {
                        postulanteUpdate.Otros = null;
                    }

                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-informacion-estudio")]
        public HttpResponseMessage PostInfoEstudio(BEMPL_DATOS_ACADEMICOS datoAcademico)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOS_ACADEMICOS datoUpdate = db.BEMPL_DATOS_ACADEMICOS.FirstOrDefault(x => x.IdEstudio == datoAcademico.IdEstudio);
                    if (datoUpdate == null)
                    {
                        datoAcademico.IdEstudio = 0;
                        db.BEMPL_DATOS_ACADEMICOS.Add(datoAcademico);
                    }
                    else
                    {
                        if (datoAcademico.AlPresente == true)
                        {
                            datoAcademico.AnioFin = null;
                            datoAcademico.MesFin = null;
                            datoAcademico.MesFinDesc = null;

                        }
                        db.Entry(datoUpdate).CurrentValues.SetValues(datoAcademico);
                    }
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-informacion-experiencia")]
        public HttpResponseMessage PostInfoExperiencia(BEMPL_EXPERIENCIA_LABORAL datosExperiencia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_EXPERIENCIA_LABORAL datoUpdate = db.BEMPL_EXPERIENCIA_LABORAL.FirstOrDefault(x => x.IdExperiencia == datosExperiencia.IdExperiencia);
                    if (datoUpdate == null)
                    {
                        datosExperiencia.IdExperiencia = 0;
                        db.BEMPL_EXPERIENCIA_LABORAL.Add(datosExperiencia);
                    }
                    else
                    {
                        if (datosExperiencia.AlPresente == true)
                        {
                            datosExperiencia.AnioFin = null;
                            datosExperiencia.MesFin = null;
                            datosExperiencia.MesFinDesc = null;

                        }
                        db.Entry(datoUpdate).CurrentValues.SetValues(datosExperiencia);
                    }
                    db.SaveChanges();



                    List<BEMPL_EXPERIENCIA_LABORAL> experiencias = db.BEMPL_EXPERIENCIA_LABORAL.Where(x => x.IdPostulante == datosExperiencia.IdPostulante).ToList();
                    int meses = 0;
                    int anios = 0;
                    DateTime fechaActual = DateTime.Now.Date;
                    foreach (BEMPL_EXPERIENCIA_LABORAL experienc in experiencias)
                    {
                        DateTime fechaInicio = Convert.ToDateTime("01/" + experienc.MesIni + "/" + experienc.AnioInicio);
                        if (experienc.AlPresente == true)
                        {

                            meses = meses + Math.Abs((fechaActual.Month - fechaInicio.Month) + 12 * (fechaActual.Year - fechaInicio.Year));
                        }
                        else
                        {
                            DateTime fechaFin = Convert.ToDateTime("01/" + experienc.MesFin + "/" + experienc.AnioFin);
                            meses = meses + Math.Abs((fechaFin.Month - fechaInicio.Month) + 12 * (fechaFin.Year - fechaInicio.Year));
                        }
                    }
                    if (meses >= 12)
                    {
                        anios = (int)Math.Floor((decimal)meses / 12);
                    }
                    else
                    {
                        anios = 0;
                    }
                    BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == datosExperiencia.IdPostulante);
                    postulanteUpdate.AniosExperiencia = anios;
                    db.SaveChanges();


                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-informacion-referencia")]
        public HttpResponseMessage PostInfoReferencia(BEMPL_REFERENCIAS_LABORA datosReferencia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_REFERENCIAS_LABORA datoUpdate = db.BEMPL_REFERENCIAS_LABORA.FirstOrDefault(x => x.IdReferencia == datosReferencia.IdReferencia);
                    datosReferencia.Nombre = datosReferencia.Nombre.ToUpperInvariant().Trim();
                    datosReferencia.Apellido = datosReferencia.Apellido.ToUpperInvariant().Trim();
                    if (datoUpdate == null)
                    {
                        //datosExperiencia.IdExperiencia = 0;
                        db.BEMPL_REFERENCIAS_LABORA.Add(datosReferencia);
                    }
                    else
                    {

                        db.Entry(datoUpdate).CurrentValues.SetValues(datosReferencia);
                    }
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/save-informacion-idioma")]
        public HttpResponseMessage PostInfoIdioma(BEMPL_IDIOMAS_POSTULANTE datosIdioma)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_IDIOMAS_POSTULANTE datoUpdate = db.BEMPL_IDIOMAS_POSTULANTE.FirstOrDefault(x => x.IdIdiomaPostulante == datosIdioma.IdIdiomaPostulante);
                    if (datoUpdate == null)
                    {
                        datosIdioma.IdIdiomaPostulante = 0;
                        db.BEMPL_IDIOMAS_POSTULANTE.Add(datosIdioma);
                    }
                    else
                    {

                        db.Entry(datoUpdate).CurrentValues.SetValues(datosIdioma);
                    }
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-estudio")]
        public HttpResponseMessage PostEliminaEstudio(BEMPL_DATOS_ACADEMICOS datoAcademico)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOS_ACADEMICOS datoUpdate = db.BEMPL_DATOS_ACADEMICOS.FirstOrDefault(x => x.IdEstudio == datoAcademico.IdEstudio);
                    db.BEMPL_DATOS_ACADEMICOS.Remove(datoUpdate);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-referencia")]
        public HttpResponseMessage PostEliminaReferencia(BEMPL_REFERENCIAS_LABORA datoReferencia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_REFERENCIAS_LABORA datoUpdate = db.BEMPL_REFERENCIAS_LABORA.FirstOrDefault(x => x.IdReferencia == datoReferencia.IdReferencia);
                    db.BEMPL_REFERENCIAS_LABORA.Remove(datoUpdate);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-experiencia")]
        public HttpResponseMessage PostEliminaExperiencia(BEMPL_EXPERIENCIA_LABORAL datoexperiencia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_EXPERIENCIA_LABORAL datodelete = db.BEMPL_EXPERIENCIA_LABORAL.FirstOrDefault(x => x.IdExperiencia == datoexperiencia.IdExperiencia);
                    int idPostulante = datodelete.IdPostulante.Value;
                    List<BEMPL_REFERENCIAS_LABORA> datosRef = db.BEMPL_REFERENCIAS_LABORA.Where(x => x.IdExperiencia == datoexperiencia.IdExperiencia).ToList();
                    if (datosRef.Count > 0)
                    {
                        db.BEMPL_REFERENCIAS_LABORA.RemoveRange(datosRef);
                    }

                    db.BEMPL_EXPERIENCIA_LABORAL.Remove(datodelete);
                    db.SaveChanges();


                    List<BEMPL_EXPERIENCIA_LABORAL> experiencias = db.BEMPL_EXPERIENCIA_LABORAL.Where(x => x.IdPostulante == idPostulante).ToList();
                    int meses = 0;
                    int anios = 0;
                    DateTime fechaActual = DateTime.Now.Date;
                    foreach (BEMPL_EXPERIENCIA_LABORAL experienc in experiencias)
                    {
                        DateTime fechaInicio = Convert.ToDateTime("01/" + experienc.MesIni + "/" + experienc.AnioInicio);
                        if (experienc.AlPresente == true)
                        {

                            meses = meses + Math.Abs((fechaActual.Month - fechaInicio.Month) + 12 * (fechaActual.Year - fechaInicio.Year));
                        }
                        else
                        {
                            DateTime fechaFin = Convert.ToDateTime("01/" + experienc.MesFin + "/" + experienc.AnioFin);
                            meses = meses + Math.Abs((fechaFin.Month - fechaInicio.Month) + 12 * (fechaFin.Year - fechaInicio.Year));
                        }
                    }
                    if (meses >= 12)
                    {
                        anios = (int)Math.Floor((decimal)meses / 12);
                    }
                    else
                    {
                        anios = 0;
                    }
                    BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == idPostulante);
                    postulanteUpdate.AniosExperiencia = anios;
                    db.SaveChanges();


                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/calculo-experiencia")]
        public HttpResponseMessage PostCalculoExperiencia(BEMPL_EXPERIENCIA_LABORAL datoexperiencia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<BEMPL_DATOSPOSTULANTE> postulantes = db.BEMPL_DATOSPOSTULANTE.ToList();
                    foreach (BEMPL_DATOSPOSTULANTE post in postulantes)
                    {


                        List<BEMPL_EXPERIENCIA_LABORAL> experiencias = db.BEMPL_EXPERIENCIA_LABORAL.Where(x => x.IdPostulante == post.IdPostulante).ToList();
                        int meses = 0;
                        int anios = 0;
                        DateTime fechaActual = DateTime.Now.Date;
                        foreach (BEMPL_EXPERIENCIA_LABORAL experienc in experiencias)
                        {
                            DateTime fechaInicio = Convert.ToDateTime("01/" + experienc.MesIni + "/" + experienc.AnioInicio);
                            if (experienc.AlPresente == true)
                            {

                                meses = meses + Math.Abs((fechaActual.Month - fechaInicio.Month) + 12 * (fechaActual.Year - fechaInicio.Year));
                            }
                            else
                            {
                                DateTime fechaFin = Convert.ToDateTime("01/" + experienc.MesFin + "/" + experienc.AnioFin);
                                meses = meses + Math.Abs((fechaFin.Month - fechaInicio.Month) + 12 * (fechaFin.Year - fechaInicio.Year));
                            }
                        }
                        if (meses >= 12)
                        {
                            anios = (int)Math.Floor((decimal)meses / 12);
                        }
                        else
                        {
                            anios = 0;
                        }
                        BEMPL_DATOSPOSTULANTE postulanteUpdate = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == post.IdPostulante);
                        postulanteUpdate.AniosExperiencia = anios;
                        db.SaveChanges();
                    }
                    dbTransaction.Commit();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-idioma")]
        public HttpResponseMessage PostEliminaIdioma(BEMPL_IDIOMAS_POSTULANTE datoIdioma)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_IDIOMAS_POSTULANTE datoUpdate = db.BEMPL_IDIOMAS_POSTULANTE.FirstOrDefault(x => x.IdIdioma == datoIdioma.IdIdioma);
                    db.BEMPL_IDIOMAS_POSTULANTE.Remove(datoUpdate);
                    db.SaveChanges();
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-video")]
        public HttpResponseMessage PostEliminaVideo(BEMPL_DATOSPOSTULANTE datoVideo)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE datodelete = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == datoVideo.IdPostulante);
                    string[] _splitUrl = datodelete.UrlVideo.Split('/');
                    string fileName = _splitUrl.Last();
                    datodelete.UrlVideo = null;
                    db.SaveChanges();
                    this.deleteFile(fileName, "Videos");
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/delete-cv")]
        public HttpResponseMessage PostEliminaCV(BEMPL_DATOSPOSTULANTE datoCV)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE datodelete = db.BEMPL_DATOSPOSTULANTE.FirstOrDefault(x => x.IdPostulante == datoCV.IdPostulante);
                    string[] _splitUrl = datodelete.UrlAdjuntoCV.Split('/');
                    string fileName = _splitUrl.Last();
                    datodelete.UrlAdjuntoCV = null;
                    db.SaveChanges();
                    this.deleteFile(fileName, "CVS");
                    dbTransaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/report-bempl")]
        public HttpResponseMessage PostReport(ParametrosFilterReportBEmpl filters)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);

            try
            {
                var r = db.sp_ReportPostulantes(filters.idGenero, filters.carnetDiscapacidad, filters.movilizacion, filters.aniosExperienciaDesde,
                      filters.aniosExperienciaHasta, filters.sueldoPretendidoDesde, filters.sueldoPretendidoHasta, filters.edadDesde, filters.edadHasta, filters.puesto, filters.estudio
                      ).ToList();
                var result = (from re in db.sp_ReportPostulantes(filters.idGenero, filters.carnetDiscapacidad, filters.movilizacion, filters.aniosExperienciaDesde,
                      filters.aniosExperienciaHasta, filters.sueldoPretendidoDesde, filters.sueldoPretendidoHasta, filters.edadDesde, filters.edadHasta, filters.puesto, filters.estudio
                      )
                              select new
                              {
                                  idPostulante = re.IdPostulante,
                                  nombres = re.Nombres,
                                  apellidos = re.Apellidos,
                                  fechaNacimiento = re.FechaNacimiento,
                                  edad = re.edad,
                                  experiencia = re.AniosExperiencia,
                                  genero = re.Genero,
                                  estadoCivil = re.EstadoCivil,
                                  provincia = re.Provincia,
                                  ciudad = re.Ciudad,
                                  movilizacion = re.MoilizacionPropia,
                                  carnetDiscapacidad = re.CarnetDiscapacidad,
                                  urlDiscapacidad = re.UrlDiscapacidad,
                                  aspiracionSalarial = re.AspiracionSalarial,
                                  urlCV = re.UrlAdjuntoCV,
                                  urlVideo = re.UrlVideo,
                                  urlImagenPerfil = re.UrlImagenPerfil,
                                  porcentajeHV = re.PorcentajeHojaVida,
                                  identificacion = re.Identificacion,
                                  numeroCel=re.Celular,
                                  correo=re.Correo,
                                  Capacitacion=re.IdCapacitacion==14?re.Otros:re.DESCRIPCION,

                                  datosAcademicos = (from ac in db.BEMPL_DATOS_ACADEMICOS
                                                     join ne in db.BEMPL_CAT_NIVEL_ESTUDIO
                                                     on ac.IdNivelEstudio equals ne.IdNivelEstudio
                                                     join est in db.BEMPL_CAT_NIVEL_ACADEMICO
                                                     on ac.IdEstadonivelAcademico equals est.IdEstadoNivelAcademico
                                                     where ac.IdDatosPostulante == re.IdPostulante
                                                     select new
                                                     {
                                                         idEstudio = ac.IdEstudio,
                                                         idPostulante = ac.IdDatosPostulante,
                                                         institucion = ac.Institucion,
                                                         nivelEstudio = ne.NivelEstudioDescripcion,
                                                         estadoEstudio = est.DescripcionNivelAcademico,
                                                         ac.AnioInicio,
                                                         ac.AnioFin,
                                                         ac.MesFin,
                                                         ac.AlPresente,
                                                         ac.Titulo,
                                                         ac.MesInicioDesc,
                                                         ac.MesFinDesc,
                                                     }
                                                   ).OrderByDescending(x=>x.AnioInicio),
                                  experienciasLaborales = (from exp in db.BEMPL_EXPERIENCIA_LABORAL
                                                           where exp.IdPostulante == re.IdPostulante
                                                           select new
                                                           {
                                                               exp
                                                           }
                                                          ).OrderByDescending(x => x.exp.AnioInicio).ToList(),
                                  idiomas = (from idi in db.BEMPL_IDIOMAS_POSTULANTE
                                             join cati in db.BEMPL_CAT_IDIOMAS
                                             on idi.IdIdioma equals cati.IdIdioma
                                             join catnivel in db.BEMPL_CAT_NIVEL_IDIOMA
                                             on idi.IdNivelIdiomaEscrito equals catnivel.IdNivelIdioma
                                             join catnivelOral in db.BEMPL_CAT_NIVEL_IDIOMA
                                             on idi.IdNivelIdiomaOral equals catnivelOral.IdNivelIdioma
                                             where idi.IdPostulante == re.IdPostulante
                                             select new
                                             {
                                                 idIdiomaPostulante=idi.IdIdiomaPostulante,
                                                 idPostulante=idi.IdPostulante,
                                                 idioma=cati.IdiomaDescripcion,
                                                 nivelEscrito=catnivel.NivelIdiomaDescripcion,
                                                 nivelOral=catnivelOral.NivelIdiomaDescripcion
                                             }
                                            )



                              }

                            ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

        }
        // GET: api/BEMPL_DATOSPOSTULANTE
        public IQueryable<BEMPL_DATOSPOSTULANTE> GetBEMPL_DATOSPOSTULANTE()
        {
            return db.BEMPL_DATOSPOSTULANTE;
        }

        // GET: api/BEMPL_DATOSPOSTULANTE/5
        [ResponseType(typeof(BEMPL_DATOSPOSTULANTE))]
        public async Task<IHttpActionResult> GetBEMPL_DATOSPOSTULANTE(int id)
        {
            BEMPL_DATOSPOSTULANTE bEMPL_DATOSPOSTULANTE = await db.BEMPL_DATOSPOSTULANTE.FindAsync(id);
            if (bEMPL_DATOSPOSTULANTE == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_DATOSPOSTULANTE);
        }

        // PUT: api/BEMPL_DATOSPOSTULANTE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_DATOSPOSTULANTE(int id, BEMPL_DATOSPOSTULANTE bEMPL_DATOSPOSTULANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_DATOSPOSTULANTE.IdPostulante)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_DATOSPOSTULANTE).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_DATOSPOSTULANTEExists(id))
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

        // POST: api/BEMPL_DATOSPOSTULANTE
        [ResponseType(typeof(BEMPL_DATOSPOSTULANTE))]
        public async Task<IHttpActionResult> PostBEMPL_DATOSPOSTULANTE(BEMPL_DATOSPOSTULANTE bEMPL_DATOSPOSTULANTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_DATOSPOSTULANTE.Add(bEMPL_DATOSPOSTULANTE);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_DATOSPOSTULANTE.IdPostulante }, bEMPL_DATOSPOSTULANTE);
        }

        // DELETE: api/BEMPL_DATOSPOSTULANTE/5
        [ResponseType(typeof(BEMPL_DATOSPOSTULANTE))]
        public async Task<IHttpActionResult> DeleteBEMPL_DATOSPOSTULANTE(int id)
        {
            BEMPL_DATOSPOSTULANTE bEMPL_DATOSPOSTULANTE = await db.BEMPL_DATOSPOSTULANTE.FindAsync(id);
            if (bEMPL_DATOSPOSTULANTE == null)
            {
                return NotFound();
            }

            db.BEMPL_DATOSPOSTULANTE.Remove(bEMPL_DATOSPOSTULANTE);
            await db.SaveChangesAsync();

            return Ok(bEMPL_DATOSPOSTULANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_DATOSPOSTULANTEExists(int id)
        {
            return db.BEMPL_DATOSPOSTULANTE.Count(e => e.IdPostulante == id) > 0;
        }
    }
}