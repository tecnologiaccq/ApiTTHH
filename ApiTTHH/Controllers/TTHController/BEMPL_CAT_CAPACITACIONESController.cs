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
    public class BEMPL_CAT_CAPACITACIONESController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        // GET: api/BEMPL_CAT_CAPACITACIONES
        public IQueryable<BEMPL_CAT_CAPACITACIONES> GetBEMPL_CAT_CAPACITACIONES()
        {
            db.Configuration.LazyLoadingEnabled = false ;
            return db.BEMPL_CAT_CAPACITACIONES.Where(x=>x.Estado==true);
        }

        // GET: api/BEMPL_CAT_CAPACITACIONES/5
        [ResponseType(typeof(BEMPL_CAT_CAPACITACIONES))]
        public async Task<IHttpActionResult> GetBEMPL_CAT_CAPACITACIONES(int id)
        {
            BEMPL_CAT_CAPACITACIONES bEMPL_CAT_CAPACITACIONES = await db.BEMPL_CAT_CAPACITACIONES.FindAsync(id);
            if (bEMPL_CAT_CAPACITACIONES == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_CAT_CAPACITACIONES);
        }

        // PUT: api/BEMPL_CAT_CAPACITACIONES/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_CAT_CAPACITACIONES(int id, BEMPL_CAT_CAPACITACIONES bEMPL_CAT_CAPACITACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_CAT_CAPACITACIONES.IdCapacitacion)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_CAT_CAPACITACIONES).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_CAT_CAPACITACIONESExists(id))
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

        // POST: api/BEMPL_CAT_CAPACITACIONES
        [ResponseType(typeof(BEMPL_CAT_CAPACITACIONES))]
        public async Task<IHttpActionResult> PostBEMPL_CAT_CAPACITACIONES(BEMPL_CAT_CAPACITACIONES bEMPL_CAT_CAPACITACIONES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_CAT_CAPACITACIONES.Add(bEMPL_CAT_CAPACITACIONES);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_CAT_CAPACITACIONES.IdCapacitacion }, bEMPL_CAT_CAPACITACIONES);
        }

        // DELETE: api/BEMPL_CAT_CAPACITACIONES/5
        [ResponseType(typeof(BEMPL_CAT_CAPACITACIONES))]
        public async Task<IHttpActionResult> DeleteBEMPL_CAT_CAPACITACIONES(int id)
        {
            BEMPL_CAT_CAPACITACIONES bEMPL_CAT_CAPACITACIONES = await db.BEMPL_CAT_CAPACITACIONES.FindAsync(id);
            if (bEMPL_CAT_CAPACITACIONES == null)
            {
                return NotFound();
            }

            db.BEMPL_CAT_CAPACITACIONES.Remove(bEMPL_CAT_CAPACITACIONES);
            await db.SaveChangesAsync();

            return Ok(bEMPL_CAT_CAPACITACIONES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_CAT_CAPACITACIONESExists(int id)
        {
            return db.BEMPL_CAT_CAPACITACIONES.Count(e => e.IdCapacitacion == id) > 0;
        }
    }
}