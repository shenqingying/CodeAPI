using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IBF_BFDJ
    {
        int Create(CRM_BF_BFDJ model);
        int Update(CRM_BF_BFDJ model);
        int Delete(int BFDJID);
        IList<CRM_BF_BFDJList> Report(CRM_BF_BFDJList model);
        CRM_BF_BFDJ ReadByBFDJID(int BFDJID);
        IList<CRM_BF_REPORTSUMMARY> Report_Summary(CRM_BF_ReportParam model);
        IList<CRM_BF_REPORTDETAIL> Report_Detail(CRM_BF_ReportParam model);
        IList<CRM_BF_BFDJList> Read(CRM_BF_BFDJ_PARAMS model, int isGun);
        IList<CRM_KHDJ_REPORT_SUMMARY> ReadKHBF_BFDJ_SUMMARY(CRM_KHDJ_REPORT_PARAMS model);
        IList<CRM_KHDJ_REPORT_DETAIL> ReadKHBF_BFDJ_DETAIL(CRM_KHDJ_REPORT_PARAMS model);
        IList<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> ReadKHBF_ReportByStaff_SummaryTotal(CRM_BF_REPORT_BYSTAFF_PARAMS model);
        IList<CRM_BF_REPORT_BYSTAFF_SUMMARY> ReadKHBF_ReportByStaff_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model);
        IList<CRM_BF_BFDJList> ReadKHBF_ReportByStaff_Detail(CRM_BF_REPORT_BYSTAFF_PARAMS model);
        DataTable ReadKHBF_ReportByDate_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model);
    }
}
