﻿using Sonluk.API.Models;
using Sonluk.Entities.HR;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.HR
{
    /// <summary>
    /// WS_HR_XZGL_FLDATZMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_HR_XZGL_FLDATZMX : System.Web.Services.WebService
    {
        HRModels hrmodel = new HRModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public HR_XZGL_FLDATZMX_SELECT_REPORT SELECT_REPORT(HR_XZGL_FLDATZMX model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.XZGL_FLDATZMX.SELECT_REPORT(model);
            }
            else
            {
                HR_XZGL_FLDATZMX_SELECT_REPORT rst = new HR_XZGL_FLDATZMX_SELECT_REPORT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public HR_XZGL_FLDATZMX_SELECT SELECT(HR_XZGL_FLDATZMX model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.XZGL_FLDATZMX.SELECT(model);
            }
            else
            {
                HR_XZGL_FLDATZMX_SELECT rst = new HR_XZGL_FLDATZMX_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN UPDATE(HR_XZGL_FLDATZMX model, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.XZGL_FLDATZMX.UPDATE(model, LB);
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