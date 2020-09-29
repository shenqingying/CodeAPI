using Sonluk.DAFactory;
using Sonluk.Entities.API;
using Sonluk.IDataAccess.Helper;
using System.Collections.Generic;

namespace Sonluk.BusinessLogic.Helper
{
    public class Insights
    {
        private static readonly IInsights_ApiRequest insightsApiRequest = HelperDataAccess.CreateInsights_ApiRequest();
        private static readonly IInsights_Config insightsConfig = HelperDataAccess.CreateInsights_Config();

        public ApiReturn ReadApiRequestErrorMsgs(Helper_Insights_ApiRequest_ErrorMsg model)
        {
            return insightsApiRequest.ReadErrorMsgs(model);
        }

        public ApiReturn CreateApiRequestErrorMsg(Helper_Insights_ApiRequest_ErrorMsg model)
        {
            return insightsApiRequest.CreateErrorMsg(model);
        }

        public ApiReturn ReadApiRequests(Helper_Insights_ApiRequest model)
        {
            ApiReturn rst = insightsApiRequest.Read(model);
            //不使用该方法（量太大）
            //if (rst.success)
            //{
            //    foreach (var item in ((ApiReturn<List<Helper_Insights_ApiRequest>>)rst).data)
            //    {
            //        ApiReturn child = ReadApiRequestErrorMsgs(new Helper_Insights_ApiRequest_ErrorMsg() { AID = item.ID });
            //        if (child.success) item.ErrorMessages = ((ApiReturn<List<Helper_Insights_ApiRequest_ErrorMsg>>)child).data;
            //        else rst.AddMessages(child.messages, false);
            //    }
            //}
            return rst;
        }

        public ApiReturn CreateApiRequest(Helper_Insights_ApiRequest model)
        {
            return insightsApiRequest.Create(model);
        }

        public ApiReturn UpdateApiRequest(Helper_Insights_ApiRequest model)
        {
            return insightsApiRequest.Update(model);
        }

        public ApiReturn ReadConfig(Helper_Insights_Config model)
        {
            return insightsConfig.Read(model);
        }

        public ApiReturn UpdateConfig(Helper_Insights_Config model)
        {
            return insightsConfig.Update(model);
        }
    }
}
