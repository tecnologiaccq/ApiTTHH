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
    public class BEMPL_CAT_CIUDADController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/ciudades-provincia/{idProvincia}")]
        public HttpResponseMessage GetCiudad(int idProvincia)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {

               
                return Request.CreateResponse(HttpStatusCode.OK, db.BEMPL_CAT_CIUDAD.Where(x => x.IdProvincia==idProvincia).Select(x=>new { 
                    x.IdCiudad,x.Ciudad
                }));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // GET: api/BEMPL_CAT_CIUDAD
        public IQueryable<BEMPL_CAT_CIUDAD> GetBEMPL_CAT_CIUDAD()
        {
            return db.BEMPL_CAT_CIUDAD;
        }

        // GET: api/BEMPL_CAT_CIUDAD/5
        [ResponseType(typeof(BEMPL_CAT_CIUDAD))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_CIUDAD(int id)
        {
            BEMPL_CAT_CIUDAD bEMPL_CAT_CIUDAD = await db.BEMPL_CAT_CIUDAD.FindAsync(id);
            if (bEMPL_CAT_CIUDAD == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_CIUDAD);
        }

        // PUT: api/BEMPL_CAT_CIUDAD/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_CIUDAD(int id, BEMPL_CAT_CIUDAD bEMPL_CAT_CIUDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_CIUDAD.IdCiudad)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_CIUDAD).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_CIUDADExists(id))
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

        // POST: api/BEMPL_CAT_CIUDAD
        [ResponseType(typeof(BEMPL_CAT_CIUDAD))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_CIUDAD(BEMPL_CAT_CIUDAD bEMPL_CAT_CIUDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_CIUDAD.Add(bEMPL_CAT_CIUDAD);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BEMPL_CAT_CIUDADExists(bEMPL_CAT_CIUDAD.IdCiudad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_CIUDAD.IdCiudad }, bEMPL_CAT_CIUDAD);
        }

        // DELETE: api/BEMPL_CAT_CIUDAD/5
        [ResponseType(typeof(BEMPL_CAT_CIUDAD))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_CIUDAD(int id)
        {
            BEMPL_CAT_CIUDAD bEMPL_CAT_CIUDAD = await db.BEMPL_CAT_CIUDAD.FindAsync(id);
            if (bEMPL_CAT_CIUDAD == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_CIUDAD.Remove(bEMPL_CAT_CIUDAD);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_CIUDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_CIUDADExists(int id)
        {
            return db.BEMPL_CAT_CIUDAD.Count(e => e.IdCiudad == id) > 0;
        }
    }
}