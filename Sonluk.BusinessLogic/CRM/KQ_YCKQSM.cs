using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_YCKQSM
    {
        private static readonly IKQ_YCKQSM _DataAccess = RMSDataAccess.CreateKQ_YCKQSM();
        public int Create(CRM_KQ_YCKQSM model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KQ_YCKQSM model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_KQ_YCKQSMList> ReadBySTAFFID(int STAFFID)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID);
        }
        public int Delete(int YCKQID)
        {
            return _DataAccess.Delete(YCKQID);
        }
        public IList<CRM_KQ_YCKQList> Report_YC(int STAFFID, string fromdate, string todate)
        {
            return _DataAccess.Report_YC(STAFFID, fromdate, todate);
        }
        public IList<CRM_KQ_YCKQSMList> ReadByParam(CRM_KQ_YCKQSMList model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int UpdateStatus(int YCKQID, int ISACTIVE)
        {
            return _DataAccess.UpdateStatus(YCKQID, ISACTIVE);
        }
    }
}
