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
    public class BEMPL_CAT_ESTADO_CIVILController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        // GET: api/BEMPL_CAT_ESTADO_CIVIL
        public HttpResponseMessage GetBEMPL_CAT_ESTADO_CIVIL()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_ESTADO_CIVIL.Where(x=>x.Estado==true).Select(x=>new { 
                x.IdEstadoCivil,x.Descripcion
            }));
        }

        // GET: api/BEMPL_CAT_ESTADO_CIVIL/5
        [ResponseType(typeof(BEMPL_CAT_ESTADO_CIVIL))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_ESTADO_CIVIL(int id)
        {
            BEMPL_CAT_ESTADO_CIVIL bEMPL_CAT_ESTADO_CIVIL = await db.BEMPL_CAT_ESTADO_CIVIL.FindAsync(id);
            if (bEMPL_CAT_ESTADO_CIVIL == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_ESTADO_CIVIL);
        }

        // PUT: api/BEMPL_CAT_ESTADO_CIVIL/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_ESTADO_CIVIL(int id, BEMPL_CAT_ESTADO_CIVIL bEMPL_CAT_ESTADO_CIVIL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_ESTADO_CIVIL.IdEstadoCivil)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_ESTADO_CIVIL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_ESTADO_CIVILExists(id))
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

        // POST: api/BEMPL_CAT_ESTADO_CIVIL
        [ResponseType(typeof(BEMPL_CAT_ESTADO_CIVIL))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_ESTADO_CIVIL(BEMPL_CAT_ESTADO_CIVIL bEMPL_CAT_ESTADO_CIVIL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_ESTADO_CIVIL.Add(bEMPL_CAT_ESTADO_CIVIL);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_ESTADO_CIVIL.IdEstadoCivil }, bEMPL_CAT_ESTADO_CIVIL);
        }

        // DELETE: api/BEMPL_CAT_ESTADO_CIVIL/5
        [ResponseType(typeof(BEMPL_CAT_ESTADO_CIVIL))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_ESTADO_CIVIL(int id)
        {
            BEMPL_CAT_ESTADO_CIVIL bEMPL_CAT_ESTADO_CIVIL = await db.BEMPL_CAT_ESTADO_CIVIL.FindAsync(id);
            if (bEMPL_CAT_ESTADO_CIVIL == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_ESTADO_CIVIL.Remove(bEMPL_CAT_ESTADO_CIVIL);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_ESTADO_CIVIL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_ESTADO_CIVILExists(int id)
        {
            return db.BEMPL_CAT_ESTADO_CIVIL.Count(e => e.IdEstadoCivil == id) > 0;
        }
    }
}