using Sonluk.API.Models;
using Sonluk.Entities.KQ;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.HR
{
    /// <summary>
    /// WS_HR_KQ_KQINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_HR_KQ_KQINFO : System.Web.Services.WebService
    {

        HRModels hrmodel = new HRModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN SYNC(string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.KQ_KQINFO.SYNC();
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
        public HR_KQ_KQINFO_SELECT SELECT(HR_KQ_KQINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.KQ_KQINFO.SELECT(model);
            }
            else
            {
                HR_KQ_KQINFO_SELECT rst = new HR_KQ_KQINFO_SELECT();
                MES_RETURN rst_MES_RETURN = new MES_RETURN();
                rst_MES_RETURN.TYPE = "E";
                rst_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}
