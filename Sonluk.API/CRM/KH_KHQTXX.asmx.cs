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
    /// KH_KHQTXX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_KHQTXX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_KHQTXX model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHQTXX.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_KH_KHQTXX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHQTXX.Update(model);
            }
            return -100;
           
        }
        [WebMethod]
        public int Delete(int XXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHQTXX.Delete(XXID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_KH_KHQTXXList> Read(int KHID, int XXLB, string ptoken)
        {
            List<CRM_KH_KHQTXXList> node = new List<CRM_KH_KHQTXXList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHQTXX.Read(KHID, XXLB).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public int DeleteByKHID_XXLB(int KHID, int XXLB,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHQTXX.DeleteByKHID_XXLB(KHID, XXLB);
            }
            return -100;
           
        }
    }
}
