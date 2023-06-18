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
    public class BEMPL_CAT_PROVINCIASController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        // GET: api/BEMPL_CAT_PROVINCIAS
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public HttpResponseMessage GetBEMPL_CAT_PROVINCIAS()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_PROVINCIAS.Where(x => x.Activo == true).Select(x => new { x.IdProvincia, x.Provincia }));
            ;
        }

        // GET: api/BEMPL_CAT_PROVINCIAS/5
        [ResponseType(typeof(BEMPL_CAT_PROVINCIAS))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_PROVINCIAS(int id)
        {
            BEMPL_CAT_PROVINCIAS bEMPL_CAT_PROVINCIAS = await db.BEMPL_CAT_PROVINCIAS.FindAsync(id);
            if (bEMPL_CAT_PROVINCIAS == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_PROVINCIAS);
        }

        // PUT: api/BEMPL_CAT_PROVINCIAS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_PROVINCIAS(int id, BEMPL_CAT_PROVINCIAS bEMPL_CAT_PROVINCIAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_PROVINCIAS.IdProvincia)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_PROVINCIAS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_PROVINCIASExists(id))
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

        // POST: api/BEMPL_CAT_PROVINCIAS
        [ResponseType(typeof(BEMPL_CAT_PROVINCIAS))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_PROVINCIAS(BEMPL_CAT_PROVINCIAS bEMPL_CAT_PROVINCIAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_PROVINCIAS.Add(bEMPL_CAT_PROVINCIAS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BEMPL_CAT_PROVINCIASExists(bEMPL_CAT_PROVINCIAS.IdProvincia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_PROVINCIAS.IdProvincia }, bEMPL_CAT_PROVINCIAS);
        }

        // DELETE: api/BEMPL_CAT_PROVINCIAS/5
        [ResponseType(typeof(BEMPL_CAT_PROVINCIAS))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_PROVINCIAS(int id)
        {
            BEMPL_CAT_PROVINCIAS bEMPL_CAT_PROVINCIAS = await db.BEMPL_CAT_PROVINCIAS.FindAsync(id);
            if (bEMPL_CAT_PROVINCIAS == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_PROVINCIAS.Remove(bEMPL_CAT_PROVINCIAS);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_PROVINCIAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_PROVINCIASExists(int id)
        {
            return db.BEMPL_CAT_PROVINCIAS.Count(e => e.IdProvincia == id) > 0;
        }
    }
}