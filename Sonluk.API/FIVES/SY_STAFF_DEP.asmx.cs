using Sonluk.API.Models;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.FIVES
{
    /// <summary>
    /// SY_STAFF_DEP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_STAFF_DEP : System.Web.Services.WebService
    {

        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<FIVES_SY_STAFF_DEPList> Read(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.Read(model).ToList();
            }
            else
            {
                List<FIVES_SY_STAFF_DEPList> rst = new List<FIVES_SY_STAFF_DEPList>();
                return rst;
            }
        }
        [WebMethod]
        public List<FIVES_SY_STAFF_DEPList> ReadByDJ(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.ReadByDJ(model).ToList();
            }
            else
            {
                List<FIVES_SY_STAFF_DEPList> rst = new List<FIVES_SY_STAFF_DEPList>();
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN Create(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.Create(model);
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
        public MES_RETURN UPDATE(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.Update(model);
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
        public MES_RETURN DELETE(FIVES_SY_STAFF_DEP model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.Delete(model);
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
        public MES_RETURN Update_All(List<FIVES_SY_STAFF_DEP> model, int staffid, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_DEP.Update_All(model, staffid);
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
