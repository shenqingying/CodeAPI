using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KATSCLMX
    {
        int Create(CRM_COST_KATSCLMX model);
        int Update(CRM_COST_KATSCLMX model);
        IList<CRM_COST_KATSCLMX> ReadByParam(CRM_COST_KATSCLMX model);
        IList<CRM_COST_KATSCLMX> Read_Unconnected(CRM_COST_KATSCLMX model);
        int Delete(int KATSCLMXID);

        int Create_CONN(COST_KATSCLMX_KAHXDJMX model);
        IList<CRM_COST_KATSCLMX> Read_Unconnected_CONN(CRM_COST_KATSCLMX model);
        int DeleteByHXDJMXID(int HXDJMXID);

    }
}
