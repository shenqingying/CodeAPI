using Sonluk.API.Models;
using Sonluk.Entities.MES;
using Sonluk.Entities.QM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.QM
{
    /// <summary>
    /// WS_QM_ZSL_QMFG_RFC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_QM_ZSL_QMFG_RFC : System.Web.Services.WebService
    {
        QMModels models = new QMModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZSL_QMFM_012_SELECT ZSL_QMFM_012(ZSL_QMFM_012_SELECT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.ZSL_QMFG_RFC.ZSL_QMFM_012(model);
            }
            else
            {
                ZSL_QMFM_012_SELECT rst = new ZSL_QMFM_012_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
