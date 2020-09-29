using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
  public  interface ICOST_JXSHXDJMX_COST
    {
        int Create(CRM_COST_JXSHXDJMX_COST model);
        int Update(CRM_COST_JXSHXDJMX_COST model);
        IList<CRM_COST_JXSHXDJMX_COST> ReadByParam(CRM_COST_JXSHXDJMX_COST model);
     
        int Delete(CRM_COST_JXSHXDJMX_COST model);
        int DeleteByHXDJMXID(int HXDJMXID);
    }
}
