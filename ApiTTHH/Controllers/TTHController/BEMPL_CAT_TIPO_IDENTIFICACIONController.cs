
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
    public class BEMPL_CAT_TIPO_IDENTIFICACIONController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        // GET: api/BEMPL_CAT_TIPO_IDENTIFICACION
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        
        public HttpResponseMessage GetBEMPL_CAT_TIPO_IDENTIFICACION()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_TIPO_IDENTIFICACION.Where(x => x.Estado == true).Select(x => new { x.IdTipoIdentificacion, x.Descripcion }));
             ;
        }

        // GET: api/BEMPL_CAT_TIPO_IDENTIFICACION/5
        [ResponseType(typeof(BEMPL_CAT_TIPO_IDENTIFICACION))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_TIPO_IDENTIFICACION(int id)
        {
            BEMPL_CAT_TIPO_IDENTIFICACION bEMPL_CAT_TIPO_IDENTIFICACION = await db.BEMPL_CAT_TIPO_IDENTIFICACION.FindAsync(id);
            if (bEMPL_CAT_TIPO_IDENTIFICACION == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_TIPO_IDENTIFICACION);
        }

        // PUT: api/BEMPL_CAT_TIPO_IDENTIFICACION/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_TIPO_IDENTIFICACION(int id, BEMPL_CAT_TIPO_IDENTIFICACION bEMPL_CAT_TIPO_IDENTIFICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_TIPO_IDENTIFICACION.IdTipoIdentificacion)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_TIPO_IDENTIFICACION).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_TIPO_IDENTIFICACIONExists(id))
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

        // POST: api/BEMPL_CAT_TIPO_IDENTIFICACION
        [ResponseType(typeof(BEMPL_CAT_TIPO_IDENTIFICACION))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_TIPO_IDENTIFICACION(BEMPL_CAT_TIPO_IDENTIFICACION bEMPL_CAT_TIPO_IDENTIFICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_TIPO_IDENTIFICACION.Add(bEMPL_CAT_TIPO_IDENTIFICACION);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_TIPO_IDENTIFICACION.IdTipoIdentificacion }, bEMPL_CAT_TIPO_IDENTIFICACION);
        }

        // DELETE: api/BEMPL_CAT_TIPO_IDENTIFICACION/5
        [ResponseType(typeof(BEMPL_CAT_TIPO_IDENTIFICACION))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_TIPO_IDENTIFICACION(int id)
        {
            BEMPL_CAT_TIPO_IDENTIFICACION bEMPL_CAT_TIPO_IDENTIFICACION = await db.BEMPL_CAT_TIPO_IDENTIFICACION.FindAsync(id);
            if (bEMPL_CAT_TIPO_IDENTIFICACION == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_TIPO_IDENTIFICACION.Remove(bEMPL_CAT_TIPO_IDENTIFICACION);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_TIPO_IDENTIFICACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_TIPO_IDENTIFICACIONExists(int id)
        {
            return db.BEMPL_CAT_TIPO_IDENTIFICACION.Count(e => e.IdTipoIdentificacion == id) > 0;
        }
    }
}