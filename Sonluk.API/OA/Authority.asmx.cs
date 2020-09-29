using Sonluk.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.OA
{
    /// <summary>
    /// Authority 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/OA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Authority : System.Web.Services.WebService
    {
        OAModels models = new OAModels();

        [WebMethod]
        public string Authenticate()
        {
            return models.Authority.Authenticate();
        }
    }
}
