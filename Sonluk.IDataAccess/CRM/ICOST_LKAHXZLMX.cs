using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_LKAHXZLMX
    {
        int Create(CRM_COST_LKAHXZLMX model);
        int Update(CRM_COST_LKAHXZLMX model);
        IList<CRM_COST_LKAHXZLMX> ReadByParam(CRM_COST_LKAHXZLMX model);
        IList<CRM_COST_LKAHXZLMX> ReadByTTID(int HXZLTTID);
        int Delete(int HXZLMXID);
        int DeleteByLKAFYTTID(int LKAFYTTID);

        CRM_COST_LKAHXZLMX ReadMXinfo(CRM_COST_LKAHXZLMX model, string HTYEAR, int LKAID);
        IList<CRM_COST_LKAHXZLMX> Read_Unconnected(CRM_COST_LKAHXZLMX model);
        CRM_COST_LKAHXZLMX Read_CostTime(CRM_COST_LKAHXZLMX model);

    }
}
