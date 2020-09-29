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
    /// BAT_REPORT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BAT_REPORT : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public MES_BAT_REPORT SEARCH(MES_BAT_REPORT_SEARCH model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_REPORT.SEARCH(model, STAFFID);
            }
            else
            {
                MES_BAT_REPORT rst = new MES_BAT_REPORT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}
