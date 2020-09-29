using Sonluk.API.Models;
using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.SSO
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Sonluk.com/API/SSO/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {
        SSOModels models = new SSOModels();

        [WebMethod]
        public AccountInfo SignIn(string name, string passwordHash)
        {
            return models.User.SignIn(name, passwordHash);
        }

        [WebMethod]
        public bool ChangePassword(int SN, string passwordHash, string newPasswordHash)
        {
            return models.User.ChangePassword(SN, passwordHash, newPasswordHash);
        }


        [WebMethod]
        public AccountInfo SignIn_OnlyName(string name)
        {
            return models.User.SignIn_OnlyName(name);
        }
    }
}
