﻿using Sonluk.API.Models;
using Sonluk.Entities.FIVES;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.FIVES
{
    /// <summary>
    /// SY_CHECKPOINT_CHECKDETAIL 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SY_CHECKPOINT_CHECKDETAIL : System.Web.Services.WebService
    {
        RMSModels rmsmodel = new RMSModels();
         [WebMethod]
        public List<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> Read(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT_CHECKDETAIL.Read(model).ToList();
            }
            else
            {
                List<FIVES_SY_CHECKPOINT_CHECKDETAILLIST> rst = new List<FIVES_SY_CHECKPOINT_CHECKDETAILLIST>();
                return rst;
            }
        }
        [WebMethod]
         public MES_RETURN Create(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT_CHECKDETAIL.Create(model);
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
        public MES_RETURN UPDATE(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT_CHECKDETAIL.Update(model);
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
        public MES_RETURN DELETE(FIVES_SY_CHECKPOINT_CHECKDETAIL model, string ptoken)
        {
            if (rmsmodel.CRM_Login.ValidateToken(ptoken))
            {
                return rmsmodel.SY_CHECKPOINT_CHECKDETAIL.Delete(model);
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
