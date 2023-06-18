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
    public class BEMPL_RELACION_REF_CATController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        // GET: api/BEMPL_RELACION_REF_CAT
        public HttpResponseMessage GetBEMPL_RELACION_REF_CAT()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_RELACION_REF_CAT.Where(x => x.Estado == true).Select(x => new { x.IdRelacionReferencia, x.Descripcion }));
            ;
        }

        // GET: api/BEMPL_RELACION_REF_CAT/5
        [ResponseType(typeof(BEMPL_RELACION_REF_CAT))]
        public async Task<IHttpActionResult> GetBEMPL_RELACION_REF_CAT(int id)
        {
            BEMPL_RELACION_REF_CAT bEMPL_RELACION_REF_CAT = await db.BEMPL_RELACION_REF_CAT.FindAsync(id);
            if (bEMPL_RELACION_REF_CAT == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_RELACION_REF_CAT);
        }

        // PUT: api/BEMPL_RELACION_REF_CAT/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_RELACION_REF_CAT(int id, BEMPL_RELACION_REF_CAT bEMPL_RELACION_REF_CAT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_RELACION_REF_CAT.IdRelacionReferencia)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_RELACION_REF_CAT).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_RELACION_REF_CATExists(id))
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

        // POST: api/BEMPL_RELACION_REF_CAT
        [ResponseType(typeof(BEMPL_RELACION_REF_CAT))]
        public async Task<IHttpActionResult> PostBEMPL_RELACION_REF_CAT(BEMPL_RELACION_REF_CAT bEMPL_RELACION_REF_CAT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_RELACION_REF_CAT.Add(bEMPL_RELACION_REF_CAT);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_RELACION_REF_CAT.IdRelacionReferencia }, bEMPL_RELACION_REF_CAT);
        }

        // DELETE: api/BEMPL_RELACION_REF_CAT/5
        [ResponseType(typeof(BEMPL_RELACION_REF_CAT))]
        public async Task<IHttpActionResult> DeleteBEMPL_RELACION_REF_CAT(int id)
        {
            BEMPL_RELACION_REF_CAT bEMPL_RELACION_REF_CAT = await db.BEMPL_RELACION_REF_CAT.FindAsync(id);
            if (bEMPL_RELACION_REF_CAT == null)
            {
                return NotFound();
            }

            db.BEMPL_RELACION_REF_CAT.Remove(bEMPL_RELACION_REF_CAT);
            await db.SaveChangesAsync();

            return Ok(bEMPL_RELACION_REF_CAT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_RELACION_REF_CATExists(int id)
        {
            return db.BEMPL_RELACION_REF_CAT.Count(e => e.IdRelacionReferencia == id) > 0;
        }
    }
}