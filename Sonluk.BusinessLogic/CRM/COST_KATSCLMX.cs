using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KATSCLMX
    {
        private static readonly ICOST_KATSCLMX _DataAccess = RMSDataAccess.CreateCOST_KATSCLMX();


        public int Create(CRM_COST_KATSCLMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KATSCLMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KATSCLMX> ReadByParam(CRM_COST_KATSCLMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_KATSCLMX> Read_Unconnected(CRM_COST_KATSCLMX model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public int Delete(int KATSCLMXID)
        {
            return _DataAccess.Delete(KATSCLMXID);
        }

        public int Create_CONN(COST_KATSCLMX_KAHXDJMX model)
        {
            return _DataAccess.Create_CONN(model);
        }

        public IList<CRM_COST_KATSCLMX> Read_Unconnected_CONN(CRM_COST_KATSCLMX model)
        {
            return _DataAccess.Read_Unconnected_CONN(model);
        }

        public int DeleteByHXDJMXID(int HXDJMXID)
        {
            return _DataAccess.DeleteByHXDJMXID(HXDJMXID);
        }



    }
}
