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
    /// PRODUCT_KHGROUP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PRODUCT_KHGROUP : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Create(int KHID, int GROUPID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KHGROUP.Create(KHID, GROUPID);
            }
            return -100;

        }
        [WebMethod]
        public int Delete(int KHID, int GROUPID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KHGROUP.Delete(KHID, GROUPID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_PRODUCT_KHGROUP> Read(CRM_PRODUCT_KHGROUP model, string ptoken)
        {
            List<CRM_PRODUCT_KHGROUP> node = new List<CRM_PRODUCT_KHGROUP>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.PRODUCT_KHGROUP.Read(model).ToList();
            }
            return node;
        }
    }
}
