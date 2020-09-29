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
    /// COST_KATSCLTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KATSCLTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KATSCLTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLTT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KATSCLTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLTT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateCost(int KATSCLTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLTT.UpdateCost(KATSCLTTID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_KATSCLTT> ReadByParam(CRM_COST_KATSCLTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_KATSCLTT> node = new List<CRM_COST_KATSCLTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLTT.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int KATSCLTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLTT.Delete(KATSCLTTID);
            }
            return -100;

        }
    }
}
