using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IKQ_GZRL
    {
        int Create(CRM_KQ_GZRL model);
        int Update(CRM_KQ_GZRL model);
        int Delete(int BBID);
        IList<CRM_KQ_GZRL> Read(string MS, int BBID);
        //CRM_KQ_GZRL ReadByMS(string MS);
        //CRM_KQ_GZRL ReadByBBID(int BBID);
    }
}
