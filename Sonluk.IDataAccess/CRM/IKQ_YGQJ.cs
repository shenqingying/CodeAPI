using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_YGQJ
    {
        int Create(CRM_KQ_YGQJ model);
        int Update(CRM_KQ_YGQJ model);
        int Delete(int YGQJID);
        IList<CRM_KQ_YGQJList> ReadBySTAFFID(int STAFFID, int STATUS);

        int Verify_QJ(string beginTime, string endTime, int STAFFID,int YGQJID, int CCID);
        CRM_KQ_YGQJ ReadByYGQJID(int YGQJID);
        IList<CRM_KQ_YGQJList> ReadByDepartRight(CRM_KQ_YGQJ model);
        IList<CRM_KQ_YGQJList> Read(CRM_KQ_YGQJ model);
    }
}
