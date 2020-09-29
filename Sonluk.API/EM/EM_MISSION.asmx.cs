using Sonluk.API.Models;
using Sonluk.Entities.EM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.EM
{
    /// <summary>
    /// EM_MISSION 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class EM_MISSION : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public ZSD_XBZ_CHANGEINFORESULT ZSD_XBZ_CHANGEINFO_Read(string MISSION,string token)
        {
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                return rmsmodel.EM_MISSION.ZSD_XBZ_CHANGEINFO_Read(MISSION);
            }
            else
            {
                ZSD_XBZ_CHANGEINFORESULT res = new ZSD_XBZ_CHANGEINFORESULT();
                res.MES_RETURN = new Entities.MES.MES_RETURN();
                res.MES_RETURN.TYPE = "E";
                res.MES_RETURN.MESSAGE = "token is invalid";
                return res;
            }
            
        }
        [WebMethod]
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_Read(ZSD_XBZ_MAINRESULT importList,string token)
        {
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                return rmsmodel.EM_MISSION.ZSD_XBZ_MAIN_Read(importList);
            }
            else
            {
                ZSD_XBZ_MAINRESULT res = new ZSD_XBZ_MAINRESULT();
                res.MES_RETURN = new Entities.MES.MES_RETURN();
                res.MES_RETURN.TYPE = "E";
                res.MES_RETURN.MESSAGE = "token is invalid";
                return res;
            }
            
        }
        [WebMethod]
        public ZSD_XBZ_MAINRESULT ZSD_XBZ_MAIN_UPDATE(ZSD_XBZ_MAINRESULT importList,string token)
        {
            if (rmsmodel.CRM_Login.ValidateToken(token))
            {
                return rmsmodel.EM_MISSION.ZSD_XBZ_MAIN_UPDATE(importList);
            }
            else
            {
                ZSD_XBZ_MAINRESULT res = new ZSD_XBZ_MAINRESULT();
                res.MES_RETURN = new Entities.MES.MES_RETURN();
                res.MES_RETURN.TYPE = "E";
                res.MES_RETURN.MESSAGE = "token is invalid";
                return res;
            }
            
        }
    }
}
