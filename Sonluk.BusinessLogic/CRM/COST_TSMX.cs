using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_TSMX
    {
        private static readonly ICOST_TSMX _DataAccess = RMSDataAccess.CreateCOST_TSMX();

        public int Create(CRM_COST_TSMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_TSMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_TSMX> ReadByParam(CRM_COST_TSMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int CLFTTID)
        {
            return _DataAccess.Delete(CLFTTID);
        }
    }
}
