using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Windows.Forms;
using ApiTTHH.Business;
using ApiTTHH.ModelClass;
using ApiTTHH.Models;
using ApiTTHH.Models.Custom;

namespace ApiTTHH.Controllers.EstadosCuenta
{
    public class tNM_EstadosCuentaColaboradorController : ApiController
    {
        private CCQ_DESAEntities db = new CCQ_DESAEntities();
        private PagosWebEntities dbPago = new PagosWebEntities();

        private readonly LoginBusiness _loginBusiness;

        public tNM_EstadosCuentaColaboradorController()
        {
            _loginBusiness = new LoginBusiness();
        }

        // GET: api/tNM_EstadosCuentaColaborador
        public IQueryable<tNM_EstadosCuentaColaborador> GettNM_EstadosCuentaColaborador()
        {
            return db.tNM_EstadosCuentaColaborador;
        }

        // GET: api/tNM_EstadosCuentaColaborador/5
        [ResponseType(typeof(tNM_EstadosCuentaColaborador))]
        public async Task<IHttpActionResult> GettNM_EstadosCuentaColaborador(int id)
        {
            tNM_EstadosCuentaColaborador tNM_EstadosCuentaColaborador = await db.tNM_EstadosCuentaColaborador.FindAsync(id);
            if (tNM_EstadosCuentaColaborador == null)
            {
                return NotFound();
            }

            return Ok(tNM_EstadosCuentaColaborador);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/estado-cuenta/{usuario}")]
        public HttpResponseMessage GetEstadocuentaUsuario(string usuario)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                var infoColaborador = db.Get_Colaborador_Inactivo_Con_Saldo(usuario).Select(r => new ColaboradorResultModel
                {
                    ResideEnElExterior = r.ResideEnElExterior,
                    ApellidosNombres = r.ApellidosNombres,
                    ApruebaTH = r.ApruebaTH,
                    CodigoEstablecimiento = r.CodigoEstablecimiento,
                    CondicionDiscapacidad = r.CondicionDiscapacidad,
                    CreadoPor = r.CreadoPor,
                    Email = r.eMail,
                    EnviarCorreoRolPago = r.EnviarCorreoRolPago,
                    EsFinanciero = r.EsFinanciero,
                    EsNominista = r.EsNominista,
                    EsReelegible = r.EsReelegible,
                    EsSupervisor = r.EsSupervisor,
                    EstacionCreacion = r.EstacionCreacion,
                    EstacionModificacion = r.EstacionModificacion,
                    FechaCreacion = r.FechaCreacion,
                    FechaDefuncion = r.FechaDefuncion,
                    FechaEgreso = r.FechaEgreso,
                    FechaIngreso = r.FechaIngreso,
                    FechaJubilacion = r.FechaJubilacion,
                    HoraEntrada = r.HoraEntrada,
                    HoraSalida = r.HoraSalida,
                    HorasSemanalesJornadaParcial = r.HorasSemanalesJornadaParcial,
                    IdArea = r.IdArea,
                    IdBanco = r.IdBanco,
                    IdBiometrico = r.IdBiometrico,
                    IdCargo = r.IdCargo,
                    IdCategoria1 = r.IdCategoria1,
                    IdCategoria2 = r.IdCategoria2,
                    IdCategoria3 = r.IdCategoria3,
                    IdCategoria4 = r.IdCategoria4,
                    IdCategoria5 = r.IdCategoria5,
                    IdCategoriaColaborador = r.IdCategoriaColaborador,
                    IdCategoriaOcupacional = r.IdCategoriaOcupacional,
                    IdClaseColaborador = r.IdClaseColaborador,
                    IdColaborador = r.IdColaborador,
                    IdDepartamento = r.IdDepartamento,
                    IdDiscapacitado = r.IdDiscapacitado,
                    IdEstado = r.IdEstado,
                    IdGrupoColaborador = r.IdGrupoColaborador,
                    IdMedioPago = r.IdMedioPago,
                    IdMotivoEgreso = r.IdMotivoEgreso,
                    IdPersona = r.IdPersona,
                    IdProgramaColaborador = r.IdProgramaColaborador,
                    IdSectorialIESS = r.IdSectorialIESS,
                    IdSucursal = r.IdSucursal,
                    IdSupervisor = r.IdSupervisor,
                    IdTipoContrato = r.IdTipoContrato,
                    IdTipoCuenta = r.IdTipoCuenta,
                    IdTipoDiscapacidad = r.IdTipoDiscapacidad,
                    IdTipoRelacion = r.IdTipoRelacion,
                    IdTipoSangre = r.IdTipoSangre,
                    IdTitulo = r.IdTitulo,
                    IdTurno = r.IdTurno,
                    Identificacion = r.Identificacion,
                    ModificadoPor = r.ModificadoPor,
                    Nickname = r.nickname,
                    NumeroCuenta = r.NumeroCuenta,
                    NumeroDiscapacitado = r.NumeroDiscapacitado,
                    PorcentajeDiscapacidad = r.PorcentajeDiscapacidad,
                    TiempoAlmuerzo = r.TiempoAlmuerzo,
                    TieneBeneficioGalapagos = r.TieneBeneficioGalapagos,
                    TieneConvenioDobleImposicion = r.TieneConvenioDobleImposicion,
                    TieneSalarioNeto = r.TieneSalarioNeto,
                    TipoIdDiscapacitado = r.TipoIdDiscapacitado,
                    UltimaModificacion = r.UltimaModificacion,
                    UrlFoto = r.UrlFoto,
                    Usuario = r.Usuario,
                    idTipoColaborador = r.IdTipoColaborador
                }).FirstOrDefault();

                if (infoColaborador == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Datos de colaborador no encontrados");
                }

                if (infoColaborador.IdEstado == 20)
                {
                    var saldos = db.tNM_SaldosCuentaColaborador.Where(x => x.IdColaborador == infoColaborador.IdColaborador).FirstOrDefault();

                    if (saldos != null)
                    {
                        var persona = db.tGN_Personas.Where(x => x.IdPersonas == infoColaborador.IdPersona).FirstOrDefault();
                        var ingreso = db.tNM_IngresosBeneficiosColaborador.Where(x => x.IdColaborador == infoColaborador.IdColaborador && x.idTipoBeneficio == 1).FirstOrDefault();

                        var resultEstadoCuentaColaborador =
                            db.Get_EstadoCuenta_Colaborador(infoColaborador.IdColaborador, infoColaborador.IdEstado,
                                saldos.SaldoCupo, saldos.SaldoGiftCard, ingreso.Plazo).Select(r => new EstadoCuentaColaboradorResultModel
                            {
                                DescripcionEstado = r.descripcionEstado,
                                Fecha = r.fecha,
                                IdColaborador = r.idColaborador,
                                SaldoCupo = r.saldoCupo,
                                IdReferencia = r.idReferencia,
                                IdTipoBeneficio = r.idTipoBeneficio,
                                IdTipoEstadpCuenta = r.idTipoEstadpCuenta,
                                MesesDiferir = r.mesesDiferir,
                                SaldoGifcard = r.saldoGifcard,
                                TipoBeneficio = r.tipoBeneficio,
                                Total = r.total,
                                Valor = r.valor
                            }).ToList();
                        
                        return Request.CreateResponse(HttpStatusCode.OK, resultEstadoCuentaColaborador.OrderByDescending(x => x.Fecha));
                    }

                    var result = $"Colaborador no dispone de saldo para consumo.";

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    var saldos = db.tNM_SaldosCuentaColaborador.Where(x => x.IdColaborador == infoColaborador.IdColaborador).FirstOrDefault();

                    if (saldos != null)
                    {
                        var persona = db.tGN_Personas.Where(x => x.IdPersonas == infoColaborador.IdPersona).FirstOrDefault();
                        var ingreso = db.tNM_IngresosBeneficiosColaborador.Where(x => x.IdColaborador == infoColaborador.IdColaborador && x.idTipoBeneficio == 1).FirstOrDefault();

                        var resultEstadoCuentaColaborador =
                            db.Get_EstadoCuenta_Colaborador(infoColaborador.IdColaborador, infoColaborador.IdEstado,
                                saldos.SaldoCupo, saldos.SaldoGiftCard, ingreso.Plazo).Select(r => new EstadoCuentaColaboradorResultModel
                            {
                                DescripcionEstado = r.descripcionEstado,
                                Fecha = r.fecha,
                                IdColaborador = r.idColaborador,
                                SaldoCupo = Convert.ToDecimal(r.saldoCupo),
                                IdReferencia = r.idReferencia,
                                IdTipoBeneficio = r.idTipoBeneficio,
                                IdTipoEstadpCuenta = r.idTipoEstadpCuenta,
                                MesesDiferir = r.mesesDiferir,
                                SaldoGifcard = r.saldoGifcard,
                                TipoBeneficio = r.tipoBeneficio,
                                Total = r.total,
                                Valor = r.valor
                            }).ToList();

                        return Request.CreateResponse(HttpStatusCode.OK, resultEstadoCuentaColaborador.OrderByDescending(x => x.Fecha));


                    }

                    var result = $"Colaborador no dispone de saldo para consumo.";

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                
               
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/login")]
        public async Task<HttpResponseMessage> PostLogin(UsuarioModel usuario)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            try
            {
                var result = await _loginBusiness.VerifyUserSqlConfiguredAsync(usuario);

                if (result != null)
                {
                    //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Usuario no existe");
                }
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
        }
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        //[HttpPost]
        //[Route("api/reg-token")]
        //public HttpResponseMessage PostREgToken(var Token)
        //{
        //    db.Configuration.LazyLoadingEnabled = false;

        //    //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
        //    try
        //    {
        //        string cadenaConexion = ConfigurationManager.ConnectionStrings["CCQ_DESAEntities"].ConnectionString;
        //        EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder(cadenaConexion);
        //        String connString = @"data source=" + db.Database.Connection.DataSource + ";initial catalog=" + db.Database.Connection.Database + ";user id=" + usuario.usuario + ";password=" + usuario.password + ";MultipleActiveResultSets=True;App=EntityFramework;";
        //        EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
        //        esb.Metadata = "res://*/Models.ERPTTHH.csdl|res://*/Models.ERPTTHH.ssdl|res://*/Models.ERPTTHH.msl";
        //        esb.Provider = "System.Data.SqlClient";
        //        esb.ProviderConnectionString = connString;
        //        db = new CCQ_DESAEntities(esb.ToString());
        //        db.Configuration.LazyLoadingEnabled = false;
        //        tNM_Colaboradores empleado = db.tNM_Colaboradores.FirstOrDefault(x => x.Usuario == usuario.usuario && x.IdEstado==1);
        //        //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
        //        return Request.CreateResponse(HttpStatusCode.OK, empleado);
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = string.Format(ex.Message);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
        //    }
        //}

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/pagar")]
        public HttpResponseMessage PostPago(Pago pago)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == pago.idColaborador);
                    saldo.SaldoGiftCard = saldo.SaldoGiftCard - pago.gifCard;
                    saldo.SaldoCupo = saldo.SaldoCupo - pago.cupo;
                    tNM_EstadosCuentaColaborador estadoCuentaColaboradorGift = new tNM_EstadosCuentaColaborador();
                    tNM_EstadosCuentaColaborador estadoCuentaColaboradorCupo = new tNM_EstadosCuentaColaborador();
                    if (pago.gifCard > 0)
                    {
                        estadoCuentaColaboradorGift.IdColaborador = pago.idColaborador;
                        estadoCuentaColaboradorGift.IdReferencia = pago.idCobro;
                        estadoCuentaColaboradorGift.IdTipoBeneficio = 2;
                        estadoCuentaColaboradorGift.Valor = pago.gifCard;
                        estadoCuentaColaboradorGift.Descripcion = "CompraTodo";
                        estadoCuentaColaboradorGift.IdTipoEstadoCuenta = 2;
                        db.tNM_EstadosCuentaColaborador.Add(estadoCuentaColaboradorGift);
                    }
                    if (pago.cupo > 0)
                    {
                        estadoCuentaColaboradorCupo.IdColaborador = pago.idColaborador;
                        estadoCuentaColaboradorCupo.IdReferencia = pago.idCobro;
                        estadoCuentaColaboradorCupo.IdTipoBeneficio = 1;
                        estadoCuentaColaboradorCupo.Valor = pago.cupo;
                        estadoCuentaColaboradorCupo.IdTipoEstadoCuenta = 2;
                        estadoCuentaColaboradorCupo.Descripcion = "CompraTodo";
                        db.tNM_EstadosCuentaColaborador.Add(estadoCuentaColaboradorCupo);
                    }
                    tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.IdColaborador == pago.idColaborador);
                    tNM_ConceptosFijos colaboradorConcepto = new tNM_ConceptosFijos();
                    colaboradorConcepto.IdColaborador = colaborador.IdColaborador;
                    colaboradorConcepto.Saldo = pago.cupo;
                    colaboradorConcepto.Valor = pago.cuota;
                    colaboradorConcepto.Activo = true;
                    colaboradorConcepto.NumeroCuotas = pago.mesesPlazo;
                    colaboradorConcepto.CuotasPagadas = 0;
                    if (colaborador.IdEmpresa == 1)
                        colaboradorConcepto.IdConcepto = 99;
                    if (colaborador.IdEmpresa == 2)
                        colaboradorConcepto.IdConcepto = 124;
                    db.tNM_ConceptosFijos.Add(colaboradorConcepto);
                    using (var dbTransactionPago = dbPago.Database.BeginTransaction())
                    {
                        try
                        {
                            PA_Cobro cobro = dbPago.PA_Cobro.FirstOrDefault(x => x.IdCobro == pago.idCobro);
                            cobro.IdEstado = 4;
                            cobro.valorCupoUsado = pago.cupo;
                            cobro.valorGiftCardUsado = pago.gifCard;
                            cobro.idColaborador = pago.idColaborador;
                            cobro.idEmpresa = colaborador.IdEmpresa;
                            db.SaveChanges();
                            dbPago.SaveChanges();
                            dbTransactionPago.Commit();
                            dbTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbTransactionPago.Rollback();
                            dbTransaction.Rollback();
                            var message = string.Format(ex.Message);
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                        }
                    }
                    //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    var message = string.Format(ex.Message);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/cupo-masivo")]
        public HttpResponseMessage PostIngresoMasivo(List<Cupo> cupos)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);

