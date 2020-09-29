using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_CP
    {
        int Create(CRM_COST_CP model);
        int Update(CRM_COST_CP model);
        IList<CRM_COST_CP> ReadByParam(CRM_COST_CP model);
        int Delete(int CPID);
        CRM_COST_CP_YEARDATA ReportYEARData(int LKAYEARTTID, int ISACTIVE);
        IList<CRM_COST_CP_JXSReport> JXSReport(CRM_COST_CP_JXSReport model);

    }
}
