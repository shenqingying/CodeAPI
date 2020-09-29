using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KQ_YGQJ
    {
        private static readonly IKQ_YGQJ _DataAccess = RMSDataAccess.CreateKQ_YGQJ();
        public int Create(CRM_KQ_YGQJ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KQ_YGQJ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int YGQJID)
        {
            return _DataAccess.Delete(YGQJID);
        }
        public IList<CRM_KQ_YGQJList> ReadBySTAFFID(int STAFFID, int STATUS)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID,STATUS);
        }

        public int Verify_QJ(string beginTime, string endTime, int STAFFID,int YGQJID, int CCID)
        {
            return _DataAccess.Verify_QJ(beginTime, endTime, STAFFID, YGQJID, CCID);
        }
        public CRM_KQ_YGQJ ReadByYGQJID(int YGQJID)
        {
            return _DataAccess.ReadByYGQJID(YGQJID);
        }
        public IList<CRM_KQ_YGQJList> ReadByDepartRight(CRM_KQ_YGQJ model)
        {
            return _DataAccess.ReadByDepartRight(model);
        }
        public IList<CRM_KQ_YGQJList> Read(CRM_KQ_YGQJ model)
        {
            return _DataAccess.Read(model);
        }
    }
}
