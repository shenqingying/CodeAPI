using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CXHD
    {
        private static readonly ICOST_CXHD _DataAccess = RMSDataAccess.CreateCOST_CXHD();


        public int Create(CRM_COST_CXHD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CXHD model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CXHD> ReadByParam(CRM_COST_CXHD model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int CXHDID)
        {
            return _DataAccess.Delete(CXHDID);
        }







    }
}
