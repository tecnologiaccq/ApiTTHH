
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

namespace ApiTTHH.Controllers.Catalogos
{
    public class tNm_BeneficiosCCQController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tNm_BeneficiosCCQ
        public IQueryable<tNm_BeneficiosCCQ> GettNm_BeneficiosCCQ()
        {
            return db.tNm_BeneficiosCCQ;
        }

        // GET: api/tNm_BeneficiosCCQ/5
        [ResponseType(typeof(tNm_BeneficiosCCQ))]
        public async Task<IHttpActionResult> GettNm_BeneficiosCCQ(int id)
        {
            tNm_BeneficiosCCQ tNm_BeneficiosCCQ = await db.tNm_BeneficiosCCQ.FindAsync(id);
            if (tNm_BeneficiosCCQ == null)
            {
                return NotFound();
            }

            return Ok(tNm_BeneficiosCCQ);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/beneficios")]
        public HttpResponseMessage GetBeneficios()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                
                var candidatos = (from beneficio in db.tNm_BeneficiosCCQ
                                  
                                  where beneficio.IdTipoBeneficio==2 || beneficio.IdTipoBeneficio == 3
                                  select new
                                  {
                                     name=beneficio.Descripcion,
                                     code=beneficio.IdTipoBeneficio
                                  }
                          ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, candidatos.OrderBy(x => x.code));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // PUT: api/tNm_BeneficiosCCQ/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNm_BeneficiosCCQ(int id, tNm_BeneficiosCCQ tNm_BeneficiosCCQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNm_BeneficiosCCQ.IdTipoBeneficio)
            {
                return BadRequest();
            }

            db.Entry(tNm_BeneficiosCCQ).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNm_BeneficiosCCQExists(id))
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

        // POST: api/tNm_BeneficiosCCQ
        [ResponseType(typeof(tNm_BeneficiosCCQ))]
        public async Task<IHttpActionResult> PosttNm_BeneficiosCCQ(tNm_BeneficiosCCQ tNm_BeneficiosCCQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNm_BeneficiosCCQ.Add(tNm_BeneficiosCCQ);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNm_BeneficiosCCQ.IdTipoBeneficio }, tNm_BeneficiosCCQ);
        }

        // DELETE: api/tNm_BeneficiosCCQ/5
        [ResponseType(typeof(tNm_BeneficiosCCQ))]
        public async Task<IHttpActionResult> DeletetNm_BeneficiosCCQ(int id)
        {
            tNm_BeneficiosCCQ tNm_BeneficiosCCQ = await db.tNm_BeneficiosCCQ.FindAsync(id);
            if (tNm_BeneficiosCCQ == null)
            {
                return NotFound();
            }

            db.tNm_BeneficiosCCQ.Remove(tNm_BeneficiosCCQ);
            await db.SaveChangesAsync();

            return Ok(tNm_BeneficiosCCQ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNm_BeneficiosCCQExists(int id)
        {
            return db.tNm_BeneficiosCCQ.Count(e => e.IdTipoBeneficio == id) > 0;
        }
    }
}