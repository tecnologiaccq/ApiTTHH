using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiTTHH.Models;

namespace ApiTTHH.Controllers.Colaboradores
{
    public class tNM_ColaboradoresController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNM_Colaboradores
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<tNM_Colaboradores> GettNM_Colaboradores()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.tNM_Colaboradores.Where(x=>x.IdEstado==1);
        }

        // GET: api/tNM_Colaboradores/5
        [ResponseType(typeof(tNM_Colaboradores))]
        public async Task<IHttpActionResult> GettNM_Colaboradores(int id)
        {
            tNM_Colaboradores tNM_Colaboradores = await db.tNM_Colaboradores.FindAsync(id);
            if (tNM_Colaboradores == null)
            {
                return NotFound();
            }

            return Ok(tNM_Colaboradores);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/colaboradores/")]
        public HttpResponseMessage GetColabordoresActivos()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, db.tNM_Colaboradores.Where(x => x.IdEstado == 1).OrderBy(x => x.ApellidosNombres));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/colaboradores-new/{idColaborador}")]
        public HttpResponseMessage GetColabordoresActivosNew(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                var colaboradores = db.tNM_Colaboradores.Where(x => x.IdEstado == 1 && x.IdColaborador!=idColaborador).Select(y => new{ y.IdColaborador, y.IdPersona,y.nickname,y.ApellidosNombres,y.UrlFoto,y.tNM_Departamentos.Descripcion,cargo=y.tNM_Cargos.Descripcion}).OrderBy(x=>x.ApellidosNombres);
                return Request.CreateResponse(HttpStatusCode.OK, colaboradores);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/ausencias-vacaciones/{idColaborador}")]
        public HttpResponseMessage GetHome(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);

            try
            {
                var result = db.sp_AusenciasCCQ(idColaborador);
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
        [Route("api/vacacionesdias/{idColaborador}")]
        public HttpResponseMessage GetColaboradorDiasVacaciones(int idColaborador)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_tnmDiasVacacionesColaborador(idColaborador));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/colaboradores-saldos/")]
        public HttpResponseMessage GetColabordoresActivosSaldos()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                var colaboradoresSaldos = (from colaborador in db.tNM_Colaboradores

                                           join persona in db.tGN_Personas
                                           on colaborador.IdPersona equals persona.IdPersonas
                                           //join empresa in db.tGN_Empresas
                                           //on colaborador.IdEmpresa equals empresa.IdEmpresa
                                           join departamento in db.tNM_Departamentos
                                           on colaborador.IdDepartamento equals departamento.IdDepartamento
                                           join tipoColaborador in db.tNM_TiposColaboradores
                                           on colaborador.IdTipoColaborador equals tipoColaborador.IdTipoColaborador
                                           where colaborador.IdEstado == 1
                                           select new
                                           {
                                               idColaborador = colaborador.IdColaborador,
                                               identificacion = persona.Identificacion,
                                               nombres = persona.ApellidoNombre,
                                               empresa = (from empresaI in db.tGN_Empresas
                                                          where empresaI.IdEmpresa == colaborador.IdEmpresa
                                                          select new
                                                          {
                                                             name=empresaI.Descripcion,
                                                             code=empresaI.IdEmpresa
                                                          }
                                                               ).FirstOrDefault(),
                                               tipoColaborador = (from tipoI in db.tNM_TiposColaboradores
                                                                  where tipoI.IdTipoColaborador == colaborador.IdTipoColaborador
                                                                  select new
                                                                  {
                                                                      name = tipoI.Descripcion,
                                                                      code = tipoI.IdTipoColaborador
                                                                  }
                                                               ).FirstOrDefault(),
                                               departamento = (from departamentoI in db.tNM_Departamentos
                                                               where departamentoI.IdDepartamento == colaborador.IdDepartamento
                                                               select new
                                                               {
                                                                   name = departamentoI.Descripcion,
                                                                   code = departamentoI.IdDepartamento
                                                               }
                                                               ).FirstOrDefault(),
                                               cupoAsignado = (from ingreso in db.tNM_IngresosBeneficiosColaborador
                                                               where ingreso.idTipoBeneficio == 1 && ingreso.IdColaborador == colaborador.IdColaborador
                                                               select new
                                                               {
                                                                   ingreso.Valor,
                                                                   ingreso.Plazo
                                                               }
                                                               ).FirstOrDefault(),
                                               saldo = (from saldos in db.tNM_SaldosCuentaColaborador
                                                         where saldos.IdColaborador == colaborador.IdColaborador
                                                         select new
                                                         {
                                                             saldos.SaldoCupo,
                                                             saldos.SaldoGiftCard
                                                         }
                                                               ).FirstOrDefault(),
                                               estadosCuenta = (from estadoCuenta in db.tNM_EstadosCuentaColaborador
                                                                where estadoCuenta.IdColaborador == colaborador.IdColaborador
                                                                select new
                                                                {
                                                                    estadoCuenta
                                                                }
                                                              ).ToList(),
                                                               tarjetas = (from tarjeta in db.tNM_IngresosBeneficiosColaborador
                                                                                where tarjeta.IdColaborador == colaborador.IdColaborador && tarjeta.idTipoBeneficio!=1
                                                                                select new
                                                                                {
                                                                                    id=tarjeta.IdIngresoBeneficio,
                                                                                    descripcion=tarjeta.Descripcion,
                                                                                    valor=tarjeta.Valor,
                                                                                    fecha=tarjeta.FechaCreacion,
                                                                                    estadoId=tarjeta.ActivaCumpleaños,
                                                                                    estado=tarjeta.ActivaCumpleaños==true ? "Pendiente":"Activa"
                                                                                }
                                                              ).ToList(),
                                                               tarjetasCount = (from tarjeta in db.tNM_IngresosBeneficiosColaborador
                                                                           where tarjeta.IdColaborador == colaborador.IdColaborador && tarjeta.idTipoBeneficio != 1
                                                                           select new
                                                                           {
                                                                               id = tarjeta.IdIngresoBeneficio,
                                                                               descripcion = tarjeta.Descripcion,
                                                                               valor = tarjeta.Valor,
                                                                               fecha = tarjeta.FechaCreacion,
                                                                               estadoId = tarjeta.ActivaCumpleaños,
                                                                               estado = tarjeta.ActivaCumpleaños == true ? "Pendiente" : "Activa"
                                                                           }
                                                              ).ToList().Count
                                           }
                         ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, colaboradoresSaldos.OrderBy(x => x.nombres));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // PUT: api/tNM_Colaboradores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_Colaboradores(int id, tNM_Colaboradores tNM_Colaboradores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_Colaboradores.IdColaborador)
            {
                return BadRequest();
            }

            db.Entry(tNM_Colaboradores).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_ColaboradoresExists(id))
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

        // POST: api/tNM_Colaboradores
        [ResponseType(typeof(tNM_Colaboradores))]
        public async Task<IHttpActionResult> PosttNM_Colaboradores(tNM_Colaboradores tNM_Colaboradores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_Colaboradores.Add(tNM_Colaboradores);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_Colaboradores.IdColaborador }, tNM_Colaboradores);
        }

        // DELETE: api/tNM_Colaboradores/5
        [ResponseType(typeof(tNM_Colaboradores))]
        public async Task<IHttpActionResult> DeletetNM_Colaboradores(int id)
        {
            tNM_Colaboradores tNM_Colaboradores = await db.tNM_Colaboradores.FindAsync(id);
            if (tNM_Colaboradores == null)
            {
                return NotFound();
            }

            db.tNM_Colaboradores.Remove(tNM_Colaboradores);
            await db.SaveChangesAsync();

            return Ok(tNM_Colaboradores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_ColaboradoresExists(int id)
        {
            return db.tNM_Colaboradores.Count(e => e.IdColaborador == id) > 0;
        }
    }
}