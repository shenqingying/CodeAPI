using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
 public   class COST_JXSHXDJMX
    {
     private static readonly ICOST_JXSHXDJMX _DataAccess = RMSDataAccess.CreateCOST_JXSHXDJMX();

        public int Create(CRM_COST_JXSHXDJMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_JXSHXDJMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_JXSHXDJMX> ReadByParam(CRM_COST_JXSHXDJMX model)
        {
            return _DataAccess.ReadByParam(model);
        }

        public int Delete(int HXDJMXID)
        {
            return _DataAccess.Delete(HXDJMXID);
        }
    }
}
