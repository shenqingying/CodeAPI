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
    /// HG_KQDZ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_KQDZ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_HG_KQDZ model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.Create(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Update(CRM_HG_KQDZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.Update(model);
            }
            return -100;
            
        }
        [WebMethod]
        public int Delete(int KQDZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.Delete(KQDZID);
            }
            return -100;
            
        }
        [WebMethod]
        public List<CRM_HG_KQDZ> Read(int KQDZID,string ptoken)
        {
            List<CRM_HG_KQDZ> node = new List<CRM_HG_KQDZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.Read(KQDZID).ToList();
            }
            return node;

            
        }
        [WebMethod]
        public List<CRM_HG_KQDZ> ReadBySTAFFID(int STAFFID,string ptoken)
        {
            List<CRM_HG_KQDZ> node = new List<CRM_HG_KQDZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.ReadBySTAFFID(STAFFID).ToList();
            }
            return node;
            
        }
        [WebMethod]
        public List<CRM_HG_KQDZ> ReadBylikeKQDZ(string KQDZ,string ptoken)
        {
            List<CRM_HG_KQDZ> node = new List<CRM_HG_KQDZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.ReadBylikeKQDZ(KQDZ).ToList();
            }
            return node;
            
        } 
        [WebMethod]
        public List<CRM_HG_KQDZList> Report(CRM_HG_KQDZList model,string ptoken)
        {
            List<CRM_HG_KQDZList> node = new List<CRM_HG_KQDZList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_KQDZ.Report(model).ToList();
            }
            return node;
            
        }
    }
}
