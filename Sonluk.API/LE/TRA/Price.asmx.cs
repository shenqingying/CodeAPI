using Sonluk.API.Models;
using Sonluk.Entities.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.LE.TRA
{
    /// <summary>
    /// Price 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Price : System.Web.Services.WebService
    {
        LETRAModels _Models = new LETRAModels();

        [WebMethod]
        public List<PriceInfo> Read(int routeID)
        {
            return _Models.Price.Read(routeID).ToList();
        }

        [WebMethod]
        public int Create(List<PriceInfo> nodes)
        {
            return _Models.Price.Create(nodes);
        }

        [WebMethod]
        public int Delete(int routeID)
        {
            return _Models.Price.Delete(routeID);
        }
    }
}
