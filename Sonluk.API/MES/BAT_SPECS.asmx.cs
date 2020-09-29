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
    /// BAT_SPECS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class BAT_SPECS : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();

        [WebMethod]
        public MES_DCBZ_SELECT SELECT_SPECS_FULL(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.SELECT_SPECS_FULL(model);
            }
            else
            {
                MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_DCBZ_SELECT SELECT_LIST(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.SELECT_LIST(model);
            }
            else
            {
                MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_DCBZ_SELECT SELECT_LIST_LEFT(string DCXH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.SELECT_LIST_LEFT(DCXH);
            }
            else
            {
                MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN INSERT_FULL(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.INSERT_FULL(model);
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
        public MES_RETURN UPDATE(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.UPDATE(model);
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
        public MES_RETURN DELETE(string DCXH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.DELETE(DCXH);
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
        public MES_DCBZ_SELECT SELECT_SPECS(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.SELECT_SPECS(model);
            }
            else
            {
                MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_DCBZ_SELECT SELECT_PERFOR(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.SELECT_PERFOR(model);
            }
            else
            {
                MES_DCBZ_SELECT rst = new MES_DCBZ_SELECT();
                rst.MES_RETURN.TYPE = "E";
                rst.MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }

        [WebMethod]
        public MES_RETURN INSERT_SPECS(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.INSERT_SPECS(model);
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
        public MES_RETURN INSERT_PERFOR(MES_DCBZ model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.BAT_SPECS.INSERT_PERFOR(model);
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
