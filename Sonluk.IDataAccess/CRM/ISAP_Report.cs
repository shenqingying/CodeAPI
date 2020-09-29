using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonluk.Entities.CRM;

namespace Sonluk.IDataAccess.CRM
{
    public interface ISAP_Report
    {
        IList<SAP_Invoice> Invoice(List<SAP_KH> sapsn, SAP_Invoice_Param model);
        IList<SAP_ReportInfo> AC(string dateStart, string dateEnd, string customer);
        IList<SAP_ReportInfo> SHFH(string customer, string dateStart, string dateEnd);
        IList<SAP_ReportInfo> ZKMX(string customer, string dateStart, string dateEnd);
        string SAP_CPFL(string I_MATNR);
        SAP_RWJDInfo SAP_RWJD(string customer, string year, string dateStart, string dateEnd);
        SAP_RWXSInfo SAP_RWXS(string customer, string dateStart, string dateEnd);
        SAP_RWJD2Info SAP_RWJD2(string customer, string dateStart, string dateEnd, string[] MATNR);
        IList<ZSD_JXSKP> GET_JXSKP(string STARTDATE, string ENDDATE, IList<ZSD_JXSKP> data);
    }
}
