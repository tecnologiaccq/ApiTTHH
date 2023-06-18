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
    public class tGN_EmpresasController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();

        // GET: api/tGN_Empresas
        public IQueryable<tGN_Empresas> GettGN_Empresas()
        {
            return db.tGN_Empresas;
        }

        // GET: api/tGN_Empresas/5
        [ResponseType(typeof(tGN_Empresas))]
        public async Task<IHttpActionResult> GettGN_Empresas(int id)
        {
            tGN_Empresas tGN_Empresas = await db.tGN_Empresas.FindAsync(id);
            if (tGN_Empresas == null)
            {
                return NotFound();
            }

            return Ok(tGN_Empresas);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/empresas")]
        public HttpResponseMessage GetEmpresas()
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {

                var empresas = (from empresa in db.tGN_Empresas

                                  
                                  select new
                                  {
                                      name = empresa.Descripcion,
                                      code = empresa.IdEmpresa
                                  }
                          ).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, empresas.OrderBy(x => x.code));
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // PUT: api/tGN_Empresas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttGN_Empresas(int id, tGN_Empresas tGN_Empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tGN_Empresas.IdEmpresa)
            {
                return BadRequest();
            }

            db.Entry(tGN_Empresas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tGN_EmpresasExists(id))
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

        // POST: api/tGN_Empresas
        [ResponseType(typeof(tGN_Empresas))]
        public async Task<IHttpActionResult> PosttGN_Empresas(tGN_Empresas tGN_Empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tGN_Empresas.Add(tGN_Empresas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tGN_Empresas.IdEmpresa }, tGN_Empresas);
        }

        // DELETE: api/tGN_Empresas/5
        [ResponseType(typeof(tGN_Empresas))]
        public async Task<IHttpActionResult> DeletetGN_Empresas(int id)
        {
            tGN_Empresas tGN_Empresas = await db.tGN_Empresas.FindAsync(id);
            if (tGN_Empresas == null)
            {
                return NotFound();
            }

            db.tGN_Empresas.Remove(tGN_Empresas);
            await db.SaveChangesAsync();

            return Ok(tGN_Empresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tGN_EmpresasExists(int id)
        {
            return db.tGN_Empresas.Count(e => e.IdEmpresa == id) > 0;
        }
    }
}