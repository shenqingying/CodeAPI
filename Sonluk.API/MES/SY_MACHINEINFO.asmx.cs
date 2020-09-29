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
    /// SY_MACHINEINFO 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_MACHINEINFO : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_SY_MACHINEINFO insert(MES_SY_MACHINEINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_MACHINEINFO.insert(model);
            }
            else
            {
                MES_SY_MACHINEINFO rst = new MES_SY_MACHINEINFO();
                return rst;
            }
        }
        [WebMethod]
        public MES_SY_MACHINEINFO_SELECT SELECT(MES_SY_MACHINEINFO model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_MACHINEINFO.SELECT(model);
            }
            else
            {
                MES_SY_MACHINEINFO_SELECT rst = new MES_SY_MACHINEINFO_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_SY_MACHINEINFO_SELECTBBXX SELECT_BBXX(MES_SY_MACHINEINFO_BBXX model,string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_MACHINEINFO.SELECT_BBXX(model);
            }
            else
            {
                MES_SY_MACHINEINFO_SELECTBBXX rst = new MES_SY_MACHINEINFO_SELECTBBXX();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登陆！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
