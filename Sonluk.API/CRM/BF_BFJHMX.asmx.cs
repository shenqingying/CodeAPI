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
    /// BF_BFJHMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BF_BFJHMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(CRM_BF_BFJHMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFJHMX.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_BF_BFJHMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFJHMX.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(CRM_BF_BFJHMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFJHMX.Delete(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_BF_BFJHMXList> ReadbyBFJHID(int BFJHID,string ptoken)
        {
            List<CRM_BF_BFJHMXList> node = new List<CRM_BF_BFJHMXList>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BF_BFJHMX.ReadbyBFJHID(BFJHID).ToList();
            }
            return node;
            
        }
    }
}
