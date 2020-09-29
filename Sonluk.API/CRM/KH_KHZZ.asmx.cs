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
    /// KH_KHZZ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_KHZZ : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_KH_KHZZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.Create(model);
            }
            return -100;
        }

        [WebMethod]
        public int Update(CRM_KH_KHZZ model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.Update(model);
            }
            return -100;
        }

        [WebMethod]
        public int Delete(int ZZID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.Delete(ZZID);
            }
            return -100;
        }

        [WebMethod]
        public int DeleteByKHID(int KHID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.DeleteByKHID(KHID);
            }
            return -100;
        }

        [WebMethod]
        public List<CRM_KH_KHZZList> ReadByKHID(int KHID, string ptoken)
        {
            List<CRM_KH_KHZZList> node = new List<CRM_KH_KHZZList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.ReadByKHID(KHID).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<CRM_KH_KHZZ> ReadByParam(CRM_KH_KHZZ model, string ptoken)
        {
            List<CRM_KH_KHZZ> node = new List<CRM_KH_KHZZ>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.ReadByParam(model).ToList();
            }
            return node;
        }

        [WebMethod]
        public CRM_KH_KHZZ ReadByID(int ZZID, string ptoken)
        {
            CRM_KH_KHZZ node = new CRM_KH_KHZZ();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHZZ.ReadByID(ZZID);
            }
            return node;
        }





    }
}
