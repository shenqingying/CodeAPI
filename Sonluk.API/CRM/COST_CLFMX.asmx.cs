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
    /// COST_CLFMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_CLFMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_CLFMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.Create(model);
            }
            return -100;
        }

        [WebMethod]
        public int Update(CRM_COST_CLFMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.Update(model);
            }
            return -100;

        }

        [WebMethod]
        public List<CRM_COST_CLFMX> ReadByParam(CRM_COST_CLFMX model, string ptoken)
        {
            List<CRM_COST_CLFMX> node = new List<CRM_COST_CLFMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_CLFMX> ReadPart(CRM_COST_CLFMX model, string ptoken)
        {
            List<CRM_COST_CLFMX> node = new List<CRM_COST_CLFMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.ReadPart(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_CLFMX> ReadByTTID(int CLFTTID, string ptoken)
        {
            List<CRM_COST_CLFMX> node = new List<CRM_COST_CLFMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.ReadByTTID(CLFTTID).ToList();
            }
            return node;

        }

        [WebMethod]
        public int Delete(int CLFMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX.Delete(CLFMXID);
            }
            return -100;

        }
    }
}
