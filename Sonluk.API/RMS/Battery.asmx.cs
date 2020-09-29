using Sonluk.API.Models;
using Sonluk.Entities.RMS;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.RMS
{
    /// <summary>
    /// Battery 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/RMS/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Battery : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();

        [WebMethod]
        public List<BatteryHistoryInfo> History(string code, string type)
        {
            return models.Product.History(code, type).ToList();
        }

        [WebMethod]
        public List<BatteryInfo> Type()
        {
            return models.Product.Type().ToList();
        }
    }
}
