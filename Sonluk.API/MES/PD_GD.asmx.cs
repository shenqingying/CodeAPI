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
    /// PD_GD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PD_GD : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT(model, "");
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public ZBCFUN_GDLIST_READ SAP_GET_GDLIST(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_GDLIST_READ rst = mesmodel.MES_MM.GET_GDLIST(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_GDLIST_READ SAP_GET_GDLIST1(string IV_WERKS, string IV_GZZX, string IV_WLDL, string IV_AUFNR, string LOW, string HIGH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_GDLIST_READ rst = mesmodel.MES_MM.GET_GDLIST_1(IV_WERKS, IV_GZZX, IV_WLDL, IV_AUFNR, LOW, HIGH);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_GDLIST_READ rst = new ZBCFUN_GDLIST_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_GDJGXX_READ SAP_GET_GDJGXX(string RWBH, string ZPRQ, string GC, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_GDJGXX_READ rst = mesmodel.MES_MM.get_GDJGXX(RWBH, ZPRQ, GC);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return mesmodel.MES_MM.get_GDJGXX(RWBH, ZPRQ, GC);
            }
            else
            {
                ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_GD SELECT(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_GD rst = mesmodel.PD_GD.SELECT(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_FROM_SAP_GD(List<ZSL_BCST024_PO> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT_FROM_SAP_GD(model, "");
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN UPDATE(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.UPDATE(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN DELETE(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.DELETE(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN INSERT_BY_MES(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT_BY_MES(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN INSERT_BY_MES_OLD(MES_PD_GD model, string YEAR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT_BY_MES_OLD(model, YEAR);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN INSERT_BY_SAPGDLIST(string IV_WERKS, string IV_GZZX, string IV_AUFNR, string LOW, string HIGH, int JRL, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT_BY_SAPGDLIST(IV_WERKS, IV_GZZX, IV_AUFNR, LOW, HIGH, JRL);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public MES_RETURN INSERT_BY_SAPGDLIST_1(string IV_WERKS, string IV_GZZX, string LOW, string HIGH, int JRL, string IV_AUFNR, string YEAR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.PD_GD.INSERT_BY_SAPGDLIST_1(IV_WERKS, IV_GZZX, LOW, HIGH, JRL, IV_AUFNR, YEAR);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
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
        [WebMethod]
        public SELECT_MES_PD_GD SELECT_BY_PFDH(MES_PD_GD_SELECT_BY_PFDH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_GD rst = mesmodel.PD_GD.SELECT_BY_PFDH(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_GDJGXX_READ get_GDJGXX_BYERPNO(string IV_AUFNR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_GDJGXX_READ rst = mesmodel.MES_MM.get_GDJGXX(IV_AUFNR);
                //rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public ZBCFUN_GDJGXX_READ get_GDJGXX_BYERPNO_GC(string IV_WERKS, string IV_AUFNR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                ZBCFUN_GDJGXX_READ rst = mesmodel.MES_MM.get_GDJGXX_GC(IV_WERKS, IV_AUFNR);
                //rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                ZBCFUN_GDJGXX_READ rst = new ZBCFUN_GDJGXX_READ();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
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
        public SELECT_MES_PD_GD SELECT_BY_STAFFID(MES_PD_GD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_GD rst = mesmodel.PD_GD.SELECT_BY_STAFFID(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_PD_GD_GDJD_SELECT SELECT_GDJD(MES_PD_GD_GDJD_IMPORT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_PD_GD_GDJD_SELECT rst = mesmodel.PD_GD.SELECT_GDJD(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_PD_GD_GDJD_SELECT rst = new MES_PD_GD_GDJD_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_GD SELECT_BY_ERPNO_SYNC(MES_PD_GD model, string ptoken)
        {
            //return mesmodel.PD_GD.SELECT_BY_ERPNO_SYNC(model);
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_GD rst = mesmodel.PD_GD.SELECT_BY_ERPNO_SYNC(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                SELECT_MES_PD_GD rst = new SELECT_MES_PD_GD();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
