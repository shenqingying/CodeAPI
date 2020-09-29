using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.Entities.CRM;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// HG_KHLX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_KHLX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(int STAFFKHLXID, int DICID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KHLX.Create(STAFFKHLXID, DICID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_HG_KHLXList> Read(int STAFFKHLXID, int DICID, string ptoken)
        {
            List<CRM_HG_KHLXList> node = new List<CRM_HG_KHLXList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KHLX.Read(STAFFKHLXID, DICID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int STAFFKHLXID, int DICID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KHLX.Delete(STAFFKHLXID, DICID);
            }
            return -100;
        }


    }
}
