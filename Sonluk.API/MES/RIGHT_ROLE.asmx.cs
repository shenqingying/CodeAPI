using Sonluk.API.Models;
using Sonluk.Entities.Account;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MES
{
    /// <summary>
    /// RIGHT_ROLE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class RIGHT_ROLE : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RIGHT_ROLE SELECT(int STAFFID, int RGROUPID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                TokenInfo tokeninfo = rmsmodel.CRM_Login.get_ptokeninfo_language(ptoken);
                return mesmodel.RIGHT_ROLE.SELECT(STAFFID, RGROUPID, tokeninfo.LANGUAGEID);
            }
            else
            {
                MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RIGHT_ROLE SELECT_ALL(int STAFFID, int RGROUPID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                TokenInfo tokeninfo = rmsmodel.CRM_Login.get_ptokeninfo_language(ptoken);
                return mesmodel.RIGHT_ROLE.SELECT_ALL(STAFFID, RGROUPID, tokeninfo.LANGUAGEID);
            }
            else
            {
                MES_RIGHT_ROLE rst = new MES_RIGHT_ROLE();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
