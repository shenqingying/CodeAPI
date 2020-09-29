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
    /// KH_GXQY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_GXQY : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_GXQY model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GXQY.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KH_GXQY model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GXQY.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_GXQYList> Read(int KHID, string ptoken)
        {
            List<CRM_KH_GXQYList> node = new List<CRM_KH_GXQYList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GXQY.Read(KHID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int Delete(int GXQYID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GXQY.Delete(GXQYID);
            }
            return -100;
            
        }
        [WebMethod]
        public int DeleteByKHID(int KHID,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_GXQY.DeleteByKHID(KHID);
            }
            return -100;
            
        }
    }
}
