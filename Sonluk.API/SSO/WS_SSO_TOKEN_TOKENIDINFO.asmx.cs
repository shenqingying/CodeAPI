using Sonluk.API.Models;
using Sonluk.Entities.MES;
using Sonluk.Entities.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.SSO
{
    /// <summary>
    /// WS_SSO_TOKEN_TOKENIDINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_SSO_TOKEN_TOKENIDINFO : System.Web.Services.WebService
    {
        SSOModels ssomodels = new SSOModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN SELECT(string TOKENID)
        {
            return ssomodels.TOKEN_TOKENIDINFO.SELECT(TOKENID);
        }
        [WebMethod]
        public MES_RETURN UPDATE(string TOKENID, int LB)
        {
            return ssomodels.TOKEN_TOKENIDINFO.UPDATE(TOKENID, LB);
        }
        [WebMethod]
        public MES_RETURN USERNAMEDY_INSERT(SSO_TOKEN_USERNAMEDY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return ssomodels.TOKEN_TOKENIDINFO.USERNAMEDY_INSERT(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN USERNAMEDY_UPDATE(SSO_TOKEN_USERNAMEDY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return ssomodels.TOKEN_TOKENIDINFO.USERNAMEDY_UPDATE(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public SSO_TOKEN_USERNAMEDY_SELECT USERNAMEDY_SELECT(SSO_TOKEN_USERNAMEDY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return ssomodels.TOKEN_TOKENIDINFO.USERNAMEDY_SELECT(model);
            }
            else
            {
                SSO_TOKEN_USERNAMEDY_SELECT rst = new SSO_TOKEN_USERNAMEDY_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
