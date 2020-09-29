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
    /// COST_KAYEARTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KAYEARTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.Create(model);
            }
            return -100;
        }
        [WebMethod]
        public int Update(CRM_COST_KAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.Update(model);
            }
            return -100;
        }
        [WebMethod]
        public int UpdateSubmitCount(int KAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.UpdateSubmitCount(KAYEARTTID);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_KAYEARTT> ReadByParam(CRM_COST_KAYEARTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_KAYEARTT> node = new List<CRM_COST_KAYEARTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int KAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.Delete(KAYEARTTID);
            }
            return -100;
        }
        [WebMethod]
        public int Verify(CRM_COST_KAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAYEARTT.Verify(model);
            }
            return -100;
        }




    }
}
