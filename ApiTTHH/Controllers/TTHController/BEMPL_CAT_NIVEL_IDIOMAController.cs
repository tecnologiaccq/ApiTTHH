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
    public class BEMPL_CAT_NIVEL_IDIOMAController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        // GET: api/BEMPL_CAT_NIVEL_IDIOMA
        public HttpResponseMessage GetBEMPL_CAT_NIVEL_IDIOMA()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_NIVEL_IDIOMA.Where(x => x.Activo == true).Select(x => new { x.IdNivelIdioma, x.NivelIdiomaDescripcion }));
            ;
        }

        // GET: api/BEMPL_CAT_NIVEL_IDIOMA/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_IDIOMA))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_NIVEL_IDIOMA(int id)
        {
            BEMPL_CAT_NIVEL_IDIOMA bEMPL_CAT_NIVEL_IDIOMA = await db.BEMPL_CAT_NIVEL_IDIOMA.FindAsync(id);
            if (bEMPL_CAT_NIVEL_IDIOMA == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_NIVEL_IDIOMA);
        }

        // PUT: api/BEMPL_CAT_NIVEL_IDIOMA/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_NIVEL_IDIOMA(int id, BEMPL_CAT_NIVEL_IDIOMA bEMPL_CAT_NIVEL_IDIOMA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_NIVEL_IDIOMA.IdNivelIdioma)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_NIVEL_IDIOMA).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_NIVEL_IDIOMAExists(id))
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

        // POST: api/BEMPL_CAT_NIVEL_IDIOMA
        [ResponseType(typeof(BEMPL_CAT_NIVEL_IDIOMA))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_NIVEL_IDIOMA(BEMPL_CAT_NIVEL_IDIOMA bEMPL_CAT_NIVEL_IDIOMA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_NIVEL_IDIOMA.Add(bEMPL_CAT_NIVEL_IDIOMA);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_NIVEL_IDIOMA.IdNivelIdioma }, bEMPL_CAT_NIVEL_IDIOMA);
        }

        // DELETE: api/BEMPL_CAT_NIVEL_IDIOMA/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_IDIOMA))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_NIVEL_IDIOMA(int id)
        {
            BEMPL_CAT_NIVEL_IDIOMA bEMPL_CAT_NIVEL_IDIOMA = await db.BEMPL_CAT_NIVEL_IDIOMA.FindAsync(id);
            if (bEMPL_CAT_NIVEL_IDIOMA == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_NIVEL_IDIOMA.Remove(bEMPL_CAT_NIVEL_IDIOMA);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_NIVEL_IDIOMA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_NIVEL_IDIOMAExists(int id)
        {
            return db.BEMPL_CAT_NIVEL_IDIOMA.Count(e => e.IdNivelIdioma == id) > 0;
        }
    }
}