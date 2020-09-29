using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXDJMX
    {
        int Create(CRM_COST_LKAHXDJMX model);
        int Update(CRM_COST_LKAHXDJMX model);
        IList<CRM_COST_LKAHXDJMX> ReadByParam(CRM_COST_LKAHXDJMX model);
        int Delete(int HXDJMXID);

    }
}
