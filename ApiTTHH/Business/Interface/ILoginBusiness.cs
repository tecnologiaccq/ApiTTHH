using ApiTTHH.ModelClass;
using ApiTTHH.Models;
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
        Task<ColaboradorResultModel> VerifyUserSqlConfiguredAsync(UsuarioModel model);
    }
}
