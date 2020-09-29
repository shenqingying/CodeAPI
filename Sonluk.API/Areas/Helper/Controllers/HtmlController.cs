using Sonluk.API.Models;
using Sonluk.Entities.API;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class HtmlController : ApiController
    {
        MESModels mesmodel = new MESModels();

        [HttpGet]
        public ApiReturn ReadTag(string input, string tag)
        {
            return new ApiReturn<string>(mesmodel.MES_Tools.GetHtmlTag(input, tag, "url"), true);
        }

        [HttpPost]
        public ApiReturn ReadTag([FromBody] dynamic inputStr)
        {
            return new ApiReturn<string>(mesmodel.MES_Tools.GetHtmlTag(inputStr.input.ToString(), inputStr.tag.ToString(), inputStr.type.ToString()), true);
        }
    }
}
