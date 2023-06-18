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

namespace ApiTTHH.Controllers.TTHController
{
    public class BEMPL_CAT_GENEROController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        // GET: api/BEMPL_CAT_GENERO
        public HttpResponseMessage GetBEMPL_CAT_GENERO()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_GENERO.Where(x => x.Estado == true).Select(x => new { x.IdGenero, x.Descripcion }));
            ;
        }

        // GET: api/BEMPL_CAT_GENERO/5
        [ResponseType(typeof(BEMPL_CAT_GENERO))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_GENERO(int id)
        {
            BEMPL_CAT_GENERO bEMPL_CAT_GENERO = await db.BEMPL_CAT_GENERO.FindAsync(id);
            if (bEMPL_CAT_GENERO == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_GENERO);
        }

        // PUT: api/BEMPL_CAT_GENERO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_GENERO(int id, BEMPL_CAT_GENERO bEMPL_CAT_GENERO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_GENERO.IdGenero)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_GENERO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_GENEROExists(id))
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

        // POST: api/BEMPL_CAT_GENERO
        [ResponseType(typeof(BEMPL_CAT_GENERO))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_GENERO(BEMPL_CAT_GENERO bEMPL_CAT_GENERO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_GENERO.Add(bEMPL_CAT_GENERO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_GENERO.IdGenero }, bEMPL_CAT_GENERO);
        }

        // DELETE: api/BEMPL_CAT_GENERO/5
        [ResponseType(typeof(BEMPL_CAT_GENERO))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_GENERO(int id)
        {
            BEMPL_CAT_GENERO bEMPL_CAT_GENERO = await db.BEMPL_CAT_GENERO.FindAsync(id);
            if (bEMPL_CAT_GENERO == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_GENERO.Remove(bEMPL_CAT_GENERO);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_GENERO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_GENEROExists(int id)
        {
            return db.BEMPL_CAT_GENERO.Count(e => e.IdGenero == id) > 0;
        }
    }
}