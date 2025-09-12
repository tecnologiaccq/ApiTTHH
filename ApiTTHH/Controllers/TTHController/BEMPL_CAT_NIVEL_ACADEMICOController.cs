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
    public class BEMPL_CAT_NIVEL_ACADEMICOController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        // GET: api/BEMPL_CAT_NIVEL_ACADEMICO
        //public IQueryable<BEMPL_CAT_NIVEL_ACADEMICO> GetBEMPL_CAT_NIVEL_ACADEMICO()
        //{
        //    return db.BEMPL_CAT_NIVEL_ACADEMICO;
        //}
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]

        public HttpResponseMessage GetBEMPL_CAT_NIVEL_ACADEMICO()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_NIVEL_ACADEMICO.Where(x => x.Activo == true).Select(x => new {
                x.IdEstadoNivelAcademico,
                x.DescripcionNivelAcademico
            }));
        }
        // GET: api/BEMPL_CAT_NIVEL_ACADEMICO/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ACADEMICO))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_NIVEL_ACADEMICO(int id)
        {
            BEMPL_CAT_NIVEL_ACADEMICO bEMPL_CAT_NIVEL_ACADEMICO = await db.BEMPL_CAT_NIVEL_ACADEMICO.FindAsync(id);
            if (bEMPL_CAT_NIVEL_ACADEMICO == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_NIVEL_ACADEMICO);
        }

        // PUT: api/BEMPL_CAT_NIVEL_ACADEMICO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_NIVEL_ACADEMICO(int id, BEMPL_CAT_NIVEL_ACADEMICO bEMPL_CAT_NIVEL_ACADEMICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_NIVEL_ACADEMICO.IdEstadoNivelAcademico)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_NIVEL_ACADEMICO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_NIVEL_ACADEMICOExists(id))
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

        // POST: api/BEMPL_CAT_NIVEL_ACADEMICO
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ACADEMICO))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_NIVEL_ACADEMICO(BEMPL_CAT_NIVEL_ACADEMICO bEMPL_CAT_NIVEL_ACADEMICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_NIVEL_ACADEMICO.Add(bEMPL_CAT_NIVEL_ACADEMICO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_NIVEL_ACADEMICO.IdEstadoNivelAcademico }, bEMPL_CAT_NIVEL_ACADEMICO);
        }

        // DELETE: api/BEMPL_CAT_NIVEL_ACADEMICO/5
        [ResponseType(typeof(BEMPL_CAT_NIVEL_ACADEMICO))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_NIVEL_ACADEMICO(int id)
        {
            BEMPL_CAT_NIVEL_ACADEMICO bEMPL_CAT_NIVEL_ACADEMICO = await db.BEMPL_CAT_NIVEL_ACADEMICO.FindAsync(id);
            if (bEMPL_CAT_NIVEL_ACADEMICO == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_NIVEL_ACADEMICO.Remove(bEMPL_CAT_NIVEL_ACADEMICO);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_NIVEL_ACADEMICO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_NIVEL_ACADEMICOExists(int id)
        {
            return db.BEMPL_CAT_NIVEL_ACADEMICO.Count(e => e.IdEstadoNivelAcademico == id) > 0;
        }
    }
}