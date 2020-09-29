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
    /// COST_ZZFSJT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_ZZFSJT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_COST_ZZFSJT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_ZZFSJT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_ZZFSJT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_ZZFSJT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_ZZFSJT> ReadByParam(CRM_COST_ZZFSJT model, string ptoken)
        {
            List<CRM_COST_ZZFSJT> node = new List<CRM_COST_ZZFSJT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_ZZFSJT.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int MXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_ZZFSJT.Delete(MXID);
            }
            return -100;

        }
    }
}
