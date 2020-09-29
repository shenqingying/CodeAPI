using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_ITEM
    {
        private static readonly ICOST_ITEM _DataAccess = RMSDataAccess.CreateCOST_ITEM();


        public int Create(CRM_COST_ITEM model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_ITEM model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_ITEM> ReadByParam(CRM_COST_ITEM model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int COSTITEMID)
        {
            return _DataAccess.Delete(COSTITEMID);
        }



    }
}