            try
            {

                using (var dbTransactionPago = db.Database.BeginTransaction())
                {

                    try
                    {
                        foreach (Cupo cupo in cupos)
                        {
                            tNM_IngresosBeneficiosColaborador ingresoCuota = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == 1);
                            tNM_IngresosBeneficiosColaborador ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                            if (cupo.idTipobeneficio == 2)
                            {
                                ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio && x.ActivaCumpleaños == true);
                                if (ingresoGiftCard != null)
                                {
                                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Colaborador tiene pendiente de activación tarjeta de cumpleaños.");
                                }
                            }
                            else
                            {
                                ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio);
                            }

                            decimal valorestadoing = 0;
                            tNM_SaldosCuentaColaborador saldo = new tNM_SaldosCuentaColaborador();
                            if (cupo.nuevocupo > 0)
                            {
                                if (ingresoCuota == null)
                                {
                                    ingresoCuota = new tNM_IngresosBeneficiosColaborador();
                                    ingresoCuota.IdColaborador = cupo.idColaborador;
                                    ingresoCuota.Estado = true;
                                    ingresoCuota.Descripcion = "Cupo Compratodo";
                                    ingresoCuota.ActivaCumpleaños = false;
                                    ingresoCuota.Valor = cupo.nuevocupo;
                                    ingresoCuota.Plazo = cupo.mesesPlazo;
                                    ingresoCuota.idTipoBeneficio = 1;

                                    db.tNM_IngresosBeneficiosColaborador.Add(ingresoCuota);

                                }
                                else
                                {
                                    ingresoCuota.Valor = cupo.nuevocupo;
                                    ingresoCuota.Plazo = cupo.mesesPlazo;
                                }
                                saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                                bool minus = false;
                                if (saldo == null)
                                {
                                    saldo = new tNM_SaldosCuentaColaborador();
                                    saldo.IdColaborador = cupo.idColaborador;
                                    saldo.SaldoCupo = cupo.nuevocupo;
                                    valorestadoing = cupo.nuevocupo;
                                    if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                    {
                                        saldo.SaldoGiftCard = cupo.nuevaGifTCard;
                                    }
                                    else
                                    {
                                        saldo.SaldoGiftCard = 0;
                                    }
                                    db.tNM_SaldosCuentaColaborador.Add(saldo);
                                }
                                else
                                {
                                    if (cupo.nuevocupo >= saldo.SaldoCupo)
                                    {
                                        valorestadoing = (decimal)(cupo.nuevocupo - saldo.SaldoCupo);
                                    }
                                    else
                                    {
                                        valorestadoing = (decimal)(saldo.SaldoCupo - cupo.nuevocupo);
                                        minus = true;
                                    }

                                    saldo.SaldoCupo = cupo.nuevocupo;
                                    if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                    {
                                        saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                                    }
                                }
                                if (valorestadoing > 0)
                                {
                                    tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                    estadocuenta.IdColaborador = cupo.idColaborador;
                                    estadocuenta.IdTipoBeneficio = 1;
                                    estadocuenta.IdTipoEstadoCuenta = minus == true ? 2 : 1;
                                    estadocuenta.Valor = valorestadoing;
                                    estadocuenta.Descripcion = minus == true ? "Reducción de cupo" : "Cupo compratodo";
                                    db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                                }
                            }

                            if (cupo.nuevaGifTCard > 0)
                            {

                                if (ingresoGiftCard == null)
                                {
                                    ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                    ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                    ingresoGiftCard.Estado = true;
                                    ingresoGiftCard.Descripcion = cupo.descripcion;
                                    ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                    ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                    ingresoGiftCard.Plazo = 0;
                                    ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                    db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                                }
                                else
                                {
                                    if (cupo.idTipobeneficio == 2)
                                    {
                                        ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                    }
                                    if (cupo.idTipobeneficio == 3)
                                    {
                                        ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                        ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                        ingresoGiftCard.Estado = true;
                                        ingresoGiftCard.Descripcion = cupo.descripcion;
                                        ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                        ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                        ingresoGiftCard.Plazo = 0;
                                        ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                        db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                                    }


                                }

                                saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                                if (saldo != null && cupo.activaCumple == false)
                                {
                                    saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                                }

                                if (!cupo.activaCumple)
                                {
                                    tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                    estadocuenta.IdColaborador = cupo.idColaborador;
                                    estadocuenta.IdTipoBeneficio = cupo.idTipobeneficio;
                                    estadocuenta.IdTipoEstadoCuenta = 1;
                                    estadocuenta.Valor = cupo.nuevaGifTCard;
                                    estadocuenta.Descripcion = cupo.descripcion;
                                    db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                                }

                            }
                            db.SaveChanges();
                        }
                        
