using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAXS
    {
        int Create(CRM_COST_KAXS model);
        int Update(CRM_COST_KAXS model);
        IList<CRM_COST_KAXS> ReadByParam(CRM_COST_KAXS model);
        IList<CRM_COST_KAXS> Report(CRM_COST_KAXS model);
        IList<CRM_COST_KAXSReportKP> Report_KP(CRM_COST_KAXSReportKP model);
        IList<CRM_COST_KAXSReportFH> Report_FH(CRM_COST_KAXSReportFH model);
        IList<CRM_COST_KAXSReportMX> Report_MX(CRM_COST_KAXSReportMX model);
        IList<CRM_COST_KAXS_Report_MXFH> Report_MXFH(CRM_COST_KAXS_Report_MXFH model);
        int Delete(int KAXSID);
        IList<CRM_COST_KAXSReport_Compare> Report_Compare(CRM_COST_KAXSReport_Compare model);
    }
}
