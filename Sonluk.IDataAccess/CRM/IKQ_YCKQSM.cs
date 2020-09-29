using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_YCKQSM
    {
        int Create(CRM_KQ_YCKQSM model);
        int Update(CRM_KQ_YCKQSM model);
        IList<CRM_KQ_YCKQSMList> ReadBySTAFFID(int STAFFID);
        int Delete(int YCKQID);
        IList<CRM_KQ_YCKQSMList> ReadByParam(CRM_KQ_YCKQSMList model);
        IList<CRM_KQ_YCKQList> Report_YC(int STAFFID, string fromdate, string todate);
        int UpdateStatus(int YCKQID, int ISACTIVE);
    }
}
