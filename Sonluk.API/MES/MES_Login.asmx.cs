using Sonluk.API.Models;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MES
{
    /// <summary>
    /// MES_Login 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_Login : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        [WebMethod]
        public MES_LoginINFO Login(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID)
        {
            return mesmodel.MES_Login.Login(name, password, OPENID, WXDLCS, PC, WX, GCID);
        }
        [WebMethod]
        public MES_LoginINFO Login_language(string name, string password, string OPENID, string WXDLCS, int PC, int WX, int GCID,int LANGUAGEID)
        {
            return mesmodel.MES_Login.Login_language(name, password, OPENID, WXDLCS, PC, WX, GCID, LANGUAGEID);
        }
    }
}
