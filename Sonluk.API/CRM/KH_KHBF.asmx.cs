using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace Sonluk.API.CRM
{
    /// <summary>
    /// KH_KHBF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_KHBF : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Create(CRM_KH_KHBFList model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHBF.Create(model);
            }
            return -100;
           
        }
         [WebMethod]

         public int Delete(CRM_KH_KHBFList model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHBF.Delete(model);
            }
            return -100;
            
        }
        [WebMethod]
         public List<CRM_KH_KHBFList> Read(int BFID, int KHID,string ptoken)
         {
             List<CRM_KH_KHBFList> node = new List<CRM_KH_KHBFList>();
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KH_KHBF.Read(BFID, KHID).ToList();
             }
             return node;
             
         }
        [WebMethod]
        public List<CRM_KH_KHBFList> ReadByParms(CRM_KH_KHBF_Parms model,string ptoken)
        {
            List<CRM_KH_KHBFList> node = new List<CRM_KH_KHBFList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHBF.ReadByParms(model).ToList();
            }
            return node;
            
        }
    }
}
