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
    /// MES_WLKCBS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_WLKCBS : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZBCFUN_PURBS_READ GET_WLPZ(ZSL_BCS303_CT IS_PURCT, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_PURBS_READ rst = mesmodel.MES_WLKCBS.GET_WLPZ(IS_PURCT);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_PURBS_READ GET_WLPZ_ZJ(ZSL_BCS303_BS IS_PURBS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_PURBS_READ rst = mesmodel.MES_WLKCBS.GET_WLPZ_ZJ(IS_PURBS);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_PURBS_READ INSERT_TM_WLPZ(List<ZSL_BCS303_BS> model, int INSERTLB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
                if (INSERTLB == 1)
                {
                    rst= mesmodel.MES_WLKCBS.INSERT_TM_WLPZ(model);
                }
                else
                {
                    rst= mesmodel.MES_WLKCBS.INSERT_TM_WLPZ_CHILD(model);
                }
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_PURBS_READ rst = new ZBCFUN_PURBS_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
