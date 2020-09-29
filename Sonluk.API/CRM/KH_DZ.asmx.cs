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
    /// KH_DZ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_DZ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_DZ model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_DZ.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KH_DZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_DZ.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int DZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_DZ.Delete(DZID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_DZList> ReadByKHID(int KHID, string ptoken)
        {
            List<CRM_KH_DZList> node = new List<CRM_KH_DZList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_DZ.ReadByKHID(KHID).ToList();
            }
            return node;
            
        }
    }
}
