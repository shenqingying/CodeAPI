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
    /// PMM_MOULD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PMM_MOULD : System.Web.Services.WebService
    {
        MESModels mesmodels = new MESModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public MES_PMM_MOULD_SELECT SELECT(MES_PMM_MOULD model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodels.PMM_MOULD.SELECT(model, STAFFID);
            }
            else
            {
                MES_PMM_MOULD_SELECT rst = new MES_PMM_MOULD_SELECT();
                rst.MES_RETURN = new MES_RETURN();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_PMM_MOULD_SELECT SELECT_ALL(MES_PMM_MOULD model, string ptoken)
        {
            int STAFFID = rmsmodel.CRM_Login.ReadSTAFFIDByToken(ptoken);
            if (STAFFID > 0)
            {
                return mesmodels.PMM_MOULD.SELECT_ALL(model, STAFFID);
            }
            else
            {
                MES_PMM_MOULD_SELECT rst = new MES_PMM_MOULD_SELECT();
                rst.MES_RETURN = new MES_RETURN();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN INSERT(MES_PMM_MOULD model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodels.PMM_MOULD.INSERT(model, STAFFID);
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
        public MES_RETURN UPDATE(MES_PMM_MOULD model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodels.PMM_MOULD.UPDATE(model, STAFFID);
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
        public MES_RETURN DELETE(string MID, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodels.PMM_MOULD.DELETE(MID, STAFFID);
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
