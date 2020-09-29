using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// DuiBiReport 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class DuiBiReport : System.Web.Services.WebService
    {

        
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public DataTable RuK_DuiBiReport(RuK_DuiBiReport model, string ptoken)
        {
            DataTable node = new DataTable();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.DuiBiReport.RuK_DuiBiReport(model);
            }
            return node;

        }
    }
}
