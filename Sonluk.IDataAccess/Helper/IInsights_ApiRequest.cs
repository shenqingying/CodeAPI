using Sonluk.Entities.API;

namespace Sonluk.IDataAccess.Helper
{
    public interface IInsights_ApiRequest
    {
        ApiReturn Read(Helper_Insights_ApiRequest model);
        ApiReturn Create(Helper_Insights_ApiRequest model);
        ApiReturn Update(Helper_Insights_ApiRequest model);
        ApiReturn ReadErrorMsgs(Helper_Insights_ApiRequest_ErrorMsg model);
        ApiReturn CreateErrorMsg(Helper_Insights_ApiRequest_ErrorMsg model);
    }
}
