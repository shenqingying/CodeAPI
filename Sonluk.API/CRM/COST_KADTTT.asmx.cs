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
    /// COST_KADTTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KADTTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KADTTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KADTTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateCost(int KADTTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.UpdateCost(KADTTTID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_KADTTT> ReadByParam(CRM_COST_KADTTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_KADTTT> node = new List<CRM_COST_KADTTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KADTTT> Read_Unconnected(CRM_COST_KADTTT model, string ptoken)
        {
            List<CRM_COST_KADTTT> node = new List<CRM_COST_KADTTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.Read_Unconnected(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int KADTTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTTT.Delete(KADTTTID);
            }
            return -100;

        }
    }
}
