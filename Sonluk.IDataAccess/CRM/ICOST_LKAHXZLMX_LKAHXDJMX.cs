using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXZLMX_LKAHXDJMX
    {
        int Create(CRM_COST_LKAHXZLMX_LKAHXDJMX model);
        int Update(CRM_COST_LKAHXZLMX_LKAHXDJMX model);
        IList<CRM_COST_LKAHXZLMX_LKAHXDJMX> ReadByParam(CRM_COST_LKAHXZLMX_LKAHXDJMX model);
        int Delete(CRM_COST_LKAHXZLMX_LKAHXDJMX model);
        int DeleteByHXDJMXID(int HXDJMXID);




    }
}
