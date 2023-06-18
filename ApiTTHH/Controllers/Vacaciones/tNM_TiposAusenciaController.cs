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
    public class tNM_TiposAusenciaController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNM_TiposAusencia
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<tNM_TiposAusencia> GettNM_TiposAusencia()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.tNM_TiposAusencia.Where(x=>x.Estado==true);
        }

        // GET: api/tNM_TiposAusencia/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ResponseType(typeof(tNM_TiposAusencia))]
        public async Task<IHttpActionResult> GettNM_TiposAusencia(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            tNM_TiposAusencia tNM_TiposAusencia = await db.tNM_TiposAusencia.FindAsync(id);
            if (tNM_TiposAusencia == null)
            {
                return NotFound();
            }

            return Ok(tNM_TiposAusencia);
        }

        // PUT: api/tNM_TiposAusencia/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_TiposAusencia(int id, tNM_TiposAusencia tNM_TiposAusencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_TiposAusencia.IdAusencia)
            {
                return BadRequest();
            }

            db.Entry(tNM_TiposAusencia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_TiposAusenciaExists(id))
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

        // POST: api/tNM_TiposAusencia
        [ResponseType(typeof(tNM_TiposAusencia))]
        public async Task<IHttpActionResult> PosttNM_TiposAusencia(tNM_TiposAusencia tNM_TiposAusencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_TiposAusencia.Add(tNM_TiposAusencia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_TiposAusencia.IdAusencia }, tNM_TiposAusencia);
        }

        // DELETE: api/tNM_TiposAusencia/5
        [ResponseType(typeof(tNM_TiposAusencia))]
        public async Task<IHttpActionResult> DeletetNM_TiposAusencia(int id)
        {
            tNM_TiposAusencia tNM_TiposAusencia = await db.tNM_TiposAusencia.FindAsync(id);
            if (tNM_TiposAusencia == null)
            {
                return NotFound();
            }

            db.tNM_TiposAusencia.Remove(tNM_TiposAusencia);
            await db.SaveChangesAsync();

            return Ok(tNM_TiposAusencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_TiposAusenciaExists(int id)
        {
            return db.tNM_TiposAusencia.Count(e => e.IdAusencia == id) > 0;
        }
    }
}