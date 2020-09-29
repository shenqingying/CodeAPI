using Sonluk.API.Models;
using Sonluk.Entities.BC;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// ORDER_SH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ORDER_SH : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public RETURN_MSG Modify(List<CRM_ORDER_SH> model,string ptoken)
        {
            RETURN_MSG node = new RETURN_MSG();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_SH.Modify(model);
            }
            return node;

        }
        [WebMethod]
        public List<CRM_ORDER_SH> ReadByParam(CRM_ORDER_SH model, string ptoken)
        {
            List<CRM_ORDER_SH> node = new List<CRM_ORDER_SH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_SH.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_ORDER_SH> Report(CRM_ORDER_SH model, string ptoken)
        {
            List<CRM_ORDER_SH> node = new List<CRM_ORDER_SH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.ORDER_SH.Report(model).ToList();
            }
            return node;

        }


    }
}
