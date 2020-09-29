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
    /// MES_MM 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_MM : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZBCFUN_CPBZ_READ get_CPBZ_READ(string IV_TPM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_CPBZ_READ rst = mesmodel.MES_MM.get_CPBZ_READ(IV_TPM);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_CPBZ_READ rst = new ZBCFUN_CPBZ_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_SY_MATERIAL_INSERT_LIST GET_WLXXBYGROUP(string IV_WERKS, string WLGROUP, string MATNR, string FCODE, string ptoken)
        {
            
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_SY_MATERIAL_INSERT_LIST rst = mesmodel.MES_MM.GET_WLXXBYGROUP(IV_WERKS, WLGROUP, MATNR, FCODE);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_SY_MATERIAL_INSERT_LIST rst = new MES_SY_MATERIAL_INSERT_LIST();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
