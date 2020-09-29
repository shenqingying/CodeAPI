using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sonluk.BusinessLogic.CRM
{
    public class SAP_Report
    {
        private static readonly ISAP_Report _SAP_Report_DataAccess = RMSDataAccess.CreateSAP_Report();
        private static readonly IKH_KH _DataAccess = RMSDataAccess.CreateKH_KH();
        KH_KH KH_KHService = new KH_KH();

        public IList<SAP_Invoice> Invoice(int STAFFID, SAP_Invoice_Param model)
        {
            IList<SAP_Invoice> SAP_KH_nodes = new List<SAP_Invoice>();

            List<SAP_KH> sapsn = KH_KHService.ReadKHForSap(STAFFID).ToList();
            return _SAP_Report_DataAccess.Invoice(sapsn, model);
        }

        public IList<SAP_ReportInfo> AC(string customer, string dateStart, string dateEnd)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            CRM_KH_KH KH = _DataAccess.ReadBySAPSN(customer);
            IList<SAP_ReportInfo> data = _SAP_Report_DataAccess.AC(dateStart, dateEnd, customer);
            for (int i = 0; i < data.Count; i++)
            {
                data[i].CustomerName = KH.MC;
            }
            return data;
        }
        public IList<SAP_ReportInfo> SHFH(string customer, string dateStart, string dateEnd)
        {
            customer = Convert.ToDecimal(customer).ToString("0000000000");
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return _SAP_Report_DataAccess.SHFH(customer, dateStart, dateEnd);
        }

        public IList<SAP_ReportInfo> ZKMX(string customer, string dateStart, string dateEnd)
        {

            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return _SAP_Report_DataAccess.ZKMX(customer, dateStart, dateEnd);
        }

        public string SAP_CPFL(string I_MATNR)
        {
            return _SAP_Report_DataAccess.SAP_CPFL(I_MATNR);
        }
        public SAP_RWJDInfo SAP_RWJD(string customer, string year, string dateStart, string dateEnd)
        {
            //year = Regex.Replace(year, @"[^\d]*", "");
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return _SAP_Report_DataAccess.SAP_RWJD(customer, year, dateStart, dateEnd);
        }
        public SAP_RWXSInfo SAP_RWXS(string customer, string dateStart, string dateEnd)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return _SAP_Report_DataAccess.SAP_RWXS(customer, dateStart, dateEnd);
        }
        public SAP_RWJD2Info SAP_RWJD2(string customer, string dateStart, string dateEnd, string[] MATNR)
        {
            dateStart = Regex.Replace(dateStart, @"[^\d]*", "");
            dateEnd = Regex.Replace(dateEnd, @"[^\d]*", "");
            return _SAP_Report_DataAccess.SAP_RWJD2(customer, dateStart, dateEnd, MATNR);
        }
        public IList<ZSD_JXSKP> GET_JXSKP(string STARTDATE, string ENDDATE, IList<ZSD_JXSKP> data)
        {
            STARTDATE = Regex.Replace(STARTDATE, @"[^\d]*", "");
            ENDDATE = Regex.Replace(ENDDATE, @"[^\d]*", "");
            return _SAP_Report_DataAccess.GET_JXSKP(STARTDATE, ENDDATE, data);
        }




    }
}
