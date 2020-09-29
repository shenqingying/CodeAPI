using Sonluk.IDataAccess.Helper;
using Sonluk.Utility;
using System.Reflection;

namespace Sonluk.DAFactory
{
    public class HelperDataAccess
    {
        private static readonly string assembly = AppConfig.Settings("RMS.DataAccess");

        public static IInsights_ApiRequest CreateInsights_ApiRequest()
        {
            return (IInsights_ApiRequest)Assembly.Load(assembly).CreateInstance(assembly + ".Helper.Insights_ApiRequest");
        }
        public static IInsights_Config CreateInsights_Config()
        {
            return (IInsights_Config)Assembly.Load(assembly).CreateInstance(assembly + ".Helper.Insights_Config");
        }
    }
}
