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
    /// COST_KAXS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class COST_KAXS : System.Web.Services.WebService
    {

        RMSModels models = new RMSModels();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public int Create(CRM_COST_KAXS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Create(model);
            }
            return -100;

        }
        [WebMethod]
        public int Update(CRM_COST_KAXS model, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Update(model);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_KAXS> ReadByParam(CRM_COST_KAXS model, string ptoken)
        {
            List<CRM_COST_KAXS> node = new List<CRM_COST_KAXS>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.ReadByParam(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAXSReportMX> Report_MX(CRM_COST_KAXSReportMX model, string ptoken)
        {
            List<CRM_COST_KAXSReportMX> node = new List<CRM_COST_KAXSReportMX>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report_MX(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAXS_Report_MXFH> Report_MXFH(CRM_COST_KAXS_Report_MXFH model, string ptoken)
        {
            List<CRM_COST_KAXS_Report_MXFH> node = new List<CRM_COST_KAXS_Report_MXFH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report_MXFH(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAXS> Report(CRM_COST_KAXS model, string ptoken)
        {
            List<CRM_COST_KAXS> node = new List<CRM_COST_KAXS>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAXSReportKP> Report_KP(CRM_COST_KAXSReportKP model, string ptoken)
        {
            List<CRM_COST_KAXSReportKP> node = new List<CRM_COST_KAXSReportKP>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report_KP(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public List<CRM_COST_KAXSReportFH> Report_FH(CRM_COST_KAXSReportFH model, string ptoken)
        {
            List<CRM_COST_KAXSReportFH> node = new List<CRM_COST_KAXSReportFH>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report_FH(model).ToList();
            }
            return node;

        }
        [WebMethod]
        public int Delete(int KAXSID, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Delete(KAXSID);
            }
            return -100;

        }
        [WebMethod]
        public List<CRM_COST_KAXSReport_Compare> Report_Compare(CRM_COST_KAXSReport_Compare model, string ptoken)
        {
            List<CRM_COST_KAXSReport_Compare> node = new List<CRM_COST_KAXSReport_Compare>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.COST_KAXS.Report_Compare(model).ToList();
            }
            return node;

        }
    }
}
