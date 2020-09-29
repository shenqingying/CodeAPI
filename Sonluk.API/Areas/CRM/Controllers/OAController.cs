using Newtonsoft.Json;
using Sonluk.API.Models;
using Sonluk.Entities.API;
using System.Collections.Generic;
using System.Web.Http;

namespace Sonluk.API.Areas.CRM.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class OAController : ApiController
    {
        RMSModels models = new RMSModels();

        [HttpGet]
        public ApiReturn CreateFlow(string ptoken, string code, string id)
        {
            return models.CRM_OA.LaunchByID(ApiReceive.GetStaffID(ptoken), code, id);
        }

        [HttpPost]
        public ApiReturn CreateFlows(string ptoken, string code, [FromBody]List<string> ids)
        {
            return models.CRM_OA.LaunchByIDs(ApiReceive.GetStaffID(ptoken), code, ids);
        }

        [HttpPost]
        public ApiReturn CreateFlow(string ptoken, string code, [FromBody]dynamic data)
        {
            return models.CRM_OA.Launch(ApiReceive.GetStaffID(ptoken), code, JsonConvert.DeserializeObject<Dictionary<string, object>>(data.data), (long[])data.att);
        }

        [HttpGet]
        public ApiReturn ReadTemplate(string ptoken, string code)
        {
            return models.CRM_OA.ReadTemplate(code);
        }
    }
}
