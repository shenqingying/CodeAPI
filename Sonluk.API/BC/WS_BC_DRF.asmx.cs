using Sonluk.API.Models;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.BC
{
    /// <summary>
    /// WS_BC_DRF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_BC_DRF : System.Web.Services.WebService
    {
        BCModels models = new BCModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(ZSL_BCS111 IS_HEADDATA, List<ZSL_BCS112> IT_ITEMDATA, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.DRF.ZBCFUN_DRFDD_CRT(IS_HEADDATA, IT_ITEMDATA);
            }
            else
            {
                ZBCFUN_DRFDD_CRT_RETURN rst = new ZBCFUN_DRFDD_CRT_RETURN();
                MES_RETURN child_ET_RETURN = new MES_RETURN();
                child_ET_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                child_ET_RETURN.TYPE = "E";
                rst.MES_RETURN = child_ET_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN ZBCFUN_DRFDD_CHK(ZSL_BCS111 IS_HEADDATA, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.DRF.ZBCFUN_DRFDD_CHK(IS_HEADDATA);
            }
            else
            {
                MES_RETURN child_ET_RETURN = new MES_RETURN();
                child_ET_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                child_ET_RETURN.TYPE = "E";
                return child_ET_RETURN;
            }
        }
        [WebMethod]
        public ZBCFUN_DRFDD_DT_RETURN ZBCFUN_DRFDD_DT(List<ZSL_BCS113> IT_ORDERDATA, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return models.DRF.ZBCFUN_DRFDD_DT(IT_ORDERDATA);
            }
            else
            {
                ZBCFUN_DRFDD_DT_RETURN rst = new ZBCFUN_DRFDD_DT_RETURN();
                MES_RETURN child_ET_RETURN = new MES_RETURN();
                child_ET_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                child_ET_RETURN.TYPE = "E";
                rst.MES_RETURN = child_ET_RETURN;
                return rst;
            }
        }
    }
}
