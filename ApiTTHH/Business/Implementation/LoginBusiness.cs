using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApiTTHH.Business.Interface;
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

        public async Task<bool> VerifyUserSqlConfiguredAsync(UsuarioModel model)
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

                return result;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: ", e);

                return false;
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