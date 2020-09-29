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
    /// Route 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Route : System.Web.Services.WebService
    {
        LETRAModels _Models = new LETRAModels();

        [WebMethod]
        public RouteInfo Read(int source, int destination, decimal weight, string departure)
        {
            return _Models.Route.Read(source, destination, weight, departure);
        }

        [WebMethod]
        public RouteInfo ReadByCityID(int cityID)
        {
            return _Models.Route.Read(cityID);
        }

        [WebMethod]
        public int Create(RouteInfo node)
        {
            return _Models.Route.Create(node);
        }

        [WebMethod]
        public int Update(RouteInfo node)
        {
            return _Models.Route.Update(node);
        }

        //[WebMethod]
        //public string ReadDJ(int SXID, decimal weight)
        //{
        //    return _Models.Route.Read(SXID, weight);
        //}

        [WebMethod]
        public string ReadZSF(int BZDID, int EZDID)
        {
            return _Models.Route.ReadZSF(BZDID, EZDID);
        }
        [WebMethod]
        public string ReadDJ(int source, int destination, decimal weight)
        {
            return _Models.Route.ReadDJ(source, destination, weight);
        }
    }
}
