using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CXHDPGQD
    {
        private static readonly ICOST_CXHDPGQD _DataAccess = RMSDataAccess.CreateCOST_CXHDPGQD();


        public int Create(CRM_COST_CXHDPGQD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CXHDPGQD model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CXHDPGQD> ReadByParam(CRM_COST_CXHDPGQD model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int PGQDID)
        {
            return _DataAccess.Delete(PGQDID);
        }
        public int DeleteByCXHDID(int CXHDID)
        {
            return _DataAccess.DeleteByCXHDID(CXHDID);
        }






    }
}
