using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class CRM_PENDING
    {
        private static readonly ICRM_PENDING _DataAccess = RMSDataAccess.CreateCRM_PENDING();
        public IList<CRM_PENDING_SUMMARY> Read_Summary(int STAFFID)
        {
            return _DataAccess.Read_Summary(STAFFID);
        }
        public IList<CRM_PENDING_DETAIL> Read_Detail(int STAFFID, int SummaryID)
        {
            return _DataAccess.Read_Detail(STAFFID, SummaryID);
        }
    }
}
