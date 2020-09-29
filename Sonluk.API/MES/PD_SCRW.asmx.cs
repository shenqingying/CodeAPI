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
    /// PD_SCRW 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PD_SCRW : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public SELECT_MES_PD_SCRW SELECT(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_PD_SCRWANDPD_LIST_SELECT SELECT_SCRW_GD(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_SCRW_GD(model);
            }
            else
            {
                MES_PD_SCRWANDPD_LIST_SELECT rst = new MES_PD_SCRWANDPD_LIST_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.DELETE(model);
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
        public MES_RETURN INSERT_LIST(List<MES_PD_SCRW_LIST> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.INSERT_LIST(model);
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
        public SELECT_MES_PD_SCRW SELECT_ZPQD(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_ZPQD(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_SCRW SELECT_LAST(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_LAST(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_SCRW UPDATE_FJTL(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.UPDATE_FJTL(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_SCRW UPDATE_FJCC(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.UPDATE_FJCC(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN FJTL_VERIFY(MES_PD_TL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.FJTL_VERIFY(model);
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
        public MES_PD_SCRW_CCTH SELECT_ZXCCINFO(string RWBH, int BC, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_ZXCCINFO(RWBH, BC, LB);
            }
            else
            {
                MES_PD_SCRW_CCTH rst = new MES_PD_SCRW_CCTH();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN ZX_CC(MES_PD_SCRW_ZXCC_INSERT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.ZX_CC(model, 0);
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
        public MES_RETURN ZX_CC_NOUPDATE_TIME(MES_PD_SCRW_ZXCC_INSERT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.ZX_CC(model, 1);
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
        public MES_RETURN ZX_CC_OLD(MES_PD_SCRW_ZXCC_INSERT model, string YEAR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.ZX_CC_OLD(model, YEAR);
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
        public SELECT_MES_PD_SCRW_ZX_LIST SELECT_ZX_LIST(string RWBH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_ZX_LIST(RWBH);
            }
            else
            {
                SELECT_MES_PD_SCRW_ZX_LIST rst = new SELECT_MES_PD_SCRW_ZX_LIST();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN DELETE_ZXCC(string TM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.DELETE_ZXCC(TM);
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
        public MES_RETURN UPDATE_SCRW(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.UPDATE_SCRW(model);
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
        public SELECT_MES_PD_SCRW GET_RWBH_BY_ERPNO(MES_PD_SCRW_GET_BY_ERPNO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                if (model.ERPNO.Length == 8)
                {
                    rst = mesmodel.PD_SCRW.GET_RWBH_BY_ERPNO(model);
                }
                else
                {
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "工单位数错误！请检查！";
                    rst.MES_RETURN = child_MES_RETURN;
                }
                return rst;
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_PD_SCRW GET_RWBH_BY_ERPNO_OLD(MES_PD_SCRW_GET_BY_ERPNO model, string YEAR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                if (model.ERPNO.Length == 8)
                {
                    rst = mesmodel.PD_SCRW.GET_RWBH_BY_ERPNO_OLD(model, YEAR);
                }
                else
                {
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "工单位数错误！请检查！";
                    rst.MES_RETURN = child_MES_RETURN;
                }
                return rst;
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }

        [WebMethod]
        public SELECT_MES_PD_SCRW GET_RWBH_BY_TPM(MES_PD_SCRW_GET_BY_TPM model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                if (model.TPM.Length == 12)
                {
                    rst = mesmodel.PD_SCRW.GET_RWBH_BY_TPM(model);
                }
                else
                {
                    MES_RETURN child_MES_RETURN = new MES_RETURN();
                    child_MES_RETURN.TYPE = "E";
                    child_MES_RETURN.MESSAGE = "托盘码位数错误！请检查！";
                    rst.MES_RETURN = child_MES_RETURN;
                }
                return rst;
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_BY_FJPD(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.INSERT_BY_FJPD(model);
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
        public SELECT_MES_PD_SCRW SELECT_BY_ROLE(MES_PD_SCRW model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_BY_ROLE(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE_GZZX(string GC, string GZZXBH, int BC, string GDDH, string ZPRQ, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.DELETE_GZZX(GC, GZZXBH, BC, GDDH, ZPRQ);
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
        public SELECT_MES_PD_SCRW SELECT_BY_TM(MES_PD_SCRW_SELECT_BY_TM model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_BY_TM(model);
            }
            else
            {
                SELECT_MES_PD_SCRW rst = new SELECT_MES_PD_SCRW();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_PD_SCRW_SUM_SELECT SELECT_SUM(MES_PD_SCRW_SUM_LIST model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_SUM(model);
            }
            else
            {
                MES_PD_SCRW_SUM_SELECT rst = new MES_PD_SCRW_SUM_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }

        }
        [WebMethod]
        public MES_SY_FJ_RWKB_SELECT SELECT_JDKB(MES_SY_FJ_RWKB model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.SELECT_JDKB(model);
            }
            else
            {
                MES_SY_FJ_RWKB_SELECT rst = new MES_SY_FJ_RWKB_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_YEAR(MES_PD_SCRW model, string YEAR, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.INSERT_YEAR(model, YEAR);
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
        public MES_RETURN UPDATE_ALL(MES_PD_SCRW_UPDATE_IN model, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.PD_SCRW.UPDATE_ALL(model, LB);
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
