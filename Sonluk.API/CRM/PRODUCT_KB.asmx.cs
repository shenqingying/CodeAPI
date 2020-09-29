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
    /// PRODUCT_KB 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_KB : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_PRODUCT_KB model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KB.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_PRODUCT_KB model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KB.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_PRODUCT_KB> ReadByParam(CRM_PRODUCT_KB model, string ptoken)
        {
            List<CRM_PRODUCT_KB> node = new List<CRM_PRODUCT_KB>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KB.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int KHID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KB.Delete(KHID);
            }
            return -100;

        }
    }
}
