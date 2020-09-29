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
    /// SY_GZZX_SBH 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_GZZX_SBH : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(MES_SY_GZZX_SBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.INSERT(model);
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
        public MES_RETURN DELETE(string SBBH, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.DELETE(SBBH);
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
        public MES_RETURN UPDATE(MES_SY_GZZX_SBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.UPDATE(model);
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
        public List<MES_SY_GZZX_SBH> SELECT(MES_SY_GZZX_SBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.SELECT(model).ToList();
            }
            else
            {
                List<MES_SY_GZZX_SBH> rst = new List<MES_SY_GZZX_SBH>();
                return rst;
            }
        }
        [WebMethod]
        public List<MES_SY_GZZX_SBH> SELECT_BY_STAFFID(MES_SY_GZZX_SBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.SELECT_BY_STAFFID(model).ToList();
            }
            else
            {
                List<MES_SY_GZZX_SBH> rst = new List<MES_SY_GZZX_SBH>();
                return rst;
            }
        }
        [WebMethod]
        public MES_PD_TL_TD_SELECT SELECT_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.SELECT_BY_TDNO(model);
            }
            else
            {
                MES_PD_TL_TD_SELECT rst = new MES_PD_TL_TD_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                return rst;
            }
        }
        [WebMethod]
        public MES_RETURN INSERT_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.INSERT_BY_TDNO(model);
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
        public MES_RETURN DELETE_BY_TDNO(string TDNO, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.DELETE_BY_TDNO(TDNO);
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
        public MES_RETURN UPDATE_BY_TDNO(MES_PD_TL_TD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.UPDATE_BY_TDNO(model);
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
        public MES_SY_GZZX_SBH_SELECT SELECT_LB(MES_SY_GZZX_SBH model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_GZZX_SBH.SELECT_LB(model);
            }
            else
            {
                MES_SY_GZZX_SBH_SELECT rst = new MES_SY_GZZX_SBH_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
