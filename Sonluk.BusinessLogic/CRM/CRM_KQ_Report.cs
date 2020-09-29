using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_KQ_Report
    {
        private static readonly ICRM_KQ_Report _DetaAccess = RMSDataAccess.CreateCRM_KQ_Report();
        public IList<CRM_KQ_COLLECTList> CRM_KQ_REPORT_SUMMARY(int STAFFID, int STAFFLX, string STAFFNAME, string STAFFNO, string beginTime, string endTime, int DEPID, int OnlyQQ)
        {
            return _DetaAccess.CRM_KQ_REPORT_SUMMARY(STAFFID,STAFFLX, STAFFNAME, STAFFNO, beginTime, endTime, DEPID,OnlyQQ);
        }
        public IList<CRM_KQ_YGQJList> CRM_KQ_Detail_QJ(int STAFFID, string Begintime, string Endtime)
        {
            return _DetaAccess.CRM_KQ_Detail_QJ(STAFFID, Begintime, Endtime);
        }
        public IList<CRM_KQ_CCTTList> CRM_KQ_Detail_CC(int STAFFID, string Begintime, string Endtime)
        {
            return _DetaAccess.CRM_KQ_Detail_CC(STAFFID, Begintime, Endtime);
        }
        public IList<CRM_KQ_YCKQSM> CRM_KQ_Detail_YC(int STAFFID, string Begintime, string Endtime)
        {
            return _DetaAccess.CRM_KQ_Detail_YC(STAFFID, Begintime, Endtime);
        }
        public IList<CRM_KQ_QDList> CRM_KQ_Detail_QD(int STAFFID, string Begintime, string Endtime)
        {
            return _DetaAccess.CRM_KQ_Detail_QD(STAFFID, Begintime, Endtime);
        }
        public IList<CRM_KQ_QQList> CRM_KQ_Detail_QQ(int STAFFID, string Begintime, string Endtime)
        {
            return _DetaAccess.CRM_KQ_Detail_QQ(STAFFID, Begintime, Endtime);
        }
    }
}
