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
    /// KH_KHXS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KH_KHXS : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_KH_KHXS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHXS.Create(model);
            }
            return -100;


        }
        [WebMethod]
        public int Update(CRM_KH_KHXS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHXS.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(CRM_KH_KHXS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHXS.Delete(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_KH_KHXSList> Read(CRM_KH_KHXS model, string ptoken)
        {
            List<CRM_KH_KHXSList> node = new List<CRM_KH_KHXSList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHXS.Read(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_KH_KHXS_DZSreportList> DZSreport(CRM_KH_KHXS_DZSreport model, int STAFFID, string ptoken)
        {
            List<CRM_KH_KHXS_DZSreportList> node = new List<CRM_KH_KHXS_DZSreportList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KH_KHXS.DZSreport(model,STAFFID).ToList();
            }
            return node;
        }
    }
}
