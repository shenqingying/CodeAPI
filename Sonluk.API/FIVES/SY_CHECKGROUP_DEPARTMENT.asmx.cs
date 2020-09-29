using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Sonluk.API.Models;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
namespace Sonluk.API.FIVES
{
    /// <summary>
    /// SY_CHECKGROUP_DEPARTMENT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_CHECKGROUP_DEPARTMENT : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<FIVES_SY_CHECKGROUP_DEPARTMENT> Read(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKGROUP_DEPARTMENT.Read(model).ToList();
            }
            else
            {
                List<FIVES_SY_CHECKGROUP_DEPARTMENT> rst = new List<FIVES_SY_CHECKGROUP_DEPARTMENT>();
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN Create(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKGROUP_DEPARTMENT.Create(model);
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
        public MES_RETURN UPDATE(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKGROUP_DEPARTMENT.Update(model);
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
        public MES_RETURN DELETE(FIVES_SY_CHECKGROUP_DEPARTMENT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKGROUP_DEPARTMENT.Delete(model);
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
