using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_FI
    {
        private static readonly ICOST_FI _DataAccess = RMSDataAccess.CreateCOST_FI();

        public int Create(CRM_COST_FI model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_FI model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_FI> ReadByParam(CRM_COST_FI model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int CWHSBH)
        {
            return _DataAccess.Delete(CWHSBH);
        }



    }
}
