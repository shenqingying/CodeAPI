using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARTT
    {
        int Create(CRM_COST_LKAYEARTT model);
        int Update(CRM_COST_LKAYEARTT model);
        int UpdateSubmitCount(int LKAYEARTTID);
        int UpdateStatus(CRM_COST_LKAYEARTT model);
        int CheckStatus(int LKAYEARTTID);
        IList<CRM_COST_LKAYEARTT> ReadByParam(CRM_COST_LKAYEARTT model, int STAFFID);
        int Delete(int LKAYEARTTID);
        int Verify(CRM_COST_LKAYEARTT model);
        IList<CRM_COST_LKAYEARTT_JXS> ReportJXS(int LKAYEARTTID);
        IList<CRM_COST_LKAYearReport> Report_TaiZhang(CRM_COST_LKAYearReport model);
        IList<CRM_COST_LKAYEARTT_Report>Report(CRM_COST_LKAYEARTT_Report model);
    }
}
