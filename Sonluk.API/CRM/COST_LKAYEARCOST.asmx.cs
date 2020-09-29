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
    /// COST_LKAYEARCOST 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAYEARCOST : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateSPJE(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.UpdateSPJE(model);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_LKAYEARCOST> ReadByParam(CRM_COST_LKAYEARCOST model, string ptoken)
        {
            List<CRM_COST_LKAYEARCOST> node = new List<CRM_COST_LKAYEARCOST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int COSTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.Delete(COSTID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAYEARCOST> ReadCOSTByKHID(int KHID, string YEAR, string ptoken)
        {
            List<CRM_COST_LKAYEARCOST> node = new List<CRM_COST_LKAYEARCOST>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.ReadCOSTByKHID(KHID, YEAR).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_COST_GETCOST GetCost(int LKAID, string HTYEAR, string ptoken)
        {
            CRM_COST_GETCOST node = new CRM_COST_GETCOST();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARCOST.GetCost(LKAID, HTYEAR);
            }
            return node;
        }
    }
}
