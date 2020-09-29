﻿using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// COST_CXHDTC 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_CXHDTC : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_CXHDTC model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDTC.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_CXHDTC model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDTC.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_CXHDTC> ReadByParam(CRM_COST_CXHDTC model, string ptoken)
        {
            List<CRM_COST_CXHDTC> node = new List<CRM_COST_CXHDTC>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDTC.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int TCID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CXHDTC.Delete(TCID);
            }
            return -100;

        }
    }
}
