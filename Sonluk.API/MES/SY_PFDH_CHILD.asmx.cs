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
    /// SY_PFDH_CHILD 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_PFDH_CHILD : System.Web.Services.WebService
    {
        MESModels mesmodel = new MESModels();
        RMSModels rmsmodel = new RMSModels();
        [WebMethod]
        public MES_RETURN INSERT(MES_SY_PFDH_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PFDH_CHILD.INSERT(model);
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
        public MES_RETURN INSERT_LIST(List<MES_SY_PFDH_CHILD> model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PFDH_CHILD.INSERT_LIST(model);
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
        public MES_RETURN DELETE(MES_SY_PFDH_CHILD model, int LB, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PFDH_CHILD.DELETE(model, LB);
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
        public MES_SY_PFDH_CHILD_SELECT SELECT(MES_SY_PFDH_CHILD model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return mesmodel.SY_PFDH_CHILD.SELECT(model);
            }
            else
            {
                MES_SY_PFDH_CHILD_SELECT rst = new MES_SY_PFDH_CHILD_SELECT();
                MES_RETURN child_MES_RETURN = new MES_RETURN();
                child_MES_RETURN.TYPE = "E";
                child_MES_RETURN.MESSAGE = "ptoken不正确，请重新登录！";
                rst.MES_RETURN = child_MES_RETURN;
                return rst;
            }
        }
    }
}
