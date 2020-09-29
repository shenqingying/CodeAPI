using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// HG_RYKQ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_RYKQ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(int STAFFID, int KQDZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RYKQ.Create(STAFFID, KQDZID);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int STAFFID, int KQDZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RYKQ.Delete(STAFFID, KQDZID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<string[]> ReadBySTAFFID(int STAFFID, string ptoken)
        {
            List<string[]> node = new List<string[]>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_RYKQ.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
            
        }
    }
}
