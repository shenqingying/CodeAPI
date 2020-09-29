using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.API;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class LoginController : ApiController
    {
        [HttpGet]
        public ApiReturn ReadToken(string ptoken = "")
        {
            return new ApiReturn<FullTokenInfo>(new RMSModels().CRM_Login.ReadFullToken(ptoken), true);
        }

        [HttpGet]
        public ApiReturn ReadMenu(string ptoken = "")
        {
            return new ApiReturn<FullTokenInfo>(new RMSModels().CRM_Login.ReadFullToken(ptoken), true);
        }

        [AllowAnonymous]
        [HttpGet]
        public ApiReturn Valid(string ptoken = "")
        {
            return new ApiReturn<bool>(ApiReceive.GetResult(ptoken), true);
        }
    }
}
