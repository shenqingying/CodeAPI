using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAHXZLMX_LKAHXDJMX
    {

        private static readonly ICOST_LKAHXZLMX_LKAHXDJMX _DataAccess = RMSDataAccess.CreateCOST_LKAHXZLMX_LKAHXDJMX();

        public int Create(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAHXZLMX_LKAHXDJMX> ReadByParam(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(CRM_COST_LKAHXZLMX_LKAHXDJMX model)
        {
            return _DataAccess.Delete(model);
        }
        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            return _DataAccess.DeleteByHXDJMXID(HXDJMXID);
        }






    }
}
