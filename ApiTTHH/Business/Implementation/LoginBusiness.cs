using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiTTHH.Business.Interface;
using ApiTTHH.Models;
using ApiTTHH.Models.Custom;
using Ccq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

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
                var config = await _db.Adm_GeneralConfig
                    .Where(c => c.IdCatConfigKey == (int)Enums.ConfigKey.Remoteservername && c.Activo == true)
                    .FirstOrDefaultAsync();
                        
                var result = VerifyUserSqlConfigured(model, config.Valor);

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
        private bool VerifyUserSqlConfigured(UsuarioModel model, string remoteServerName)
        {
            var dataConnection = new ServerConnection(remoteServerName)
            {
                LoginSecure = false,
                Login = model.usuario,
                Password = model.password
            };

            var srvConnection = new Server(dataConnection);

            return srvConnection.Status == ServerStatus.Online;
        }
    }
}