using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KADTDP
    {
        private static readonly ICOST_KADTDP _DataAccess = RMSDataAccess.CreateCOST_KADTDP();

        public int Create(CRM_COST_KADTDP model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KADTDP model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_KADTDP> ReadByParam(CRM_COST_KADTDP model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int DPID)
        {
            return _DataAccess.Delete(DPID);
        }






    }
}
