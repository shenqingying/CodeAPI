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
    /// GS_LY 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GS_LY : System.Web.Services.WebService
    {
        HRModels hrmodel = new HRModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(HR_GS_LY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.GS_LY.INSERT(model);
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
        public MES_RETURN UPDATE(HR_GS_LY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.GS_LY.UPDATE(model);
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
        public HR_GS_LY_SELECT SELECT(HR_GS_LY model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.GS_LY.SELECT(model);
            }
            else
            {
                HR_GS_LY_SELECT rst = new HR_GS_LY_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN DELETE(int LYID, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return hrmodel.GS_LY.DELETE(LYID);
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
