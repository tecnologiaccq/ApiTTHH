using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiTTHH.Models;
using ApiTTHH.Models.Custom;
using DevExpress.DataAccess.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiTTHH.Controllers.Catalogos
{
    public class tNM_DepartamentosController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNM_Departamentos
        public IQueryable<tNM_Departamentos> GettNM_Departamentos()
        {
            return db.tNM_Departamentos;
        }

        // GET: api/tNM_Departamentos/5
        [ResponseType(typeof(tNM_Departamentos))]
        public async Task<IHttpActionResult> GettNM_Departamentos(int id)
        {
            tNM_Departamentos tNM_Departamentos = await db.tNM_Departamentos.FindAsync(id);
            if (tNM_Departamentos == null)
            {
                return NotFound();
            }

            return Ok(tNM_Departamentos);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/file")]
        public HttpResponseMessage PostCreatePlatePdf(CertificateParameters parameters)
        {
            try
            {
                Reportes.CertificadoLaboralSueldo certificadoSueldo = new Reportes.CertificadoLaboralSueldo();
                Reportes.CertificadoLaboral certificadoSinSueldo = new Reportes.CertificadoLaboral();
                db.Configuration.LazyLoadingEnabled = false;
                tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.IdColaborador == parameters.idColaborador);
                tGN_Personas persona = db.tGN_Personas.Single(x => x.IdPersonas == colaborador.IdPersona);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                string guid = Guid.NewGuid().ToString().Replace("-", "");
                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/") + guid + ".pdf";

                MemoryStream ms = new MemoryStream();

                if (parameters.idTipoCertificate == 1)
                {
                    certificadoSinSueldo = getCertificadoSinSueldo(persona, colaborador, certificadoSinSueldo);
                    certificadoSinSueldo.RequestParameters = false;
                    //MemoryStream stream = new MemoryStream();
                    certificadoSinSueldo.ExportToPdf(path);
                }
                if (parameters.idTipoCertificate == 2)
                {
                    certificadoSueldo = getCertificadoConSueldo(persona, colaborador, certificadoSueldo);
                    certificadoSueldo.RequestParameters = false;
                    //MemoryStream stream = new MemoryStream();
                    certificadoSueldo.ExportToPdf(path);
                }


                // Close the document


                // Close the writer instance  
                //writer.Close();
                //// Always close open filehandles explicity  
                //fs.Close();
                //ms.Seek(0, SeekOrigin.Begin);
                //return File(ms, "application / pdf",filena );
                //Set the Response Content.  
                byte[] bytes = System.IO.File.ReadAllBytes(path);


                //Close the File Stream
                //fs.Close();
                response.Content = new ByteArrayContent(bytes);
                //Set the Response Content Length.  
                response.Content.Headers.ContentLength = bytes.LongLength;
                //Set the Content Disposition Header Value and FileName.  
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "Certificado Laboral" + colaborador.ApellidosNombres + ".pdf";
                //Set the File Content Type.  
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("2323.pdf"));
                System.IO.File.Delete(path);
                return response;
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        public Reportes.CertificadoLaboral getCertificadoSinSueldo(tGN_Personas persona, tNM_Colaboradores colaborador, Reportes.CertificadoLaboral report)
        {
            string fullMonthName = DateTime.Now.Date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string fullMonthNameTrabajador = colaborador.FechaIngreso.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            report.Parameters["fecha"].Value = DateTime.Now.Day + " de " + fullMonthName + " de " + DateTime.Now.Year; ;
            report.Parameters["nombres"].Value = colaborador.ApellidosNombres;
            report.Parameters["cedula"].Value = persona.Identificacion;
            report.Parameters["fechaIngreso"].Value = colaborador.FechaIngreso.Value.Day + " de " + fullMonthNameTrabajador + " de " + colaborador.FechaIngreso.Value.Year;
            report.Parameters["cargo"].Value = db.tNM_Cargos.Single(x => x.IdCargo == colaborador.IdCargo).Descripcion;
            return report;
        }
        public Reportes.CertificadoLaboralSueldo getCertificadoConSueldo(tGN_Personas persona, tNM_Colaboradores colaborador, Reportes.CertificadoLaboralSueldo report)
        {
            var listValores = db.sp_CalculoCertificadoSueldo(colaborador.IdColaborador, colaborador.IdEmpresa).FirstOrDefault();
            int idconceptoSueldo = colaborador.IdEmpresa == 1 ? 1 : 133;

            tNM_CalendarioNominas calNomima = db.tNM_CalendarioNominas.Where(x => x.IdTipoNomina == 2 && x.IdEmpresa == colaborador.IdEmpresa && x.IdTipoColaborador==colaborador.IdTipoColaborador).OrderByDescending(x => x.IdCalendarioNomina).FirstOrDefault();
            tNM_NominaDefinitiva nominaDefinitiva = db.tNM_NominaDefinitiva.Single(x => x.IdCalendarioNomina == calNomima.IdCalendarioNomina && x.IdColaborador == colaborador.IdColaborador && x.IdConcepto == idconceptoSueldo);
            string fullMonthName = DateTime.Now.Date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string fullMonthNameTrabajador = colaborador.FechaIngreso.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            report.Parameters["fecha"].Value = DateTime.Now.Day + " de " + fullMonthName + " de " + DateTime.Now.Year; ;
            report.Parameters["nombres"].Value = colaborador.ApellidosNombres;
            report.Parameters["cedula"].Value = persona.Identificacion;
            report.Parameters["fechaIngreso"].Value = colaborador.FechaIngreso.Value.Day + " de " + fullMonthNameTrabajador + " de " + colaborador.FechaIngreso.Value.Year;
            report.Parameters["ingresos"].Value = listValores.Promedio.ToString("0.##");
            report.Parameters["sueldo"].Value = nominaDefinitiva.Valor.Value.ToString("0.##");
            decimal variable = listValores.Promedio - nominaDefinitiva.Valor.Value;
            report.Parameters["variables"].Value = variable.ToString("0.##");
            report.Parameters["valorLetra"].Value = NumeroALetras(listValores.Promedio);
            report.Parameters["cargo"].Value = db.tNM_Cargos.Single(x => x.IdCargo == colaborador.IdCargo).Descripcion;

            return report;
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/file-rol")]
        public HttpResponseMessage PostCreateRolPdf(ParametersRoles parameters)
        {
            try
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                db.Configuration.LazyLoadingEnabled = false;
                tNM_Colaboradores colaborador = db.tNM_Colaboradores.FirstOrDefault(x => x.IdColaborador == parameters.idColaborador);
                
                string fechaIniciostr = Convert.ToDateTime(DateTime.Parse("01/" + parameters.mes + "/" + parameters.anio)).ToString("yyyy-MM-dd");
                DateTime fechaInicio = DateTime.Parse(fechaIniciostr);
                tNM_CalendarioNominas calendarioNomina = db.tNM_CalendarioNominas.FirstOrDefault(x => DbFunctions.TruncateTime (x.FechaInicio).Value.Year == parameters.anio && DbFunctions.TruncateTime(x.FechaInicio).Value.Month == parameters.mes && x.IdTipoNomina == parameters.idTipoNomina && x.IdTipoColaborador == colaborador.IdTipoColaborador && x.IdEmpresa == colaborador.IdEmpresa);
                if (calendarioNomina == null) {
                    response= Request.CreateErrorResponse(HttpStatusCode.NotFound, "Rol no existe");
                    return response;
                }
                tNM_TiposNomina tipoNomina = db.tNM_TiposNomina.FirstOrDefault(x => x.IdTipoNomina == calendarioNomina.IdTipoNomina);
                string fullMonthName = fechaInicio.Date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                tNM_NominaDefinitiva nomde = db.tNM_NominaDefinitiva.FirstOrDefault(x => x.IdColaborador == colaborador.IdColaborador && x.IdCalendarioNomina == calendarioNomina.IdCalendarioNomina);
                if (nomde == null) {
                    
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Rol no existe");
                    return response;
                }
                
                List<rNM_RecibosPago_Result> asigNacionDeduccion = db.rNM_RecibosPago(calendarioNomina.IdCalendarioNomina, colaborador.IdColaborador).ToList();
                string asignjson = JsonConvert.SerializeObject(asigNacionDeduccion);
                var asignacionf = JsonConvert.DeserializeObject<List<AsiganicionRol>>(asignjson);
                
             
                decimal sumAsignac = asignacionf.Sum(x => x.Asignacion);
                decimal sumDeducciones = asignacionf.Sum(x => x.Deduccion);
                decimal neto = sumAsignac - sumDeducciones;
                var resultRol = (from col in db.tNM_Colaboradores.ToList()
                                 join empresa in db.tGN_Empresas
                                 on col.IdEmpresa equals empresa.IdEmpresa
                                 join depar in db.tNM_Departamentos
                                 on col.IdDepartamento equals depar.IdDepartamento
                                 join cargo in db.tNM_Cargos
                                 on col.IdCargo equals cargo.IdCargo
                                 join suc in db.tNM_Sucursales
                                 on col.IdSucursal equals suc.IdSucursal
                                 join tipo in db.tNM_TiposColaboradores
                                 on col.IdTipoColaborador equals tipo.IdTipoColaborador

                                 where col.IdColaborador == colaborador.IdColaborador

                                 select new
                                 {
                                     ApellidosNombres = col.ApellidosNombres,
                                     TipoColaborador = tipo.Descripcion,
                                     Nomina = tipoNomina.Descripcion,
                                     fechaInicio = calendarioNomina.FechaInicio,
                                     fechaFin = calendarioNomina.FechaCorte,
                                     sucursal = suc.Descripcion,
                                     unidad = depar.Descripcion,
                                     cargo = cargo.Descripcion,
                                     empresa = empresa.Descripcion,
                                     ruc = empresa.RUC,
                                     direccion = empresa.Direccion,
                                     asignacioness = asignacionf,
                                     neto = neto,
                                 }


                               ).FirstOrDefault();
                string jsonDatasource = JsonConvert.SerializeObject(resultRol);
            
                RoldePagos reportRol = new RoldePagos();
                Asignaciones reportRolAsignaciones = new Asignaciones();
                Deducciones reporteRoleDeducciones= new Deducciones();

                string guid = Guid.NewGuid().ToString().Replace("-", "");
                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/") + guid + ".pdf";
                JsonDataSource jsd = new JsonDataSource();
                string url =
                    Url.Content("~/api/pdf/");
                
                


                jsd.JsonSource = new CustomJsonSource(jsonDatasource);
                jsd.Fill();
                reportRol.DataSource = jsd;

                reportRolAsignaciones.DataSource = jsd;
                reportRolAsignaciones.DataMember = "asignacioness";
                reporteRoleDeducciones.DataSource = jsd;
                reporteRoleDeducciones.DataMember = "asignacioness";
                reportRol.xrSubreport1.ReportSource  = reportRolAsignaciones;
                reportRol.xrSubreport2.ReportSource = reporteRoleDeducciones;
                MemoryStream ms = new MemoryStream();
                reportRol.ExportToPdf(path);

                




                byte[] bytes = System.IO.File.ReadAllBytes(path);

            //    var client = new RestClient("https://api.chat-api.com/instance255710/sendFile?token=hcjw4e098dyqj1z6");
            //    client.Timeout = -1;
            //    var request = new RestRequest(Method.POST);

            //    request.AddJsonBody(new
            //    {
            //        phone = "593990940528",
            //        body = "data:application/pdf;base64,"+Convert.ToBase64String(bytes),
            //        filename="rol.pdf",

            //});
            //    var response2 = client.Execute(request);


                response.Content = new ByteArrayContent(bytes);
                //Set the Response Content Length.  
                response.Content.Headers.ContentLength = bytes.LongLength;
                //Set the Content Disposition Header Value and FileName.  
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "Recibo de Pagos" + colaborador.ApellidosNombres + " "+fullMonthName+" "+parameters.anio+ ".pdf";
                //Set the File Content Type.  
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("2323.pdf"));
                System.IO.File.Delete(path);
                return response;
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/departamentos")]
        public HttpResponseMessage GetDepartamentos()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {

                var departamentos = (from departamento in db.tNM_Departamentos


                                     select new
                                     {
                                         name = departamento.Descripcion,
                                         code = departamento.IdDepartamento
                                     }
                          ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, departamentos.OrderBy(x => x.code));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // PUT: api/tNM_Departamentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_Departamentos(int id, tNM_Departamentos tNM_Departamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_Departamentos.IdDepartamento)
            {
                return BadRequest();
            }

            db.Entry(tNM_Departamentos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_DepartamentosExists(id))
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

        // POST: api/tNM_Departamentos
        [ResponseType(typeof(tNM_Departamentos))]
        public async Task<IHttpActionResult> PosttNM_Departamentos(tNM_Departamentos tNM_Departamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_Departamentos.Add(tNM_Departamentos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_Departamentos.IdDepartamento }, tNM_Departamentos);
        }

        // DELETE: api/tNM_Departamentos/5
        [ResponseType(typeof(tNM_Departamentos))]
        public async Task<IHttpActionResult> DeletetNM_Departamentos(int id)
        {
            tNM_Departamentos tNM_Departamentos = await db.tNM_Departamentos.FindAsync(id);
            if (tNM_Departamentos == null)
            {
                return NotFound();
            }

            db.tNM_Departamentos.Remove(tNM_Departamentos);
            await db.SaveChangesAsync();

            return Ok(tNM_Departamentos);
        }
        private IActionResult File(object memory, object p, object file)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_DepartamentosExists(int id)
        {
            return db.tNM_Departamentos.Count(e => e.IdDepartamento == id) > 0;
        }
        public string NumeroALetras(decimal numberAsString)
        {
            string dec;

            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            if (decimales > 0)
            {
                //dec = " PESOS CON " + decimales.ToString() + "/100";
                dec = $" {decimales:0,0}/100 dólares de los Estados Unidos de América ";
            }
            //Código agregado por mí
            else
            {
                //dec = " PESOS CON " + decimales.ToString() + "/100";
                dec = $" {decimales:0,0}/100 dólares de los Estados Unidos de América ";
            }
            var res = NumeroALetrasI(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string NumeroALetrasI(double value)
        {
            string num2Text; value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetrasI(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetrasI(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetrasI(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetrasI(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetrasI(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetrasI(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetrasI(Math.Truncate(value / 100) * 100) + " " + NumeroALetrasI(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetrasI(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetrasI(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasI(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetrasI(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetrasI(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasI(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetrasI(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetrasI(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetrasI(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        }
    }
}