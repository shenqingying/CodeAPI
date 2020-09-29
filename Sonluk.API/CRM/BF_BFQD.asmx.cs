using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// BF_BFQD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BF_BFQD : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_BF_BFQD model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFQD.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_BF_BFQDLIST> ReadByBFDJID(int BFDJID, string ptoken)
        {
            List<CRM_BF_BFQDLIST> node = new List<CRM_BF_BFQDLIST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFQD.ReadByBFDJID(BFDJID).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int BFQDID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFQD.Delete(BFQDID);
            }
            return -100;
            
        }
    }
}
