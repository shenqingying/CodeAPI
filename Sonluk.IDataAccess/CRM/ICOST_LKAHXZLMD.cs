using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXZLMD
    {
        int Create(CRM_COST_LKAHXZLMD model);
        int Update(CRM_COST_LKAHXZLMD model);
        IList<CRM_COST_LKAHXZLMD> ReadByParam(CRM_COST_LKAHXZLMD model);
        int Delete(int HXZLMDMXID);

    }
}
