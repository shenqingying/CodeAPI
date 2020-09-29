using Sonluk.Entities.API;

namespace Sonluk.IDataAccess.Helper
{
    public interface IInsights_Config
    {
        ApiReturn Read(Helper_Insights_Config model);
        ApiReturn Update(Helper_Insights_Config model);
    }
}
