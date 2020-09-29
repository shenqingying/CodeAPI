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
    /// SY_TYPEMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_TYPEMX : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<MES_SY_TYPEMXLIST> SELECT(MES_SY_TYPEMX model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_TYPEMX.SELECT(model).ToList();
            }
            else
            {
                List<MES_SY_TYPEMXLIST> rst = new List<MES_SY_TYPEMXLIST>();
                return rst;
            }
        }
        [WebMethod]
        public List<MES_SY_TYPEMXLIST> SELECT_NOPTOKEN(MES_SY_TYPEMX model)
        {
            return mesmodel.SY_TYPEMX.SELECT(model).ToList();
        }
        [WebMethod]
        public MES_RETURN INSERT(MES_SY_TYPEMX model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX.INSERT(model);
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
        public MES_RETURN UPDATE(MES_SY_TYPEMX model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX.UPDATE(model);
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
        public MES_RETURN DELETE(int ID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                MES_RETURN rst = mesmodel.SY_TYPEMX.DELETE(ID);
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
        public List<MES_SY_TYPEMXLIST> SELECT_SBFL_BY_GZZX(string GC, string GZZXBH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_TYPEMX.SELECT_SBFL_BY_GZZX(GC, GZZXBH).ToList();
            }
            else
            {
                List<MES_SY_TYPEMXLIST> rst = new List<MES_SY_TYPEMXLIST>();
                return rst;
            }
        }
    }
}
