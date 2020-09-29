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
    /// SY_TYPEMX_CHILD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_TYPEMX_CHILD : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_SY_TYPEMX_CHILD_SELECT SELECT(MES_SY_TYPEMX_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_SY_TYPEMX_CHILD_SELECT rst = mesmodel.SY_TYPEMX_CHILD.SELECT(model);
                rst.MES_RETURN = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst.MES_RETURN, ptoken);
                return rst;
            }
            else
            {
                MES_SY_TYPEMX_CHILD_SELECT rst = new MES_SY_TYPEMX_CHILD_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT(MES_SY_TYPEMX_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX_CHILD.INSERT(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
                return rst;
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE(MES_SY_TYPEMX_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX_CHILD.UPDATE(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
                return rst;
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE(MES_SY_TYPEMX_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX_CHILD.DELETE(model);
                rst = mesmodel.SY_LANGUAGE_RETURN.RETURN_MESSAGE(rst, ptoken);
                return rst;
            }
            else
            {
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return child_MES_RETURN;
            }
        }
    }
}
