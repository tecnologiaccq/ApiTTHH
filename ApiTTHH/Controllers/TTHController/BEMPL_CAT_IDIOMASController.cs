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
    public class BEMPL_CAT_IDIOMASController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        // GET: api/BEMPL_CAT_IDIOMAS
        public HttpResponseMessage GetBEMPL_CAT_IDIOMAS()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_IDIOMAS.Where(x => x.Activo == true).Select(x => new { x.IdIdioma, x.IdiomaDescripcion }));
            ;
        }

        // GET: api/BEMPL_CAT_IDIOMAS/5
        [ResponseType(typeof(BEMPL_CAT_IDIOMAS))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_IDIOMAS(int id)
        {
            BEMPL_CAT_IDIOMAS bEMPL_CAT_IDIOMAS = await db.BEMPL_CAT_IDIOMAS.FindAsync(id);
            if (bEMPL_CAT_IDIOMAS == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_IDIOMAS);
        }

        // PUT: api/BEMPL_CAT_IDIOMAS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_IDIOMAS(int id, BEMPL_CAT_IDIOMAS bEMPL_CAT_IDIOMAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_IDIOMAS.IdIdioma)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_IDIOMAS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_IDIOMASExists(id))
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

        // POST: api/BEMPL_CAT_IDIOMAS
        [ResponseType(typeof(BEMPL_CAT_IDIOMAS))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_IDIOMAS(BEMPL_CAT_IDIOMAS bEMPL_CAT_IDIOMAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_IDIOMAS.Add(bEMPL_CAT_IDIOMAS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_IDIOMAS.IdIdioma }, bEMPL_CAT_IDIOMAS);
        }

        // DELETE: api/BEMPL_CAT_IDIOMAS/5
        [ResponseType(typeof(BEMPL_CAT_IDIOMAS))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_IDIOMAS(int id)
        {
            BEMPL_CAT_IDIOMAS bEMPL_CAT_IDIOMAS = await db.BEMPL_CAT_IDIOMAS.FindAsync(id);
            if (bEMPL_CAT_IDIOMAS == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_IDIOMAS.Remove(bEMPL_CAT_IDIOMAS);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_IDIOMAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_IDIOMASExists(int id)
        {
            return db.BEMPL_CAT_IDIOMAS.Count(e => e.IdIdioma == id) > 0;
        }
    }
}