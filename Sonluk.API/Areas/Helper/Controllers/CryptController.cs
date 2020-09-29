using Sonluk.Entities.API;
using Sonluk.Utility.Security;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class CryptController : ApiController
    {
        [HttpPost]
        public ApiReturn Encrypt([FromBody] dynamic input)
        {
            switch ((string)input.type)
            {
                case "DES":
                    return new ApiReturn<string>(DESE.Encrypt((string)input.data, (string)input.key), true);
                default:
                    return new ApiReturn(true);
            }
        }

        [HttpPost]
        public ApiReturn Decrypt([FromBody] dynamic input)
        {
            switch ((string)input.type)
            {
                case "DES":
                    return new ApiReturn<string>(DESE.Decrypt((string)input.data, (string)input.key), true);
                default:
                    return new ApiReturn(true);
            }
        }
    }
}
