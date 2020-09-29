using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARCOST_LKAHXZLMX
    {
        private static readonly ICOST_LKAYEARCOST_LKAHXZLMX _DataAccess = RMSDataAccess.CreateCOST_LKAYEARCOST_LKAHXZLMX();

        public int Create(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByParam(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_LKAYEARCOST_LKAHXZLMX> ReadByTTID(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            return _DataAccess.ReadByTTID(model);
        }
        public int Delete(CRM_COST_LKAYEARCOST_LKAHXZLMX model)
        {
            return _DataAccess.Delete(model);
        }
        public int DeleteByHXZLMXID(int HXZLMXID)
        {
            return _DataAccess.DeleteByHXZLMXID(HXZLMXID);
        }

    }
}
