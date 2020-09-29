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
    /// HG_STAFFKHLX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HG_STAFFKHLX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_HG_STAFFKHLX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFKHLX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_HG_STAFFKHLX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFKHLX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int STAFFKHLXID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFKHLX.Delete(STAFFKHLXID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_HG_STAFFKHLX> Read(string ptoken)
        {
            List<CRM_HG_STAFFKHLX> node = new List<CRM_HG_STAFFKHLX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFKHLX.Read().ToList();
            }
            return node;

        }
        [WebMethod]
        public CRM_HG_STAFFKHLX ReadBySTAFFKHLXID(int STAFFKHLXID, string ptoken)
        {
            CRM_HG_STAFFKHLX node = new CRM_HG_STAFFKHLX();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.HG_STAFFKHLX.ReadBySTAFFKHLXID(STAFFKHLXID);
            }
            return node;
        }
    }
}
