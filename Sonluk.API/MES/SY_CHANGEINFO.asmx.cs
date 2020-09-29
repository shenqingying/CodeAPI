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
    /// SY_CHANGEINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_CHANGEINFO : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_SY_CHANGEINFO_SELECT SELECT(MES_SY_CHANGEINFOLIST model,string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_CHANGEINFO.SELECT(model);
            }
            else
            {
                MES_SY_CHANGEINFO_SELECT rst = new MES_SY_CHANGEINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        //public  SELECT_LAY(int STAFFID, string ptoken)
        //{
        //    if (rmsmodel.CRM_Login.ValidateToken(ptoken))
        //    {
        //        return mesmodel.SY_GC.SELECT_LAY(STAFFID);
        //    }
        //    else
        //    {
        //        MES_SY_GC_LAY_SELECT rst = new MES_SY_GC_LAY_SELECT();
        //        MES_RETURN child_MES_RETURN = new MES_RETURN();
        //        child_MES_RETURN.TYPE = "E";
        //        child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
        //        rst.MES_RETURN = child_MES_RETURN;
        //        return rst;
        //    }
        //}
      
    }
}
