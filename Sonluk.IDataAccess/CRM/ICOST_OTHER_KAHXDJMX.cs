using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_OTHER_KAHXDJMX
    {
        int Create(CRM_COST_OTHER_KAHXDJMX model);
        IList<CRM_COST_OTHER_KAHXDJMX> ReadByParam(CRM_COST_OTHER_KAHXDJMX model);
        int DeleteByHXDJMXID(int HXDJMXID);


    }
}
