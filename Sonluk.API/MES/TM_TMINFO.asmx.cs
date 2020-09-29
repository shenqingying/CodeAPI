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
    /// TM_TMINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TM_TMINFO : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BYTM(MES_TM_TMINFO model, int ISINSERT, int TLLB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_BYTM(model, ISINSERT, 1, TLLB);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_TM_TMINFO_INSERT_RETURN INSERT(MES_TM_TMINFO_INSERT_GL model, int ISAUTOADD, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.INSERT(model, "", ISAUTOADD);
            }
            else
            {
                MES_TM_TMINFO_INSERT_RETURN rst = new MES_TM_TMINFO_INSERT_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_TM_TMINFO_INSERT_RETURN INSERT_YEAR(MES_TM_TMINFO_INSERT_GL model, string YEAR, int ISAUTOADD, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.INSERT(model, YEAR, ISAUTOADD);
            }
            else
            {
                MES_TM_TMINFO_INSERT_RETURN rst = new MES_TM_TMINFO_INSERT_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_TM_TMINFO_INSERT_RETURN INSERT_OLD(MES_TM_TMINFO_INSERT_GL model, string YEAR, int ISAUTOADD, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.INSERT_OLD(model, YEAR, ISAUTOADD);
            }
            else
            {
                MES_TM_TMINFO_INSERT_RETURN rst = new MES_TM_TMINFO_INSERT_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_PRINT SELECT_BYID_CHILD(string GC, string TM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_BYID_CHILD(GC, TM);
            }
            else
            {
                SELECT_MES_TM_TMINFO_PRINT rst = new SELECT_MES_TM_TMINFO_PRINT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_TL_LAST(string RWBH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_TL_LAST(RWBH);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE(string TM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.DELETE(TM);
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
        public MES_RETURN DELETE_LOG(MES_TM_TMINFO_DELETE_IN model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.DELETE_LOG(model);
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
        public SELECT_MES_TM_TMINFO_BYTM SELECT_WLKCBS(MES_WLKCBS_GETWLZJ_IN model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_WLKCBS(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT(MES_TM_TMINFO model, int CXLB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT(model, CXLB);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_ALL(MES_TM_TMINFO model, int CXLB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_ALL(model, CXLB);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_TM_TMINFO_SELECT_TL_GL_CC SELECT_TL_GL_CC(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_TL_GL_CC(model);
            }
            else
            {
                MES_TM_TMINFO_SELECT_TL_GL_CC rst = new MES_TM_TMINFO_SELECT_TL_GL_CC();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT(List<MES_TM_TMINFO_LIST> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_GLSELECT(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_GLSELECT_ALL(List<MES_TM_TMINFO_LIST> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_GLSELECT_ALL(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE(MES_TM_TMINFO model, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.UPDATE(model, LB);
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
        public MES_RETURN UPDATE_CF(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.UPDATE_CF(model);
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
        public MES_RETURN UPDATE_CPZT(List<MES_TM_TMINFO> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.UPDATE_CPZT(model);
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
        public MES_RETURN VERIFY_TPMTH(string OLDTPM, string NEWTPM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.VERIFY_TPMTH(OLDTPM, NEWTPM);
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
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_STAFFID(MES_TM_TMINFO model, int CXLB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_BY_STAFFID(model, CXLB);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_KCDDLimit(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_BY_KCDDLimit(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_BY_UPDATEROLE(MES_TM_TMINFO_SELECT_BY_UPDATEROLE_IN model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_BY_UPDATEROLE(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_TM_TMINFO_XCTMINFO GET_XCTMINFO_BY_TMLIST(List<MES_PD_TL_SELECT_REPORT_LIST> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.GET_XCTMINFO_BY_TMLIST(model);
            }
            else
            {
                MES_TM_TMINFO_XCTMINFO rst = new MES_TM_TMINFO_XCTMINFO();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN SELECT_TM_LASTTIME(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_TM_LASTTIME(model);
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
        public MES_RETURN INSERT_ONLY(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.INSERT_ONLY(model);
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
        public MES_RETURN INSERT_ZS_WLKCBS(MES_TM_TMINFO_INSERT_GL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.INSERT_ZS_WLKCBS(model);
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
        public MES_RETURN DELETE_ZS_WLKCBS(List<MES_TM_TMINFO> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.DELETE_ZS_WLKCBS(model);
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
        public MES_RETURN ZS_WLKCBS_MOVE(List<MES_TM_TMINFO> model, string RKTEXT, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.ZS_WLKCBS_MOVE(model, RKTEXT);
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
        public MES_RETURN ZS_WLKCBS_CK(List<MES_TM_TMINFO> model, int KHID, string JLMS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.ZS_WLKCBS_CK(model, KHID, JLMS);
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
        public MES_RETURN ZS_FGDJ(List<MES_TM_TMINFO> model, string JLMS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.ZS_FGDJ(model, JLMS);
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
        public MES_RETURN ZS_THDJ(List<MES_TM_TMINFO> model, int KHID, string JLMS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.ZS_THDJ(model, KHID, JLMS);
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
        public SELECT_MES_TM_TMINFO_BYTM SELECT_KC_TT(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_KC_TT(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST(List<MES_TM_TMINFO_LIST> model, MES_TM_TMINFO model1, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_LIST(model, model1);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LIST_datatable(List<MES_TM_TMINFO_LIST> model, MES_TM_TMINFO model1, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_LIST_datatable(model, model1);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public SELECT_MES_TM_TMINFO_BYTM SELECT_LB(MES_TM_TMINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.TM_TMINFO.SELECT_LB(model);
            }
            else
            {
                SELECT_MES_TM_TMINFO_BYTM rst = new SELECT_MES_TM_TMINFO_BYTM();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
