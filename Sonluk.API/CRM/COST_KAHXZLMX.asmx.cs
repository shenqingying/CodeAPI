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
    /// COST_KAHXZLMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KAHXZLMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KAHXZLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KAHXZLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateByKADTTTID(CRM_COST_KAHXZLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.UpdateByKADTTTID(model);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_KAHXZLMX> ReadByParam(CRM_COST_KAHXZLMX model, string ptoken)
        {
            List<CRM_COST_KAHXZLMX> node = new List<CRM_COST_KAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAHXZLMX> ReadByTTID(int HXZLTTID, string ptoken)
        {
            List<CRM_COST_KAHXZLMX> node = new List<CRM_COST_KAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.ReadByTTID(HXZLTTID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAHXZLMX> Read_Unconnected(CRM_COST_KAHXZLMX model, string ptoken)
        {
            List<CRM_COST_KAHXZLMX> node = new List<CRM_COST_KAHXZLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.Read_Unconnected(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int HXZLMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.Delete(HXZLMXID);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByKADTTTID(int KADTTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAHXZLMX.DeleteByKADTTTID(KADTTTID);
            }
            return -100;
        }





    }
}
