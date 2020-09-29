using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAXS
    {
        private static readonly ICOST_KAXS _DataAccess = RMSDataAccess.CreateCOST_KAXS();

        public int Create(CRM_COST_KAXS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAXS model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KAXS> ReadByParam(CRM_COST_KAXS model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_KAXSReportMX> Report_MX(CRM_COST_KAXSReportMX model)
        {
            return _DataAccess.Report_MX(model);
        }
        public IList<CRM_COST_KAXS_Report_MXFH> Report_MXFH(CRM_COST_KAXS_Report_MXFH model)
        {
            return _DataAccess.Report_MXFH(model);
        }
        public IList<CRM_COST_KAXS> Report(CRM_COST_KAXS model)
        {
            return _DataAccess.Report(model);
        }
        public IList<CRM_COST_KAXSReportKP> Report_KP(CRM_COST_KAXSReportKP model)
        {
            return _DataAccess.Report_KP(model);
        }
        public IList<CRM_COST_KAXSReportFH> Report_FH(CRM_COST_KAXSReportFH model)
        {
            return _DataAccess.Report_FH(model);
        }
        public int Delete(int KAXSID)
        {
            return _DataAccess.Delete(KAXSID);
        }
        public IList<CRM_COST_KAXSReport_Compare> Report_Compare(CRM_COST_KAXSReport_Compare model)
        {
            return _DataAccess.Report_Compare(model);
        }
    }
}
