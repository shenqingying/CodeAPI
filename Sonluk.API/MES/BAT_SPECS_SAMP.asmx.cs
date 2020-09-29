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
    /// BAT_SPECS_SAMP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BAT_SPECS_SAMP : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public MES_DCCCCYSJ_SELECT SELECT(MES_DCCCCYSJ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS_SAMP.SELECT(model);
            }
            else
            {
                MES_DCCCCYSJ_SELECT rst = new MES_DCCCCYSJ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN INSERT(MES_DCCCCYSJ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS_SAMP.INSERT(model);
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
        public MES_RETURN UPDATE(MES_DCCCCYSJ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS_SAMP.UPDATE(model);
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
        public MES_RETURN DELETE(int RI, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS_SAMP.DELETE(RI);
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
