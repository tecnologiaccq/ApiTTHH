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
    public class BEMPL_CAT_NACIONALIDADController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        // GET: api/BEMPL_CAT_NACIONALIDAD
        public HttpResponseMessage GetBEMPL_CAT_NACIONALIDAD()
        {
            db.Configuration.LazyLoadingEnabled |= false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_NACIONALIDAD.Where(x => x.Estado == true).Select(x => new { x.IdNacionalidad, x.Descripcion }));
        }

        // GET: api/BEMPL_CAT_NACIONALIDAD/5
        [ResponseType(typeof(BEMPL_CAT_NACIONALIDAD))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_NACIONALIDAD(int id)
        {
            BEMPL_CAT_NACIONALIDAD bEMPL_CAT_NACIONALIDAD = await db.BEMPL_CAT_NACIONALIDAD.FindAsync(id);
            if (bEMPL_CAT_NACIONALIDAD == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_NACIONALIDAD);
        }

        // PUT: api/BEMPL_CAT_NACIONALIDAD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_NACIONALIDAD(int id, BEMPL_CAT_NACIONALIDAD bEMPL_CAT_NACIONALIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_NACIONALIDAD.IdNacionalidad)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_NACIONALIDAD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_NACIONALIDADExists(id))
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

        // POST: api/BEMPL_CAT_NACIONALIDAD
        [ResponseType(typeof(BEMPL_CAT_NACIONALIDAD))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_NACIONALIDAD(BEMPL_CAT_NACIONALIDAD bEMPL_CAT_NACIONALIDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_NACIONALIDAD.Add(bEMPL_CAT_NACIONALIDAD);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_NACIONALIDAD.IdNacionalidad }, bEMPL_CAT_NACIONALIDAD);
        }

        // DELETE: api/BEMPL_CAT_NACIONALIDAD/5
        [ResponseType(typeof(BEMPL_CAT_NACIONALIDAD))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_NACIONALIDAD(int id)
        {
            BEMPL_CAT_NACIONALIDAD bEMPL_CAT_NACIONALIDAD = await db.BEMPL_CAT_NACIONALIDAD.FindAsync(id);
            if (bEMPL_CAT_NACIONALIDAD == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_NACIONALIDAD.Remove(bEMPL_CAT_NACIONALIDAD);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_NACIONALIDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_NACIONALIDADExists(int id)
        {
            return db.BEMPL_CAT_NACIONALIDAD.Count(e => e.IdNacionalidad == id) > 0;
        }
    }
}