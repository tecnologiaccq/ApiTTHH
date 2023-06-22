using ApiTTHH.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTTHH.Business.Interface
{
    public interface ILoginBusiness
    {
        Task<bool> VerifyUserSqlConfiguredAsync(UsuarioModel model);
    }
}
