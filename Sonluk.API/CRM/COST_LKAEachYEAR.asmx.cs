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
    /// COST_LKAEachYEAR 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAEachYEAR : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_LKAEachYEAR model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAEachYEAR.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateByTTID(int LKAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAEachYEAR.UpdateByTTID(LKAYEARTTID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAEachYEAR> ReadByParam(CRM_COST_LKAEachYEAR model, string ptoken)
        {
            List<CRM_COST_LKAEachYEAR> node = new List<CRM_COST_LKAEachYEAR>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAEachYEAR.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int DeleteByTTID(int LKAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAEachYEAR.DeleteByTTID(LKAYEARTTID);
            }
            return -100;

        }







    }
}
