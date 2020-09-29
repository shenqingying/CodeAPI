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
    /// COST_KADTMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KADTMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KADTMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KADTMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_KADTMX> ReadByParam(CRM_COST_KADTMX model, string ptoken)
        {
            List<CRM_COST_KADTMX> node = new List<CRM_COST_KADTMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int KADTMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.Delete(KADTMXID);
            }
            return -100;

        }

        [WebMethod]
        public int Create_CONN(COST_KADTMX_KAHXDJMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.Create_CONN(model);
            }
            return -100;

        }


        [WebMethod]
        public int DeleteByHXDJMXID_CONN(int HXDJMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.DeleteByHXDJMXID_CONN(HXDJMXID);
            }
            return -100;

        }


        [WebMethod]
        public List<CRM_COST_KADTMX> Read_Unconnected_CONN(CRM_COST_KADTMX model, string ptoken)
        {
            List<CRM_COST_KADTMX> node = new List<CRM_COST_KADTMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KADTMX.Read_Unconnected_CONN(model).ToList();
            }
            return node;

        }



    }
}
