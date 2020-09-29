using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_GZRLMX
    {
        int Create(CRM_KQ_GZRLMX model);
        int Update(CRM_KQ_GZRLMX model);
        IList<CRM_KQ_GZRLMX> Read(int BBID, string Fromdate, string Todate);
        double CountDaysByGZRLMX(int BBID,string beginTime, string endTime, bool isfullbegin, bool isfullend);
        int Delete(int BBID, string DATE_BEGIN, string DATE_END);
    }
}
