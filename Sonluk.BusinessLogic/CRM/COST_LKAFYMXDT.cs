using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAFYMXDT
    {
        private static readonly ICOST_LKAFYMXDT _DataAccess = RMSDataAccess.CreateCOST_LKAFYMXDT();

        public int Create(CRM_COST_LKAFYMXDT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAFYMXDT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAFYMXDT> ReadByParam(CRM_COST_LKAFYMXDT model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int LKADTMXID)
        {
            return _DataAccess.Delete(LKADTMXID);
        }
        public IList<CRM_COST_LKAFYMXDT> Read_Unconnected(CRM_COST_LKAFYMXDT model)
        {
            return _DataAccess.Read_Unconnected(model);
        }



    }
}
