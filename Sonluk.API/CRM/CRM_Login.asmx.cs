using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// CRM_Login 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CRM_Login : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public CRM_LoginInfo Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX)
        {
            return models.CRM_Login.Login(name, password, OPENID, WXDLCS, PC, WX);
        }
        [WebMethod]
        public int WX_SYS_Update(CRM_WX_SYS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_Login.WX_SYS_Update(model);
            }
            return -100;

        }
        [WebMethod]
        public CRM_WX_SYS WX_SYS_ReadByWXAPPID(string WXAPPID, string ptoken)
        {
            CRM_WX_SYS node = new CRM_WX_SYS();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.CRM_Login.WX_SYS_ReadByWXAPPID(WXAPPID);
            }
            return node;


        }
        [WebMethod]
        public Boolean ValidateToken(string ptoken)
        {
            return models.CRM_Login.ValidateToken(ptoken);
        }
        [WebMethod]
        public TokenInfo Login_SSO(string name, string password, string OPENID, string WXDLCS)
        {
            return models.CRM_Login.Login_SSO(name, password, OPENID, WXDLCS);
        }
        [WebMethod]
        public TokenInfo Login_SSO_LANGUAGE(string name, string password, string OPENID, string WXDLCS, int SYLANGUAGEID)
        {
            return models.CRM_Login.Login_SSO_LANGUAGE(name, password, OPENID, WXDLCS, SYLANGUAGEID);
        }
        [WebMethod]
        public CRM_LoginInfo Login_SSO_TOKEN(string TOKENID, int PC, int WX)
        {
            return models.CRM_Login.Login_SSO_TOKEN(TOKENID, PC, WX);
        }
        [WebMethod]
        public CRM_LoginInfo Login_SSO_TOKEN_LANGUAGE(string TOKENID, int PC, int WX)
        {
            return models.CRM_Login.Login_SSO_TOKEN_LANGUAGE(TOKENID, PC, WX);
        }
        [WebMethod]
        public TokenInfo get_ptokeninfo_language(string ptoken)
        {
            return models.CRM_Login.get_ptokeninfo_language(ptoken);
        }
    }
}
