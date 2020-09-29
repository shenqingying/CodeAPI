using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class BF_BF
    {
        private static readonly IBF_BFDJ _DataAccess_BFDJ = RMSDataAccess.CreateBF_BFDJ();
        private static readonly IBF_BFJH _DataAccess_BFJH = RMSDataAccess.CreateBF_BFJH();
        public int Create_BFDJ(CRM_BF_BFDJ model)
        {
            return _DataAccess_BFDJ.Create(model);
        }
        public int Update_BFDJ(CRM_BF_BFDJ model)
        {
            return _DataAccess_BFDJ.Update(model);
        }
        public int Delete_BFDJ(int BFDJID)
        {
            return _DataAccess_BFDJ.Delete(BFDJID);
        }

        public int Create_BFJH(CRM_BF_BFJH model)
        {
            return _DataAccess_BFJH.Create(model);
        }
        public int Update_BFJH(CRM_BF_BFJH model)
        {
            return _DataAccess_BFJH.Update(model);
        }
        public int Delete_BFJH(int BFJHID)
        {
            return _DataAccess_BFJH.Delete(BFJHID);
        }
        //public IList<CRM_BF_BFJHList> Report_BFJH(CRM_BF_BFJH model)
        //{
        //    return _DataAccess_BFJH.Report(model);
        //}
        public IList<CRM_BF_STAFFList> Report_STAFF(CRM_BF_STAFFList model)
        {
            return _DataAccess_BFJH.Report_STAFF(model);
        }
        public IList<CRM_BF_KHList> Report_KH(CRM_BF_KHList model)
        {
            return _DataAccess_BFJH.Report_KH(model);
        }
        public IList<CRM_BF_BFDJList> Report(CRM_BF_BFDJList model)
        {
            return _DataAccess_BFDJ.Report(model);
        }
        public CRM_BF_BFDJ ReadByBFDJID(int BFDJID)
        {
            return _DataAccess_BFDJ.ReadByBFDJID(BFDJID);
        }

        public IList<CRM_BF_REPORTSUMMARY> Report_Summary(CRM_BF_ReportParam model)
        {
            return _DataAccess_BFDJ.Report_Summary(model);
        }
        public IList<CRM_BF_REPORTDETAIL> Report_Detail(CRM_BF_ReportParam model)
        {
            return _DataAccess_BFDJ.Report_Detail(model);
        }
        public IList<CRM_BF_BFJHList> Read_BFJHByParams(int BFLX, string BFJHMC, string FROMDATE, string TODATE, int STAFFID)
        {
            return _DataAccess_BFJH.ReadByParams(BFLX, BFJHMC, FROMDATE, TODATE,STAFFID);
        }
        public CRM_BF_BFJH Read_BFJDByID(int BFJHID)
        {
            return _DataAccess_BFJH.ReadByID(BFJHID);
        }
        public IList<CRM_BF_BFDJList> Read(CRM_BF_BFDJ_PARAMS model, int isGun)
        {
            return _DataAccess_BFDJ.Read(model,isGun);
        }
        public IList<CRM_KHDJ_REPORT_SUMMARY> ReadKHBF_BFDJ_SUMMARY(CRM_KHDJ_REPORT_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_BFDJ_SUMMARY(model);
        }
        public IList<CRM_KHDJ_REPORT_DETAIL> ReadKHBF_BFDJ_DETAIL(CRM_KHDJ_REPORT_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_BFDJ_DETAIL(model);
        }
        public IList<CRM_BF_REPORT_BYSTAFF_SUMMARYTOTAL> ReadKHBF_ReportByStaff_SummaryTotal(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_ReportByStaff_SummaryTotal(model);
        }
        public IList<CRM_BF_REPORT_BYSTAFF_SUMMARY> ReadKHBF_ReportByStaff_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_ReportByStaff_Summary(model);
        }
        public IList<CRM_BF_BFDJList> ReadKHBF_ReportByStaff_Detail(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_ReportByStaff_Detail(model);
        }
        public DataTable ReadKHBF_ReportByDate_Summary(CRM_BF_REPORT_BYSTAFF_PARAMS model)
        {
            return _DataAccess_BFDJ.ReadKHBF_ReportByDate_Summary(model);
        }
    }
}
