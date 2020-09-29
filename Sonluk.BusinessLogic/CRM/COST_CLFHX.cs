using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CLFHX
    {
        private static readonly ICOST_CLFHX _DataAccess = RMSDataAccess.CreateCOST_CLFHX();

        public int Create(CRM_COST_CLFHX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CLFHX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CLFHX> ReadByParam(CRM_COST_CLFHX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int CLFHXID)
        {
            return _DataAccess.Delete(CLFHXID);
        }
    }
}
