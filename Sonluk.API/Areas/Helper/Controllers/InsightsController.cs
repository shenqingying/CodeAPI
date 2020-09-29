using Newtonsoft.Json.Linq;
using Sonluk.API.Models;
using Sonluk.Entities.API;
using System.Web.Http;

namespace Sonluk.API.Areas.Helper.Controllers
{
    [ApiReturn]
    [ApiAuthorize]
    public class InsightsController : ApiController
    {
        HelperModels models = new HelperModels();

        [HttpPost]
        public ApiReturn ReadApiRequestErrorMsgs(string ptoken, [FromBody] Helper_Insights_ApiRequest_ErrorMsg input)
        {
            if (ApiReceive.GetStaffID(ptoken) == 35 || ApiReceive.GetStaffID(ptoken) == 79)
            {
                if (input == null) input = new Helper_Insights_ApiRequest_ErrorMsg();
                return models.Insights.ReadApiRequestErrorMsgs(input);
            }
            else
            {
                return new ApiReturn(false, "00002");
            }
        }

        [HttpPost]
        public ApiReturn ReadApiRequests(string ptoken, [FromBody] Helper_Insights_ApiRequest input)
        {
            if (ApiReceive.GetStaffID(ptoken) == 35 || ApiReceive.GetStaffID(ptoken) == 79)
            {
                if (input == null) input = new Helper_Insights_ApiRequest();
                return models.Insights.ReadApiRequests(input);
            }
            else
            {
                return new ApiReturn(false, "00002");
            }
        }

        [HttpGet]
        public ApiReturn ReadConfig(string ptoken, string name)
        {
            if (ApiReceive.GetStaffID(ptoken) == 35 || ApiReceive.GetStaffID(ptoken) == 79)
            {
                return models.Insights.ReadConfig(new Helper_Insights_Config() { Name = name });
            }
            else
            {
                return new ApiReturn(false, "00002");
            }
        }

        [HttpGet]
        public ApiReturn UpdateConfig(string ptoken, string name, string value)
        {
            if (ApiReceive.GetStaffID(ptoken) == 35 || ApiReceive.GetStaffID(ptoken) == 79)
            {
                return models.Insights.UpdateConfig(new Helper_Insights_Config() { Name = name, Value = value });
            }
            else
            {
                return new ApiReturn(false, "00002");
            }
        }
    }
}
