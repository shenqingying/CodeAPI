using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKADTDP
    {
        private static readonly ICOST_LKADTDP _DataAccess = RMSDataAccess.CreateCOST_LKADTDP();

        public int Create(CRM_COST_LKADTDP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKADTDP model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKADTDP> ReadByParam(CRM_COST_LKADTDP model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int DPID)
        {
            return _DataAccess.Delete(DPID);
        }






    }
}
