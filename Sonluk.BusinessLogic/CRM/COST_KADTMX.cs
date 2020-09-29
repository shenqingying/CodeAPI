using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KADTMX
    {
        private static readonly ICOST_KADTMX _DataAccess = RMSDataAccess.CreateCOST_KADTMX();

        public int Create(CRM_COST_KADTMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KADTMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KADTMX> ReadByParam(CRM_COST_KADTMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int KADTMXID)
        {
            return _DataAccess.Delete(KADTMXID);
        }

        public int Create_CONN(COST_KADTMX_KAHXDJMX model)
        {
            return _DataAccess.Create_CONN(model);
        }

        public int DeleteByHXDJMXID_CONN(int HXDJMXID)
        {
            return _DataAccess.DeleteByHXDJMXID_CONN(HXDJMXID);
        }

        public IList<CRM_COST_KADTMX> Read_Unconnected_CONN(CRM_COST_KADTMX model)
        {
            return _DataAccess.Read_Unconnected_CONN(model);
        }





    }
}
