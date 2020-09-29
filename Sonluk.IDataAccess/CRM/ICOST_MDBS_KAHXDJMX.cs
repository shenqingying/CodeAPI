using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_MDBS_KAHXDJMX
    {
        int Create(CRM_COST_MDBS_KAHXDJMX model);
        IList<CRM_COST_MDBS_KAHXDJMX> ReadByParam(CRM_COST_MDBS_KAHXDJMX model);
        int DeleteByHXDJMXID(int HXDJMXID);


    }
}
