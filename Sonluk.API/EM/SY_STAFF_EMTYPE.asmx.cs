using Sonluk.API.Models;
using Sonluk.Entities.EM;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.EM
{
    /// <summary>
    /// SY_STAFF_EMTYPE 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_STAFF_EMTYPE : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<EM_SY_STAFF_EMTYPE> Read(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_EMTYPE.Read(model).ToList();
            }
            else
            {
                List<EM_SY_STAFF_EMTYPE> rst = new List<EM_SY_STAFF_EMTYPE>();
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN Create(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_EMTYPE.Create(model);
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
        public MES_RETURN UPDATE(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_EMTYPE.Update(model);
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
        public MES_RETURN DELETE(EM_SY_STAFF_EMTYPE model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_EMTYPE.Delete(model);
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
        public EM_SY_EMTYPE_LAY_SELECT SELECT_EMTYPE_ROLE(int STAFFID,string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_STAFF_EMTYPE.SELECT_EMTYPE_ROLE(STAFFID);
            }
            else
            {
                EM_SY_EMTYPE_LAY_SELECT node = new EM_SY_EMTYPE_LAY_SELECT();
                List<EM_SY_EMTYPE_LAY_LIST> n = new List<EM_SY_EMTYPE_LAY_LIST>();
                node.EM_SY_EMTYPE_LAY_LIST = n;
                MES_RETURN rst = new MES_RETURN();
                rst.TYPE = "E";
                rst.MESSAGE = "ptoken不正确，请重新登录！";
                return node;
            }
            
        }
    }
}
