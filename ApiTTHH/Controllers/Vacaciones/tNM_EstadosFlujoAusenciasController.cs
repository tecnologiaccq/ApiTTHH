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

namespace ApiTTHH.Controllers.Vacaciones
{
    public class tNM_EstadosFlujoAusenciasController : ApiController
    {

        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNM_EstadosFlujoAusencias
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<tNM_EstadosFlujoAusencias> GettNM_EstadosFlujoAusencias()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.tNM_EstadosFlujoAusencias.Where(X => X.Estado == true);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/feriados/")]
        public HttpResponseMessage GettNmFeriados()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.sp_tNMFeriados());
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // GET: api/tNM_EstadosFlujoAusencias/5
        [ResponseType(typeof(tNM_EstadosFlujoAusencias))]
        public async Task<IHttpActionResult> GettNM_EstadosFlujoAusencias(int id)
        {
            tNM_EstadosFlujoAusencias tNM_EstadosFlujoAusencias = await db.tNM_EstadosFlujoAusencias.FindAsync(id);
            if (tNM_EstadosFlujoAusencias == null)
            {
                return NotFound();
            }

            return Ok(tNM_EstadosFlujoAusencias);
        }

        // PUT: api/tNM_EstadosFlujoAusencias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_EstadosFlujoAusencias(int id, tNM_EstadosFlujoAusencias tNM_EstadosFlujoAusencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_EstadosFlujoAusencias.IDEstado)
            {
                return BadRequest();
            }

            db.Entry(tNM_EstadosFlujoAusencias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_EstadosFlujoAusenciasExists(id))
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

        // POST: api/tNM_EstadosFlujoAusencias
        [ResponseType(typeof(tNM_EstadosFlujoAusencias))]
        public async Task<IHttpActionResult> PosttNM_EstadosFlujoAusencias(tNM_EstadosFlujoAusencias tNM_EstadosFlujoAusencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_EstadosFlujoAusencias.Add(tNM_EstadosFlujoAusencias);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_EstadosFlujoAusencias.IDEstado }, tNM_EstadosFlujoAusencias);
        }

        // DELETE: api/tNM_EstadosFlujoAusencias/5
        [ResponseType(typeof(tNM_EstadosFlujoAusencias))]
        public async Task<IHttpActionResult> DeletetNM_EstadosFlujoAusencias(int id)
        {
            tNM_EstadosFlujoAusencias tNM_EstadosFlujoAusencias = await db.tNM_EstadosFlujoAusencias.FindAsync(id);
            if (tNM_EstadosFlujoAusencias == null)
            {
                return NotFound();
            }

            db.tNM_EstadosFlujoAusencias.Remove(tNM_EstadosFlujoAusencias);
            await db.SaveChangesAsync();

            return Ok(tNM_EstadosFlujoAusencias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_EstadosFlujoAusenciasExists(int id)
        {
            return db.tNM_EstadosFlujoAusencias.Count(e => e.IDEstado == id) > 0;
        }
    }
}