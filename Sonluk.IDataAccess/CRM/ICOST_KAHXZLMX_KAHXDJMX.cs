using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KAHXZLMX_KAHXDJMX
    {
        int Create(CRM_COST_KAHXZLMX_KAHXDJMX model);
        IList<CRM_COST_KAHXZLMX_KAHXDJMX> ReadByParam(CRM_COST_KAHXZLMX_KAHXDJMX model);
        int DeleteByHXDJMXID(int HXDJMXID);


    }
}
