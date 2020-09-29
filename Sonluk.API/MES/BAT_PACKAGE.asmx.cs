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
    /// BAT_PACKAGE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BAT_PACKAGE : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public MES_PD_GD_PACKINFO_SELECT SELECT_LIST(MES_PD_GD_PACKINFO_SEARCH model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_PACKAGE.SELECT_LIST(model, STAFFID);
            }
            else
            {
                MES_PD_GD_PACKINFO_SELECT rst = new MES_PD_GD_PACKINFO_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_PD_GD_PACKINFO SELECT_SINGLE(string GDDH, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_PACKAGE.SELECT_SINGLE(GDDH, STAFFID);
            }
            else
            {
                MES_PD_GD_PACKINFO rst = new MES_PD_GD_PACKINFO();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN COVER(MES_PD_GD_PACKINFO model, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_PACKAGE.COVER(model, STAFFID);
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
        public MES_RETURN DELETE(string GDDH, string ptoken, int STAFFID)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_PACKAGE.DELETE(GDDH, STAFFID);
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
