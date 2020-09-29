using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_GGGS
    {
        private static readonly ICOST_GGGS _DataAccess = RMSDataAccess.CreateCOST_GGGS();

        public int Create(CRM_COST_GGGS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_GGGS model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_GGGS> ReadByParam(CRM_COST_GGGS model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int GGGSID)
        {
            return _DataAccess.Delete(GGGSID);
        }



    }
}
