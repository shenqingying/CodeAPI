using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAHXZLMX_KAHXDJMX
    {
        private static readonly ICOST_KAHXZLMX_KAHXDJMX _DataAccess = RMSDataAccess.CreateCOST_KAHXZLMX_KAHXDJMX();


        public int Create(CRM_COST_KAHXZLMX_KAHXDJMX model)
        {
            return _DataAccess.Create(model);
        }

        public IList<CRM_COST_KAHXZLMX_KAHXDJMX> ReadByParam(CRM_COST_KAHXZLMX_KAHXDJMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            return _DataAccess.DeleteByHXDJMXID(HXDJMXID);
        }




    }
}
