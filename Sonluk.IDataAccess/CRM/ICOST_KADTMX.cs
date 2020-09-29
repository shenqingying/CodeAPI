using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface ICOST_KADTMX
    {
        int Create(CRM_COST_KADTMX model);
        int Update(CRM_COST_KADTMX model);
        IList<CRM_COST_KADTMX> ReadByParam(CRM_COST_KADTMX model);
        int Delete(int KADTMXID);

        int Create_CONN(COST_KADTMX_KAHXDJMX model);
        int DeleteByHXDJMXID_CONN(int HXDJMXID);
        IList<CRM_COST_KADTMX> Read_Unconnected_CONN(CRM_COST_KADTMX model);

    }
}
