using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.Account;

namespace Sonluk.API.Account
{
    /// <summary>
    /// Access 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://sonluk.com/API/Account/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Access : System.Web.Services.WebService
    {
        AccountModels models = new AccountModels();

        [WebMethod]
        public AccountInfo SignIn(string signInName, string password)
        {
            return models.Access.SignIn(signInName, password);
        }
        [WebMethod]
        public AccountInfo SignInSS0(string signInName, string password,string url)
        {
            return models.Access.SignInSS0(signInName, password,url);
        }

        [WebMethod]
        public bool ChangePassword(string signInName, string password, string newPassword)
        {
            return models.Access.ChangePassword(signInName, password, newPassword);
        }

    }
}
