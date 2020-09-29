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
    /// MM_CK 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MM_CK : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(MES_MM_CK model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.MM_CK.INSERT(model);
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
        public MES_RETURN UPDATE_SYNC(MES_MM_CK model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.MM_CK.UPDATE_SYNC(model);
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
        public MES_MM_CK_SELECT SELECT(MES_MM_CK model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_MM_CK_SELECT rst = mesmodel.MM_CK.SELECT(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_MM_CK_SELECT SELECT_BY_STAFFID(MES_MM_CK model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_MM_CK_SELECT rst = mesmodel.MM_CK.SELECT_BY_STAFFID(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_MM_CK_SELECT SELECT_BY_ROLE_ASSEMBLE(MES_MM_CK model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_MM_CK_SELECT rst = mesmodel.MM_CK.SELECT_BY_ROLE_ASSEMBLE(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_MM_CK_SELECT rst = new MES_MM_CK_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
