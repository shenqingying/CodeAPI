using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_KQ_Report
    {
        IList<CRM_KQ_COLLECTList> CRM_KQ_REPORT_SUMMARY(int STAFFID, int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime, int DEPID, int OnlyQQ);
        IList<CRM_KQ_YGQJList> CRM_KQ_Detail_QJ(int STAFFID, string Begintime, string Endtime);
        IList<CRM_KQ_CCTTList> CRM_KQ_Detail_CC(int STAFFID, string Begintime, string Endtime);
        IList<CRM_KQ_YCKQSM> CRM_KQ_Detail_YC(int STAFFID, string Begintime, string Endtime);
        IList<CRM_KQ_QDList> CRM_KQ_Detail_QD(int STAFFID, string Begintime, string Endtime);
        IList<CRM_KQ_QQList> CRM_KQ_Detail_QQ(int STAFFID, string Begintime, string Endtime);
    }
}
