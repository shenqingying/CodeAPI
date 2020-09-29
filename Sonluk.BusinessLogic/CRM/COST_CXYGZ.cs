using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CXYGZ
    {
        private static readonly ICOST_CXYGZ _DataAccess = RMSDataAccess.CreateCOST_CXYGZ();

        public int Create(CRM_COST_CXYGZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CXYGZ model)
        {
            return _DataAccess.Update(model);
        }
        public int AddPrintCount(int CXYGZID)
        {
            return _DataAccess.AddPrintCount(CXYGZID);
        }
        public IList<CRM_COST_CXYGZ> ReadByParam(CRM_COST_CXYGZ model)
        {
            return _DataAccess.ReadByParam(model);
        }

        public int Delete(int CXYGZID)
        {
            return _DataAccess.Delete(CXYGZID);
        }
    }
}
