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
    /// COST_KATSCLMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KATSCLMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_KATSCLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KATSCLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_KATSCLMX> ReadByParam(CRM_COST_KATSCLMX model, string ptoken)
        {
            List<CRM_COST_KATSCLMX> node = new List<CRM_COST_KATSCLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KATSCLMX> Read_Unconnected(CRM_COST_KATSCLMX model, string ptoken)
        {
            List<CRM_COST_KATSCLMX> node = new List<CRM_COST_KATSCLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Read_Unconnected(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public int Delete(int KATSCLMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Delete(KATSCLMXID);
            }
            return -100;

        }

        [WebMethod]
        public int Create_CONN(COST_KATSCLMX_KAHXDJMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Create_CONN(model);
            }
            return -100;
        }
        
        [WebMethod]
        public List<CRM_COST_KATSCLMX> Read_Unconnected_CONN(CRM_COST_KATSCLMX model, string ptoken)
        {
            List<CRM_COST_KATSCLMX> node = new List<CRM_COST_KATSCLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.Read_Unconnected_CONN(model).ToList();
            }
            return node;
        }
        
        [WebMethod]
        public int DeleteByHXDJMXID(int HXDJMXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KATSCLMX.DeleteByHXDJMXID(HXDJMXID);
            }
            return -100;

        }


    }
}
