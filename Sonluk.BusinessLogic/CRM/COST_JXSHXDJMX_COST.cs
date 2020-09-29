using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public  class COST_JXSHXDJMX_COST
    {
     private static readonly ICOST_JXSHXDJMX_COST _DataAccess = RMSDataAccess.CreateCOST_JXSHXDJMX_COST();

        public int Create(CRM_COST_JXSHXDJMX_COST model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_JXSHXDJMX_COST model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_JXSHXDJMX_COST> ReadByParam(CRM_COST_JXSHXDJMX_COST model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(CRM_COST_JXSHXDJMX_COST model)
        {
            return _DataAccess.Delete(model);
        }
        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            return _DataAccess.DeleteByHXDJMXID(HXDJMXID);
        }
    }
}
