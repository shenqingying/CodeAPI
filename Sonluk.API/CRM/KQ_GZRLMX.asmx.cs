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
    /// KQ_GZRLMX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class KQ_GZRLMX : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
         [WebMethod]
        public int Create(CRM_KQ_GZRLMX model,string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRLMX.Create(model);
            }
            return -100;
            
        }
         [WebMethod]
         public int Update(CRM_KQ_GZRLMX model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRLMX.Update(model);
            }
            return -100;
            
        }
         [WebMethod]
         public List<CRM_KQ_GZRLMX> Read(int BBID,string Fromdate,string Todate, string ptoken)
        {
            List<CRM_KQ_GZRLMX> node = new List<CRM_KQ_GZRLMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRLMX.Read(BBID, Fromdate, Todate).ToList();
            }
            return node;
            
        }
        [WebMethod]
         public double CountDaysByGZRLMX(int BBID,string beginTime, string endTime, bool isfullbegin, bool isfullend,string ptoken)
         {
             if (models.CRM_Login.ValidateToken(ptoken))
             {
                 return models.KQ_GZRLMX.CountDaysByGZRLMX(BBID,beginTime, endTime, isfullbegin, isfullend);
             }
             return -100;
             
         }
        [WebMethod]
        public int Delete(int BBID, string DATE_BEGIN, string DATE_END, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.KQ_GZRLMX.Delete(BBID,DATE_BEGIN,DATE_END);
            }
            return -100;
        }
    }
}
