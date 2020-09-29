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
    /// BC_CHTT_FAKE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BC_CHTT_FAKE : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int TTCreate(CRM_BC_CHTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT_FAKE.TTCreate(model);
            }
            return -100;
        }
        [WebMethod]
        public int MXCreate(CRM_BC_CHMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT_FAKE.MXCreate(model);
            }
            return -100;
        }
        [WebMethod]
        public int TTMXDelete(string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.BC_CHTT_FAKE.TTMXDelete();
            }
            return -100;
        }

    }
}
