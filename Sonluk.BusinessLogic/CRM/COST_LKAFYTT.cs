using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAFYTT
    {
        private static readonly ICOST_LKAFYTT _DataAccess = RMSDataAccess.CreateCOST_LKAFYTT();

        public int Create(CRM_COST_LKAFYTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAFYTT model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAFYTT> ReadByParam(CRM_COST_LKAFYTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int LKAFYTTID)
        {
            return _DataAccess.Delete(LKAFYTTID);
        }
        public int UpdateCost(int LKAFYTTID)
        {
            return _DataAccess.UpdateCost(LKAFYTTID);
        }



    }
}
