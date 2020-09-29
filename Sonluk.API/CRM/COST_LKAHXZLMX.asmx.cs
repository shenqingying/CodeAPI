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
    /// COST_LKAHXZLMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAHXZLMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAHXZLMX> ReadByParam(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            List<CRM_COST_LKAHXZLMX> node = new List<CRM_COST_LKAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_LKAHXZLMX> ReadByTTID(int HXZLTTID, string ptoken)
        {
            List<CRM_COST_LKAHXZLMX> node = new List<CRM_COST_LKAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.ReadByTTID(HXZLTTID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int HXZLMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.Delete(HXZLMXID);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByLKAFYTTID(int LKAFYTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.DeleteByLKAFYTTID(LKAFYTTID);
            }
            return -100;
        }
        [WebMethod]
        public CRM_COST_LKAHXZLMX ReadMXinfo(CRM_COST_LKAHXZLMX model, string HTYEAR, int LKAID, string ptoken)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.ReadMXinfo(model, HTYEAR, LKAID);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_LKAHXZLMX> Read_Unconnected(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            List<CRM_COST_LKAHXZLMX> node = new List<CRM_COST_LKAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.Read_Unconnected(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public CRM_COST_LKAHXZLMX Read_CostTime(CRM_COST_LKAHXZLMX model, string ptoken)
        {
            CRM_COST_LKAHXZLMX node = new CRM_COST_LKAHXZLMX();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAHXZLMX.Read_CostTime(model);
            }
            return node;
        }



    }
}
