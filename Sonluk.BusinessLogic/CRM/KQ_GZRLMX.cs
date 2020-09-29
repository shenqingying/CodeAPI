using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_GZRLMX
    {
        private static readonly IKQ_GZRLMX _DataAccess = RMSDataAccess.CreateKQ_GZRLMX();
        public int Create(CRM_KQ_GZRLMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KQ_GZRLMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_KQ_GZRLMX> Read(int BBID,string Fromdate,string Todate)
        {
            return _DataAccess.Read(BBID, Fromdate, Todate);
        }
        public double CountDaysByGZRLMX(int BBID,string beginTime, string endTime, bool isfullbegin, bool isfullend)
        {
            return _DataAccess.CountDaysByGZRLMX(BBID,beginTime, endTime, isfullbegin, isfullend);
        }
        public int Delete(int BBID, string DATE_BEGIN, string DATE_END)
        {
            return _DataAccess.Delete(BBID, DATE_BEGIN, DATE_END);
        }
    }
}
