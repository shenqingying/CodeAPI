using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAYEARCOST_LKAHXZLMX
    {
        int Create(CRM_COST_LKAYEARCOST_LKAHXZLMX model);
        int Update(CRM_COST_LKAYEARCOST_LKAHXZLMX model);
        IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByParam(CRM_COST_LKAYEARCOST_LKAHXZLMX model);
        IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByTTID(CRM_COST_LKAYEARCOST_LKAHXZLMX model);
        int Delete(CRM_COST_LKAYEARCOST_LKAHXZLMX model);
        int DeleteByHXZLMXID(int HXZLMXID);



    }
}
