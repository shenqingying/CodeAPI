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
    /// SY_DEVICE_CONTRACT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_DEVICE_CONTRACT : System.Web.Services.WebService
    {

        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public List<EM_SY_DEVICE_CONTRACT> Read(EM_SY_DEVICE_CONTRACT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_DEVICE_CONTRACT.Read(model).ToList();
            }
            else
            {
                List<EM_SY_DEVICE_CONTRACT> rst = new List<EM_SY_DEVICE_CONTRACT>();
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN Create(EM_SY_DEVICE_CONTRACT model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_DEVICE_CONTRACT.Create(model);
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
        public MES_RETURN DELETE(EM_SY_DEVICE_CONTRACT ID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_DEVICE_CONTRACT.Delete(ID);
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
