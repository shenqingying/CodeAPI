using Sonluk.BusinessLogic.MES;
using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using System.Collections.Generic;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class DicController : ApiController
    {
        [HttpGet]
        public ApiReturn ReadTypemxs(int id = 0, int typeId = 0, string mxName = "", string factoryCode = "")
        {
            return new ApiReturn<IList<MES_SY_TYPEMXLIST>>(new SY_TYPEMX().SELECT(new MES_SY_TYPEMX()
            {
                ID = id,
                TYPEID = typeId,
                MXNAME = mxName,
                GC = factoryCode
            }), true);
        }
    }
}
