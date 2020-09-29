using Newtonsoft.Json;
using Sonluk.API.Areas.Helper.Models;
using Sonluk.API.Models;
using Sonluk.Entities.API;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiAuthorize]
    public class ExcelController : ApiController
    {
        HelperModels model = new HelperModels();

        [HttpPost]
        public HttpResponseMessage ReadExcelByData()
        {
            ExcelModel data = JsonConvert.DeserializeObject<ExcelModel>(HttpContext.Current.Request["input"]);
            ApiReturn rst = model.ExcelHelper.DataToExcel(HttpContext.Current.Server.MapPath("~/"), data.data, data.dataName, data.title, data.sheetTitle, data.dataTransform, data.sep, data.sepChild);
            return ApiResponse.Download(rst.success, ((ApiReturn<string>)rst).data, data.downloadName);
        }

    }
}
