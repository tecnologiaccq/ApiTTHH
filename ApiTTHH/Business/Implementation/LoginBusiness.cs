using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApiTTHH.Business.Interface;
using ApiTTHH.ModelClass;
using ApiTTHH.Models;
using ApiTTHH.Models.Custom;
using Ccq;
using Microsoft.Data.SqlClient;

namespace ApiTTHH.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly CCQ_DESAEntities _db;

        public LoginBusiness()
        {
            _db = new CCQ_DESAEntities();
        }

        public async Task<ColaboradorResultModel> VerifyUserSqlConfiguredAsync(UsuarioModel model)
        {
            try
            {
                var configRemoteServer = await _db.Adm_GeneralConfig
                    .Where(c => c.IdCatConfigKey == (int)Enums.ConfigKey.Remoteservername && c.Activo == true)
                    .FirstOrDefaultAsync();
              
                var configInitialCatalog = await _db.Adm_GeneralConfig
                    .Where(c => c.IdCatConfigKey == (int)Enums.ConfigKey.Initialcatalogsql && c.Activo == true)
                    .FirstOrDefaultAsync();

                var result = await VerifyUserSqlConfigured(model, configRemoteServer.Valor, configInitialCatalog.Valor);

                if (result)
                {
                    var empleado = await _db.tNM_Colaboradores.Where(x => x.Usuario == model.usuario && x.IdEstado == 1).Select(r => new ColaboradorResultModel
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
                    }).FirstOrDefaultAsync();

                    if (empleado == null)
                    {
                        var infoColaborador = _db.Get_Colaborador_Inactivo_Con_Saldo(model.usuario).Select(r => new ColaboradorResultModel
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

                        return infoColaborador;
                    }

                    return empleado;
                }
                else
                {
                    return null;
                }
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: ", e);

                return null;
            }
        }


        /// <summary>
        /// Verificar si Usuario ingresado se encuentra configurado y activo.
        /// </summary>
        /// <param name="model">Modelo Request Login</param>
        /// <returns></returns>
        private async Task<bool> VerifyUserSqlConfigured(UsuarioModel model, string remoteServerName, string initialCatalog)
        {
            var cadenaConexion = await _db.Adm_GeneralConfig
                .Where(c => c.IdCatConfigKey == (int)Enums.ConfigKey.Sqlconnect && c.Activo == true)
                .FirstOrDefaultAsync();

            var conStr = string.Format(cadenaConexion.Valor, remoteServerName, initialCatalog, model.usuario, model.password);

            using (var con = new SqlConnection(conStr))
            {
                var query = "Select 1";
                var command = new SqlCommand(query, con);

                con.Open();
                command.ExecuteScalar();

                return (con.State == ConnectionState.Open);
            }
        }
    }
}