using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICRM_PENDING
    {
        IList<CRM_PENDING_SUMMARY> Read_Summary(int STAFFID);
        IList<CRM_PENDING_DETAIL> Read_Detail(int STAFFID, int SummaryID);
    }
}
