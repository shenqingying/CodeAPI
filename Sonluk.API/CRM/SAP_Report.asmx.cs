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
    /// SAP_Report 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class SAP_Report : System.Web.Services.WebService
    {
        RMSModels models = new RMSModels();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<SAP_Invoice> Invoice(int STAFFID, SAP_Invoice_Param model, string ptoken)
        {
            List<SAP_Invoice> node = new List<SAP_Invoice>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SAP_Report.Invoice(STAFFID, model).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<SAP_ReportInfo> AC(string customer, string dateStart, string dateEnd, string ptoken)
        {
            List<SAP_ReportInfo> node = new List<SAP_ReportInfo>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SAP_Report.AC(customer, dateStart, dateEnd).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<SAP_ReportInfo> SHFH(string customer, string dateStart, string dateEnd, string ptoken)
        {
            List<SAP_ReportInfo> node = new List<SAP_ReportInfo>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SAP_Report.SHFH(customer, dateStart, dateEnd).ToList();
            }
            return node;
        }

        [WebMethod]
        public List<SAP_ReportInfo> ZKMX(string customer, string dateStart, string dateEnd, string ptoken)
        {
            List<SAP_ReportInfo> node = new List<SAP_ReportInfo>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SAP_Report.ZKMX(customer, dateStart, dateEnd).ToList();
            }
            return node;
        }


        [WebMethod]
        public string SAP_CPFL(string I_MATNR, string ptoken)
        {
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                string SAP_CPFL = models.SAP_Report.SAP_CPFL(I_MATNR);
                return SAP_CPFL;

            }
            return "-100";
        }

        [WebMethod]
        public SAP_RWJDInfo SAP_RWJD(string customer, string year, string dateStart, string dateEnd, string ptoken)
        {
            SAP_RWJDInfo node = new SAP_RWJDInfo();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                node = models.SAP_Report.SAP_RWJD(customer, year, dateStart, dateEnd);
            }
            return node;
        }

        [WebMethod]
        public SAP_RWXSInfo SAP_RWXS(string customer, string dateStart, string dateEnd, string ptoken)
        {
            SAP_RWXSInfo node = new SAP_RWXSInfo();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                node = models.SAP_Report.SAP_RWXS(customer, dateStart, dateEnd);
            }
            return node;
        }
        [WebMethod]
        public SAP_RWJD2Info SAP_RWJD2(string customer, string dateStart, string dateEnd, string[] MATNR, string ptoken)
        {
            SAP_RWJD2Info node = new SAP_RWJD2Info();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                node = models.SAP_Report.SAP_RWJD2(customer, dateStart, dateEnd, MATNR);
            }
            return node;
        }
        [WebMethod]
        public List<ZSD_JXSKP> GET_JXSKP(string STARTDATE, string ENDDATE, List<ZSD_JXSKP> data, string ptoken)
        {
            List<ZSD_JXSKP> node = new List<ZSD_JXSKP>();
            if (models.CRM_Login.ValidateToken(ptoken))
            {
                return models.SAP_Report.GET_JXSKP(STARTDATE, ENDDATE, data).ToList();
            }
            return node;
        }

    }
}
