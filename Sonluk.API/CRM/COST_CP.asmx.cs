using Sonluk.API.Models;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sonluk.API.CRM
{
    /// <summary>
    /// COST_CP 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_CP : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_CP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_CP model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_CP> ReadByParam(CRM_COST_CP model, string ptoken)
        {
            List<CRM_COST_CP> node = new List<CRM_COST_CP>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int CPID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.Delete(CPID);
            }
            return -100;

        }
        [WebMethod]
        public CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE, string ptoken)
        {
            CRM_COST_CP_YEARDATA node = new CRM_COST_CP_YEARDATA();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.ReportYEARData(LKAYEARTTID, ISACTIVE);
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_CP_JXSReport> JXSReport(CRM_COST_CP_JXSReport model, string ptoken)
        {
            List<CRM_COST_CP_JXSReport> node = new List<CRM_COST_CP_JXSReport>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_CP.JXSReport(model).ToList();
            }
            return node;
        }





    }
}
