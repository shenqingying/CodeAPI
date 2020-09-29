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
    /// MES_FJ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_FJ : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZBCFUN_XFPC_READ SELECT_XFPC_BY_XFCD(int XFCD, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_XFPC_READ rst = mesmodel.MES_FJ.SELECT_XFPC_BY_XFCD(XFCD);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_XFPC_READ SELECT_PC(string GC, string WLH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_XFPC_READ rst = mesmodel.MES_FJ.SELECT_PC(GC, WLH);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_XFPC_READ rst = new ZBCFUN_XFPC_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
