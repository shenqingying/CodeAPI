using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_GSZCFS
    {
        private static readonly ICOST_GSZCFS _DataAccess = RMSDataAccess.CreateCOST_GSZCFS();


        public int Create(CRM_COST_GSZCFS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_GSZCFS model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_GSZCFS> ReadByParam(CRM_COST_GSZCFS model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int ZCFSID)
        {
            return _DataAccess.Delete(ZCFSID);
        }





    }
}
