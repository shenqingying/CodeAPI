using Sonluk.API.Models;
using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using System.Collections.Generic;
using System.Web.Http;

namespace Sonluk.API.Areas.MES.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class PMMController : ApiController
    {
        MESModels mesmodels = new MESModels();

        [HttpPost]
        public ApiReturn ReadStaffs(string ptoken, [FromBody] MES_PMM_STAFF model)
        {
            return mesmodels.PMM_STAFF.Read(model);
        }

        [HttpPost]
        public ApiReturn UpdateStaff(string ptoken, [FromBody] MES_PMM_STAFF model)
        {
            return mesmodels.PMM_STAFF.Update(model);
        }

        [HttpPost]
        public ApiReturn DeleteStaff(string ptoken, [FromBody]MES_PMM_STAFF model)
        {
            return mesmodels.PMM_STAFF.Delete(model);
        }
    }
}
