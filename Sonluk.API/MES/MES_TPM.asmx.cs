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
    /// MES_TPM 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MES_TPM : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZBCFUN_TPINFO_INSERT INSERT_TPM(ZSL_BCS025 model, string IV_COUNT)
        {
            return mesmodel.MES_TPM.INSERT_TPM(model, IV_COUNT);
        }
        [WebMethod]
        public ZBCFUN_TPINFO_INSERT DELETE_TPM(string IV_TPNO)
        {
            return mesmodel.MES_TPM.DELETE_TPM(IV_TPNO);
        }
        [WebMethod]
        public ZBCFUN_TPINFO_INSERT UPDATE_TPM(ZSL_BCS025 model, List<ZSL_BCT012> model_IT_TPYD, string IV_FCODE, string IV_LGORT, string IV_WERKS)
        {
            return mesmodel.MES_TPM.UPDATE_TPM(model,model_IT_TPYD, IV_FCODE,IV_LGORT,IV_WERKS);
        }
        [WebMethod]
        public ZBCFUN_TPINFO_SELECT SELECT_TPM(ZSL_BCS025 model)
        {
            return mesmodel.MES_TPM.SELECT_TPM(model);
        }
        [WebMethod]
        public ZBCFUN_TP_ZHM_GL INSERT_TP_ZHM(string IV_FCODE, ZSL_BCT011 IT_TPZHNO, List<ZSL_BCT012> IT_TPZHNO_GL)
        {
            return mesmodel.MES_TPM.INSERT_TP_ZHM(IV_FCODE, IT_TPZHNO, IT_TPZHNO_GL);
        }
        [WebMethod]
        public ZBCFUN_TP_ZHM_GL SELECT_TP_ZHM(string IV_FCODE, string IV_TPZHNO, string IV_CJRQKS, string IV_CJRQJS, string IV_CJRNAME)
        {
            return mesmodel.MES_TPM.SELECT_TP_ZHM(IV_FCODE, IV_TPZHNO, IV_CJRQKS, IV_CJRQJS, IV_CJRNAME);
        }
        [WebMethod]
        public ZBCFUN_TP_ZHM_GL DELETE_TP_ZHM(ZSL_BCT012 model_IS_TPZHNO_GL, string IV_FCODE, string IV_TPZHNO)
        {
            return mesmodel.MES_TPM.DELETE_TP_ZHM(model_IS_TPZHNO_GL, IV_FCODE, IV_TPZHNO);
        }
        [WebMethod]
        public ZBCFUN_TP_RKBS_GL INSERT_TP_RKBS(List<ZSL_BCT010> IT_TPNO_GL)
        {
            return mesmodel.MES_TPM.INSERT_TP_RKBS(IT_TPNO_GL);
        }
        [WebMethod]
        public ZBCFUN_TP_RKBS_GL SELECT_TP_RKBS(string IV_TPNO)
        {
            return mesmodel.MES_TPM.SELECT_TP_RKBS(IV_TPNO);
        }
        [WebMethod]
        public ZBCFUN_TP_RKBS_GL DELETE_TP_RKBS(ZSL_BCT010 IS_TPNO_GL)
        {
            return mesmodel.MES_TPM.DELETE_TP_RKBS(IS_TPNO_GL);
        }
        [WebMethod]
        public MES_SY_TPM_SYNC_SELECT SELECT_TPM_SYNC(MES_SY_TPM_SYNC model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_TPM_SYNC.SELECT(model);
            }
            else
            {
                MES_SY_TPM_SYNC_SELECT rst = new MES_SY_TPM_SYNC_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
    }
}
