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
    /// PUBLIC_FUNC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PUBLIC_FUNC : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public string GET_TIME(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PUBLIC_FUNC.GET_TIME();
            }
            else
            {
                return "";
            }
        }
        [WebMethod]
        public MES_RETURN GET_YGNAME(string GH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                string ghname = mesmodel.KQinfo.GET_STAFFNAME_BYGH(GH);
                MES_RETURN rst = new MES_RETURN();
                if (ghname == "")
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "工号错误！";
                }
                else
                {
                    rst.TYPE = "S";
                    rst.MESSAGE = ghname;
                }
                return rst;
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}
