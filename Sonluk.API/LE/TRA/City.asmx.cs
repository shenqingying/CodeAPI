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
    /// City 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/LE/TRA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class City : System.Web.Services.WebService
    {
        LETRAModels models = new LETRAModels();

        [WebMethod]
        public List<CityInfo> Read()
        {
            return models.City.Read().ToList();
        }

        [WebMethod]
        public int Create(CityInfo node)
        {
            return models.City.Create(node);
        }

        [WebMethod]
        public int Update(CityInfo node)
        {
            return models.City.Update(node);
        }

        [WebMethod]
        public int Modify(CityInfo node)
        {
            return models.City.Modify(node);
        }

        [WebMethod]
        public int Delete(int ID, bool province)
        {
            return models.City.Delete(ID, province);
        }
    }
}
