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
    /// COST_LKAYEARTT 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_LKAYEARTT : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Create(CRM_COST_LKAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_LKAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public int UpdateStatus(CRM_COST_LKAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.UpdateStatus(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_LKAYEARTT> ReadByParam(CRM_COST_LKAYEARTT model, int STAFFID, string ptoken)
        {
            List<CRM_COST_LKAYEARTT> node = new List<CRM_COST_LKAYEARTT>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.ReadByParam(model, STAFFID).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int LKAYEARTTID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Delete(LKAYEARTTID);
            }
            return -100;

        }
        [WebMethod]
        public int Verify(CRM_COST_LKAYEARTT model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Verify(model);
            }
            return -100;
        }
        [WebMethod]
        public List<CRM_COST_LKAYEARTT_JXS> ReportJXS(int LKAYEARTTID, string ptoken)
        {
            List<CRM_COST_LKAYEARTT_JXS> node = new List<CRM_COST_LKAYEARTT_JXS>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.ReportJXS(LKAYEARTTID).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_LKAYearReport> Report_TaiZhang(CRM_COST_LKAYearReport model, string ptoken)
        {
            List<CRM_COST_LKAYearReport> node = new List<CRM_COST_LKAYearReport>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Report_TaiZhang(model).ToList();
            }
            return node;
        }
        [WebMethod]
        public List<CRM_COST_LKAYEARTT_Report> Report(CRM_COST_LKAYEARTT_Report model, string ptoken)
        {
            List<CRM_COST_LKAYEARTT_Report> node = new List<CRM_COST_LKAYEARTT_Report>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_LKAYEARTT.Report(model).ToList();
            }
            return node;
        }



    }
}
