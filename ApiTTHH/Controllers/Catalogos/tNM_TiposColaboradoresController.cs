using System;
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

namespace ApiTTHH.Controllers.Catalogos
{
    public class tNM_TiposColaboradoresController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNM_TiposColaboradores
        public IQueryable<tNM_TiposColaboradores> GettNM_TiposColaboradores()
        {
            return db.tNM_TiposColaboradores;
        }

        // GET: api/tNM_TiposColaboradores/5
        [ResponseType(typeof(tNM_TiposColaboradores))]
        public async Task<IHttpActionResult> GettNM_TiposColaboradores(int id)
        {
            tNM_TiposColaboradores tNM_TiposColaboradores = await db.tNM_TiposColaboradores.FindAsync(id);
            if (tNM_TiposColaboradores == null)
            {
                return NotFound();
            }

            return Ok(tNM_TiposColaboradores);
        }

        // PUT: api/tNM_TiposColaboradores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_TiposColaboradores(int id, tNM_TiposColaboradores tNM_TiposColaboradores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_TiposColaboradores.IdTipoColaborador)
            {
                return BadRequest();
            }

            db.Entry(tNM_TiposColaboradores).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_TiposColaboradoresExists(id))
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

        // POST: api/tNM_TiposColaboradores
        [ResponseType(typeof(tNM_TiposColaboradores))]
        public async Task<IHttpActionResult> PosttNM_TiposColaboradores(tNM_TiposColaboradores tNM_TiposColaboradores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_TiposColaboradores.Add(tNM_TiposColaboradores);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_TiposColaboradores.IdTipoColaborador }, tNM_TiposColaboradores);
        }

        // DELETE: api/tNM_TiposColaboradores/5
        [ResponseType(typeof(tNM_TiposColaboradores))]
        public async Task<IHttpActionResult> DeletetNM_TiposColaboradores(int id)
        {
            tNM_TiposColaboradores tNM_TiposColaboradores = await db.tNM_TiposColaboradores.FindAsync(id);
            if (tNM_TiposColaboradores == null)
            {
                return NotFound();
            }

            db.tNM_TiposColaboradores.Remove(tNM_TiposColaboradores);
            await db.SaveChangesAsync();

            return Ok(tNM_TiposColaboradores);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/tiposcolaborador")]
        public HttpResponseMessage GetDepartamentos()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {

                var tipos = (from tipo in db.tNM_TiposColaboradores
                             select new
                                     {
                                         name = tipo.Descripcion,
                                         code = tipo.IdTipoColaborador
                                     }
                          ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, tipos.OrderBy(x => x.code));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_TiposColaboradoresExists(int id)
        {
            return db.tNM_TiposColaboradores.Count(e => e.IdTipoColaborador == id) > 0;
        }
    }
}