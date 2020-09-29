using Sonluk.API.Models;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.HR
{
    /// <summary>
    /// RY_RYINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class RY_RYINFO : System.Web.Services.WebService
    {
        HRModels hrmodel = new HRModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public HR_RY_RYINFO_SELECT INSERT(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.INSERT(model);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_RY_RYINFO_SELECT SELECT(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT(model);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_ALL(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_ALL(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_PIC(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_PIC(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_CHECK(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_CHECK(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_DEPT(List<HR_RY_RYINFO> model, int DEPT, int GSBM, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_DEPT(model, DEPT, GSBM);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN UPDATE_YGTYPE(List<HR_RY_RYINFO> model, int YGTYPE, int ZZZT, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_YGTYPE(model, YGTYPE, ZZZT);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_JOBS(List<HR_RY_RYINFO> model, int JOBS, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_JOBS(model, JOBS);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_QUIT(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_QUIT(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_CHANGEINFO(model);
            }
            else
            {
                MES_RETURN rst = new MES_RETURN();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_ISINGH(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_ISINGH(model);
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
        public MES_RETURN UPDATE_DUTYNAME(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_DUTYNAME(model);
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
        public HR_RY_RYINFO_SELECT SELECT_GSGL(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_GSGL(model);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_RY_RYINFO_SELECT SELECT_WJGL(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_WJGL(model);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_RY_RYINFO_SELECT SELECT_WBZW(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_WBZW(model);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_RONGY(HR_RY_RONGY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.INSERT_RONGY(model);
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
        public HR_RY_RONGY_SELECT SELECT_RONGY(HR_RY_RONGY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_RONGY(model);
            }
            else
            {
                HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_RONGY(HR_RY_RONGY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_RONGY(model);
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
        public MES_RETURN DELETE_RONGY(int RONGYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.DELETE_RONGY(RONGYID);
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
        public MES_RETURN INSERT_RONGY_RYID(int RONGYID, int RYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.INSERT_RONGY_RYID(RONGYID, RYID);
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
        public MES_RETURN DELETE_RONGY_RYID(int RONGYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.DELETE_RONGY_RYID(RONGYID);
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
        public HR_RY_RONGY_SELECT SELECT_RONGY_RYID(int RYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_RONGY_RYID(RYID);
            }
            else
            {
                HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_RONGY_FILE(HR_RY_RONGY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.INSERT_RONGY_FILE(model);
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
        public HR_RY_RONGY_SELECT SELECT_RONGY_FILE(int RONGYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_RONGY_FILE(RONGYID);
            }
            else
            {
                HR_RY_RONGY_SELECT rst = new HR_RY_RONGY_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE_RONGY_FILE(int RYFILEID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.DELETE_RONGY_FILE(RYFILEID);
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
        public HR_RY_RYINFO_SELECT SELECT_LB(HR_RY_RYINFO model, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_LB(model, LB);
            }
            else
            {
                HR_RY_RYINFO_SELECT rst = new HR_RY_RYINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_RY_LZINFO_SELECT SELECT_LZINFO(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_LZINFO(model);
            }
            else
            {
                HR_RY_LZINFO_SELECT rst = new HR_RY_LZINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_RY_CHANGEINFO_SELECT SELECT_RY_CHANGEINFO(HR_RY_RYINFO_CHANGEINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.SELECT_RY_CHANGEINFO(model);
            }
            else
            {
                HR_RY_CHANGEINFO_SELECT rst = new HR_RY_CHANGEINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE_LB(HR_RY_RYINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.RY_RYINFO.UPDATE_LB(model);
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
