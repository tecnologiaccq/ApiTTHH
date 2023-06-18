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
    public class BEMPL_CAT_NIVEL_ESTUDIOController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        // GET: api/BEMPL_CAT_NIVEL_ESTUDIO
        //public IQueryable<BEMPL_CAT_NIVEL_ESTUDIO> GetBEMPL_CAT_NIVEL_ESTUDIO()
        //{
        //    return db.BEMPL_CAT_NIVEL_ESTUDIO;
        //}
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        // GET: api/BEMPL_CAT_ESTADO_CIVIL
        public HttpResponseMessage GetBEMPL_CAT_NIVEL_ESTUDIO()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_NIVEL_ESTUDIO.Where(x => x.Activo == true).Select(x => new {
                x.IdNivelEstudio,
                x.NivelEstudioDescripcion
            }));
        }
        // GET: api/BEMPL_CAT_NIVEL_ESTUDIO/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ESTUDIO))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_NIVEL_ESTUDIO(int id)
        {
            BEMPL_CAT_NIVEL_ESTUDIO bEMPL_CAT_NIVEL_ESTUDIO = await db.BEMPL_CAT_NIVEL_ESTUDIO.FindAsync(id);
            if (bEMPL_CAT_NIVEL_ESTUDIO == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_NIVEL_ESTUDIO);
        }

        // PUT: api/BEMPL_CAT_NIVEL_ESTUDIO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_NIVEL_ESTUDIO(int id, BEMPL_CAT_NIVEL_ESTUDIO bEMPL_CAT_NIVEL_ESTUDIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_NIVEL_ESTUDIO.IdNivelEstudio)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_NIVEL_ESTUDIO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_NIVEL_ESTUDIOExists(id))
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

        // POST: api/BEMPL_CAT_NIVEL_ESTUDIO
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ESTUDIO))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_NIVEL_ESTUDIO(BEMPL_CAT_NIVEL_ESTUDIO bEMPL_CAT_NIVEL_ESTUDIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_NIVEL_ESTUDIO.Add(bEMPL_CAT_NIVEL_ESTUDIO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_NIVEL_ESTUDIO.IdNivelEstudio }, bEMPL_CAT_NIVEL_ESTUDIO);
        }

        // DELETE: api/BEMPL_CAT_NIVEL_ESTUDIO/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ESTUDIO))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_NIVEL_ESTUDIO(int id)
        {
            BEMPL_CAT_NIVEL_ESTUDIO bEMPL_CAT_NIVEL_ESTUDIO = await db.BEMPL_CAT_NIVEL_ESTUDIO.FindAsync(id);
            if (bEMPL_CAT_NIVEL_ESTUDIO == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_NIVEL_ESTUDIO.Remove(bEMPL_CAT_NIVEL_ESTUDIO);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_NIVEL_ESTUDIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_NIVEL_ESTUDIOExists(int id)
        {
            return db.BEMPL_CAT_NIVEL_ESTUDIO.Count(e => e.IdNivelEstudio == id) > 0;
        }
    }
}