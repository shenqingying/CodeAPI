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
    /// UserToken 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class UserToken : System.Web.Services.WebService
    {
        SSOModels models = new SSOModels();
        [WebMethod]
        public TokenInfo Token(string name, string password)
        {
            return models.User.Token(name, password);
        }
        [WebMethod]
        public MenuInfo Menu(string ptoken, string parent)
        {
            MenuInfo ti = new MenuInfo();
            AccountInfo ac = models.User.AcceptToken(ptoken);
            //ti.ID = Convert.ToInt32(ac.SN);
            ti = models.Authorization.Menu(Convert.ToInt32(ac.SN), Convert.ToInt32(parent));
            return ti;
        }

        [WebMethod]
        public AccountInfo AcceptToken(string ptoken)
        {
            return models.User.AcceptToken(ptoken);
        }
        [WebMethod]

        public Boolean ValidateToken(string ptoken)
        {
            return models.User.ValidateToken(ptoken);
        }
    }
}
