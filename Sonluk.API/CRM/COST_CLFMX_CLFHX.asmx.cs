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
    /// COST_CLFMX_CLFHX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_CLFMX_CLFHX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_CLFMX_CLFHX> ReadByParam(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            List<CRM_COST_CLFMX_CLFHX> node = new List<CRM_COST_CLFMX_CLFHX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_CLFMX_CLFHX> ReadByCLFHXID(int CLFHXID, string ptoken)
        {
            List<CRM_COST_CLFMX_CLFHX> node = new List<CRM_COST_CLFMX_CLFHX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.ReadByCLFHXID(CLFHXID).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_CLFMX_CLFHX> ReadByCLFMXID(int CLFMXID, string ptoken)
        {
            List<CRM_COST_CLFMX_CLFHX> node = new List<CRM_COST_CLFMX_CLFHX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.ReadByCLFMXID(CLFMXID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(CRM_COST_CLFMX_CLFHX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.Delete(model);
            }
            return -100;

        }
        [WebMethod]
        public int DeleteByCLFHXID(int CLFHXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CLFMX_CLFHX.DeleteByCLFHXID(CLFHXID);
            }
            return -100;
        }
    }
}
