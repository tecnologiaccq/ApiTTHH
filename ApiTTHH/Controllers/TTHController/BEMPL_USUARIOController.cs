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
    public class BEMPL_USUARIOController : ApiController
    {
        private TALENTO_HUMANOEntities db = new TALENTO_HUMANOEntities();


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/registro-usuario")]
        public HttpResponseMessage PostRegistroBEMPL(BEMPL_USUARIO usuarioReg)
        {
            db.Configuration.LazyLoadingEnabled = false;
            BEMPL_USUARIO usuarioRegisterExist = db.BEMPL_USUARIO.FirstOrDefault(x => x.CorreoUsuario == usuarioReg.CorreoUsuario);
            if (usuarioRegisterExist != null) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Correo ya se encuentra registrado.");
            }
            using (var dbTransactionTTH = db.Database.BeginTransaction())
            {
                try
                {
                    BEMPL_DATOSPOSTULANTE postulante = new BEMPL_DATOSPOSTULANTE();

                    usuarioReg.Estado = true;
                    usuarioReg.CorreoUsuario = usuarioReg.CorreoUsuario.ToLower();
                    db.BEMPL_USUARIO.Add(usuarioReg);
                    db.SaveChanges();
                    postulante.IdUsuario = usuarioReg.IdUsuario;
                    postulante.Nombres = usuarioReg.Nombres.ToUpper();
                    postulante.Apellidos = usuarioReg.Apellidos.ToUpper();
                    postulante.Correo = usuarioReg.CorreoUsuario.ToLower();
                    db.BEMPL_DATOSPOSTULANTE.Add(postulante);
                    db.SaveChanges();
                    dbTransactionTTH.Commit();
              
                }
                catch (Exception ex)
                {
                    dbTransactionTTH.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
            //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/change-password")]
        public HttpResponseMessage PostChangePassword(BEMPL_USUARIO usuarioReg)
        {
            db.Configuration.LazyLoadingEnabled = false;
            BEMPL_USUARIO usuarioRegisterExist = db.BEMPL_USUARIO.FirstOrDefault(x => x.IdUsuario == usuarioReg.IdUsuario);
            if (usuarioRegisterExist.IsRecuperaPassword == false || usuarioRegisterExist.IsRecuperaPassword == null) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Link de cambio de contraseña no se encuentra disponible, vuelva a la página de resetear");
            }
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    usuarioRegisterExist.IsRecuperaPassword = false;
                    usuarioRegisterExist.Password = usuarioReg.Password;
                    db.SaveChanges();
                    dbTransaction.Commit();

                }

                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error intente más tarde");
                }
            }
            //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/login-bemple")]
        public HttpResponseMessage PostLogin(BEMPL_USUARIO usuarioReg)
        {
            db.Configuration.LazyLoadingEnabled = false;
            BEMPL_USUARIO usuarioRegisterExist = db.BEMPL_USUARIO.FirstOrDefault(x => x.CorreoUsuario == usuarioReg.CorreoUsuario);
            if (usuarioRegisterExist == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Correo no se encuentra registrado.");
            }
            if (usuarioRegisterExist.Password == usuarioReg.Password)
            {
                return Request.CreateResponse(HttpStatusCode.OK,usuarioRegisterExist);
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contraseña incorrecta.");
            }
            //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
            
        }
        // GET: api/BEMPL_USUARIO
        public IQueryable<BEMPL_USUARIO> GetBEMPL_USUARIO()
        {
            return db.BEMPL_USUARIO;
        }

        // GET: api/BEMPL_USUARIO/5
        [ResponseType(typeof(BEMPL_USUARIO))]
        public async Task<IHttpActionResult> GetBEMPL_USUARIO(int id)
        {
            BEMPL_USUARIO bEMPL_USUARIO = await db.BEMPL_USUARIO.FindAsync(id);
            if (bEMPL_USUARIO == null)
            {
                return NotFound();
            }

            return Ok(bEMPL_USUARIO);
        }

        // PUT: api/BEMPL_USUARIO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBEMPL_USUARIO(int id, BEMPL_USUARIO bEMPL_USUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bEMPL_USUARIO.IdUsuario)
            {
                return BadRequest();
            }

            db.Entry(bEMPL_USUARIO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BEMPL_USUARIOExists(id))
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

        // POST: api/BEMPL_USUARIO
        [ResponseType(typeof(BEMPL_USUARIO))]
        public async Task<IHttpActionResult> PostBEMPL_USUARIO(BEMPL_USUARIO bEMPL_USUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BEMPL_USUARIO.Add(bEMPL_USUARIO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bEMPL_USUARIO.IdUsuario }, bEMPL_USUARIO);
        }

        // DELETE: api/BEMPL_USUARIO/5
        [ResponseType(typeof(BEMPL_USUARIO))]
        public async Task<IHttpActionResult> DeleteBEMPL_USUARIO(int id)
        {
            BEMPL_USUARIO bEMPL_USUARIO = await db.BEMPL_USUARIO.FindAsync(id);
            if (bEMPL_USUARIO == null)
            {
                return NotFound();
            }

            db.BEMPL_USUARIO.Remove(bEMPL_USUARIO);
            await db.SaveChangesAsync();

            return Ok(bEMPL_USUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BEMPL_USUARIOExists(int id)
        {
            return db.BEMPL_USUARIO.Count(e => e.IdUsuario == id) > 0;
        }
    }
}