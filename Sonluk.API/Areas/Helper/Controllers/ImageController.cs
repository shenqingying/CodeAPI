using Newtonsoft.Json.Linq;
using Sonluk.API.Models;
using Sonluk.Entities.API;
using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class ImageController : ApiController
    {
        BCModels models = new BCModels();

        [HttpPost]
        public ApiReturn<byte[]> CreateQRCode([FromBody] dynamic input)
        {
            return new ApiReturn<byte[]>(models.BarCode.CreateBarCode((string)input.code, (string)input.format, (int)input.width, (int)input.height, (int)input.pure), true);
        }
        
        [HttpPost]
        public ApiReturn ReadQRCode([FromBody] dynamic input)
        {
            byte[] inputBytes = new byte[((JObject)input.blob).Count];
            foreach (var item in input.blob)
            {
                inputBytes[Convert.ToInt32(item.Name)] = (byte)item.Value;
            }
            return models.BarCode.ReadBarCode(inputBytes);
        }

        [HttpGet]
        public ApiReturn<byte[]> ReadImage(string path)
        {
            FileStream img = new FileStream(HttpContext.Current.Server.MapPath("~/Content/images/" + path), FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[img.Length];
            img.Read(buffer, 0, (int)img.Length);
            img.Close();
            return new ApiReturn<byte[]>(buffer, true);
        }
    }
}