                        dbTransactionPago.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransactionPago.Rollback();

                        var message = string.Format(ex.Message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                }

                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/cupo")]
        public HttpResponseMessage PostIngreso(Cupo cupo)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);

            try
            {
                tNM_IngresosBeneficiosColaborador ingresoCuota = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == 1);
                tNM_IngresosBeneficiosColaborador ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                if (cupo.idTipobeneficio == 2)
                {
                    ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio && x.ActivaCumpleaños == true);
                    if (ingresoGiftCard != null && cupo.nuevaGifTCard>0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Colaborador tiene pendiente de activación tarjeta de cumpleaños.");
                    }
                }
                else
                {
                    ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio);
                }

                decimal valorestadoing = 0;
                tNM_SaldosCuentaColaborador saldo = new tNM_SaldosCuentaColaborador();
                using (var dbTransactionPago = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (cupo.nuevocupo > 0)
                        {
                            if (ingresoCuota == null)
                            {
                                ingresoCuota = new tNM_IngresosBeneficiosColaborador();
                                ingresoCuota.IdColaborador = cupo.idColaborador;
                                ingresoCuota.Estado = true;
                                ingresoCuota.Descripcion = "Cupo Compratodo";
                                ingresoCuota.ActivaCumpleaños = false;
                                ingresoCuota.Valor = cupo.nuevocupo;
                                ingresoCuota.Plazo = cupo.mesesPlazo;
                                ingresoCuota.idTipoBeneficio = 1;

                                db.tNM_IngresosBeneficiosColaborador.Add(ingresoCuota);

                            }
                            else
                            {
                                ingresoCuota.Valor = cupo.nuevocupo;
                                ingresoCuota.Plazo = cupo.mesesPlazo;
                            }
                            saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                            bool minus = false;
                            if (saldo == null)
                            {
                                saldo = new tNM_SaldosCuentaColaborador();
                                saldo.IdColaborador = cupo.idColaborador;
                                saldo.SaldoCupo = cupo.nuevocupo;
                                valorestadoing = cupo.nuevocupo;
                                if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                {
                                    saldo.SaldoGiftCard = cupo.nuevaGifTCard;
                                }
                                else
                                {
                                    saldo.SaldoGiftCard = 0;
                                }
                                db.tNM_SaldosCuentaColaborador.Add(saldo);
                            }
                            else
                            {
                                if (cupo.nuevocupo >= saldo.SaldoCupo)
                                {
                                    valorestadoing = (decimal)(cupo.nuevocupo - saldo.SaldoCupo);
                                    //if (valorestadoing == 0) {
                                    //    valorestadoing = cupo.nuevocupo;
                                    //}
                                }
                                else
                                {
                                    valorestadoing = (decimal)(saldo.SaldoCupo - cupo.nuevocupo);
                                    minus = true;
                                }

                                saldo.SaldoCupo = cupo.nuevocupo;
                                if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                {
                                    saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                                }
                            }
                            if (valorestadoing > 0) {
                                tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                estadocuenta.IdColaborador = cupo.idColaborador;
                                estadocuenta.IdTipoBeneficio = 1;
                                estadocuenta.IdTipoEstadoCuenta = minus == true ? 2 : 1;
                                estadocuenta.Valor = valorestadoing;
                                estadocuenta.Descripcion = minus == true ? "Reducción de cupo" : "Cupo compratodo";
                                db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                            }
                      
                        }

                        if (cupo.nuevaGifTCard > 0)
                        {

                            if (ingresoGiftCard == null)
                            {
                                ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                ingresoGiftCard.Estado = true;
                                ingresoGiftCard.Descripcion = cupo.descripcion;
                                ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                ingresoGiftCard.Plazo = 0;
                                ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                            }
                            else
                            {
                                if (cupo.idTipobeneficio == 2)
                                {
                                    ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                }
                                if (cupo.idTipobeneficio == 3)
                                {
                                    ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                    ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                    ingresoGiftCard.Estado = true;
                                    ingresoGiftCard.Descripcion = cupo.descripcion;
                                    ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                    ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                    ingresoGiftCard.Plazo = 0;
                                    ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                    db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                                }


                            }

                            saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                            if (saldo != null && cupo.activaCumple == false && cupo.nuevocupo==0)
                            {
                                saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                            }

                            if (!cupo.activaCumple)
                            {
                                tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                estadocuenta.IdColaborador = cupo.idColaborador;
                                estadocuenta.IdTipoBeneficio = cupo.idTipobeneficio;
                                estadocuenta.IdTipoEstadoCuenta = 1;
                                estadocuenta.Valor = cupo.nuevaGifTCard;
                                estadocuenta.Descripcion = cupo.descripcion;
                                db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                            }

                        }

                        db.SaveChanges();
                        dbTransactionPago.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransactionPago.Rollback();

                        var message = string.Format(ex.Message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

        }
        // PUT: api/tNM_EstadosCuentaColaborador/5

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/cupo-gifts")]
        public HttpResponseMessage PostIngresoGiftMasivo(List<Cupo> cupos)
        {
            db.Configuration.LazyLoadingEnabled = false;

            //tNM_Colaboradores colaborador = db.tNM_Colaboradores.Single(x => x.Usuario == usuario);

            try
            {
         
                using (var dbTransactionPago = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (Cupo cupo in cupos)
                        {
                            tNM_IngresosBeneficiosColaborador ingresoCuota = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == 1);
                            tNM_IngresosBeneficiosColaborador ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                            if (cupo.idTipobeneficio == 2)
                            {
                                ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio && x.ActivaCumpleaños == true);
                                if (ingresoGiftCard != null)
                                {
                                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Colaborador tiene pendiente de activación tarjeta de cumpleaños.");
                                }
                            }
                            else
                            {
                                ingresoGiftCard = db.tNM_IngresosBeneficiosColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador && x.idTipoBeneficio == cupo.idTipobeneficio);
                            }

                            decimal valorestadoing = 0;
                            tNM_SaldosCuentaColaborador saldo = new tNM_SaldosCuentaColaborador();
                            if (cupo.nuevocupo > 0)
                            {
                                if (ingresoCuota == null)
                                {
                                    ingresoCuota = new tNM_IngresosBeneficiosColaborador();
                                    ingresoCuota.IdColaborador = cupo.idColaborador;
                                    ingresoCuota.Estado = true;
                                    ingresoCuota.Descripcion = "Cupo Compratodo";
                                    ingresoCuota.ActivaCumpleaños = false;
                                    ingresoCuota.Valor = cupo.nuevocupo;
                                    ingresoCuota.Plazo = cupo.mesesPlazo;
                                    ingresoCuota.idTipoBeneficio = 1;

                                    db.tNM_IngresosBeneficiosColaborador.Add(ingresoCuota);

                                }
                                else
                                {
                                    ingresoCuota.Valor = cupo.nuevocupo;
                                    ingresoCuota.Plazo = cupo.mesesPlazo;
                                }
                                saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                                bool minus = false;
                                if (saldo == null)
                                {
                                    saldo = new tNM_SaldosCuentaColaborador();
                                    saldo.IdColaborador = cupo.idColaborador;
                                    saldo.SaldoCupo = cupo.nuevocupo;
                                    valorestadoing = cupo.nuevocupo;
                                    if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                    {
                                        saldo.SaldoGiftCard = cupo.nuevaGifTCard;
                                    }
                                    else
                                    {
                                        saldo.SaldoGiftCard = 0;
                                    }
                                    db.tNM_SaldosCuentaColaborador.Add(saldo);
                                }
                                else
                                {
                                    if (cupo.nuevocupo >= saldo.SaldoCupo)
                                    {
                                        valorestadoing = (decimal)(cupo.nuevocupo - saldo.SaldoCupo);
                                    }
                                    else
                                    {
                                        valorestadoing = (decimal)(saldo.SaldoCupo - cupo.nuevocupo);
                                        minus = true;
                                    }

                                    saldo.SaldoCupo = cupo.nuevocupo;
                                    if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                    {
                                        saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                                    }
                                }
                                tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                estadocuenta.IdColaborador = cupo.idColaborador;
                                estadocuenta.IdTipoBeneficio = 1;
                                estadocuenta.IdTipoEstadoCuenta = minus == true ? 2 : 1;
                                estadocuenta.Valor = valorestadoing;
                                estadocuenta.Descripcion = minus == true ? "Reducción de cupo" : "Cupo compratodo";
                                db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                            }

                            if (cupo.nuevaGifTCard > 0)
                            {

                                if (ingresoGiftCard == null)
                                {
                                    ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                    ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                    ingresoGiftCard.Estado = true;
                                    ingresoGiftCard.Descripcion = cupo.descripcion;
                                    ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                    ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                    ingresoGiftCard.Plazo = 0;
                                    ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                    db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                                }
                                else
                                {
                                    if (cupo.idTipobeneficio == 2)
                                    {
                                        ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                    }
                                    if (cupo.idTipobeneficio == 3)
                                    {
                                        ingresoGiftCard = new tNM_IngresosBeneficiosColaborador();
                                        ingresoGiftCard.IdColaborador = cupo.idColaborador;
                                        ingresoGiftCard.Estado = true;
                                        ingresoGiftCard.Descripcion = cupo.descripcion;
                                        ingresoGiftCard.ActivaCumpleaños = cupo.activaCumple;
                                        ingresoGiftCard.Valor = cupo.nuevaGifTCard;
                                        ingresoGiftCard.Plazo = 0;
                                        ingresoGiftCard.idTipoBeneficio = cupo.idTipobeneficio;
                                        db.tNM_IngresosBeneficiosColaborador.Add(ingresoGiftCard);
                                    }


                                }

                                saldo = db.tNM_SaldosCuentaColaborador.FirstOrDefault(x => x.IdColaborador == cupo.idColaborador);
                                if (saldo == null)
                                {
                                    saldo = new tNM_SaldosCuentaColaborador();
                                    saldo.IdColaborador = cupo.idColaborador;
                                    saldo.SaldoCupo = cupo.nuevocupo;

                                    if (cupo.nuevaGifTCard > 0 && cupo.activaCumple == false)
                                    {
                                        saldo.SaldoGiftCard = cupo.nuevaGifTCard;
                                    }
                                    else
                                    {
                                        saldo.SaldoGiftCard = cupo.nuevaGifTCard;
                                    }
                                    db.tNM_SaldosCuentaColaborador.Add(saldo);
                                }
                                if (saldo != null && cupo.activaCumple == false)
                                {
                                    saldo.SaldoGiftCard = saldo.SaldoGiftCard + cupo.nuevaGifTCard;
                                }

                                if (!cupo.activaCumple)
                                {
                                    tNM_EstadosCuentaColaborador estadocuenta = new tNM_EstadosCuentaColaborador();
                                    estadocuenta.IdColaborador = cupo.idColaborador;
                                    estadocuenta.IdTipoBeneficio = cupo.idTipobeneficio;
                                    estadocuenta.IdTipoEstadoCuenta = 1;
                                    estadocuenta.Valor = cupo.nuevaGifTCard;
                                    estadocuenta.Descripcion = cupo.descripcion;
                                    db.tNM_EstadosCuentaColaborador.Add(estadocuenta);
                                }

                            }

                            db.SaveChanges();
                           
                        }
                        dbTransactionPago.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransactionPago.Rollback();

                        var message = string.Format(ex.Message);
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                    }
                }
                //EntityConnection entityConn = DBConnectionHelper.BuildConnection();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                var message = string.Format(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

        }
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PuttNM_EstadosCuentaColaborador(int id, tNM_EstadosCuentaColaborador tNM_EstadosCuentaColaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tNM_EstadosCuentaColaborador.IdEstadoCuenta)
            {
                return BadRequest();
            }

            db.Entry(tNM_EstadosCuentaColaborador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tNM_EstadosCuentaColaboradorExists(id))
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

        // POST: api/tNM_EstadosCuentaColaborador
        [ResponseType(typeof(tNM_EstadosCuentaColaborador))]
        public async Task<IHttpActionResult> PosttNM_EstadosCuentaColaborador(tNM_EstadosCuentaColaborador tNM_EstadosCuentaColaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tNM_EstadosCuentaColaborador.Add(tNM_EstadosCuentaColaborador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tNM_EstadosCuentaColaborador.IdEstadoCuenta }, tNM_EstadosCuentaColaborador);
        }

        // DELETE: api/tNM_EstadosCuentaColaborador/5
        [ResponseType(typeof(tNM_EstadosCuentaColaborador))]
        public async Task<IHttpActionResult> DeletetNM_EstadosCuentaColaborador(int id)
        {
            tNM_EstadosCuentaColaborador tNM_EstadosCuentaColaborador = await db.tNM_EstadosCuentaColaborador.FindAsync(id);
            if (tNM_EstadosCuentaColaborador == null)
            {
                return NotFound();
            }

            db.tNM_EstadosCuentaColaborador.Remove(tNM_EstadosCuentaColaborador);
            await db.SaveChangesAsync();

            return Ok(tNM_EstadosCuentaColaborador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tNM_EstadosCuentaColaboradorExists(int id)
        {
            return db.tNM_EstadosCuentaColaborador.Count(e => e.IdEstadoCuenta == id) > 0;
        }
    }
}