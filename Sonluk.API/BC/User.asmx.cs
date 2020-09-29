using Sonluk.API.Models;
using Sonluk.Entities.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.BC
{
    /// <summary>
    /// Enqueue 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/BC/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {
        BCModels models = new BCModels();

        [WebMethod]
        public UserInfo Read(string signInName)
        {
            return models.User.Read(signInName);
        }
    }
}
