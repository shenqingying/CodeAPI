using Sonluk.API.Models;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MES
{
    /// <summary>
    /// WS_MES_FB_QMP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_MES_FB_QMP : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        [WebMethod]
        public MES_RETURN INSERT_ALL(DataSet ds)
        {
            MES_RETURN mr = mesmodel.FB_QMP.INSERT_ALL(ds);
            MES_SY_CCGCRETRUN model_MES_SY_CCGCRETRUN = new MES_SY_CCGCRETRUN();
            model_MES_SY_CCGCRETRUN.LB = 6;
            model_MES_SY_CCGCRETRUN.CCGC = "WS_MES_FB_QMP_INSERT_ALL";
            model_MES_SY_CCGCRETRUN.TYPE = mr.TYPE;
            model_MES_SY_CCGCRETRUN.MESSAGE = "stop" + mr.MESSAGE;
            mesmodel.SY_EXCEPTION.INSERT_CCGC(model_MES_SY_CCGCRETRUN);
            return mr;
        }
        [WebMethod]
        public MES_RETURN SYNC_AUTO_CL()
        {
            return mesmodel.FB_QMP.SYNC_AUTO_CL();
        }
    }
}
