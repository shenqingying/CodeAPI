﻿using Sonluk.API.Models;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.MES
{
    /// <summary>
    /// WS_MES_ZS_SY_CLPB 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WS_MES_ZS_SY_CLPB : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(MES_ZS_SY_CLPB model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.INSERT(model);
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
        public MES_RETURN UPDATE(MES_ZS_SY_CLPB model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.UPDATE(model);
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
        public MES_ZS_SY_CLPB_SELECT SELECT(MES_ZS_SY_CLPB model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.SELECT(model);
            }
            else
            {
                MES_ZS_SY_CLPB_SELECT rst = new MES_ZS_SY_CLPB_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.INSERT_WL(model);
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
        public MES_RETURN UPDATE_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.UPDATE_WL(model);
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
        public MES_ZS_SY_CLPB_WL_SELECT SELECT_WL(MES_ZS_SY_CLPB_WL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.ZS_SY_CLPB.SELECT_WL(model);
            }
            else
            {
                MES_ZS_SY_CLPB_WL_SELECT rst = new MES_ZS_SY_CLPB_WL_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
