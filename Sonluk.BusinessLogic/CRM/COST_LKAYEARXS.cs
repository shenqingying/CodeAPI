using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARXS
    {
        private static readonly ICOST_LKAYEARXS _DataAccess = RMSDataAccess.CreateCOST_LKAYEARXS();

        public int Create(CRM_COST_LKAYEARXS model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAYEARXS model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAYEARXS> ReadByParam(CRM_COST_LKAYEARXS model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int XSID)
        {
            return _DataAccess.Delete(XSID);
        }
        public int UpdateSonlukXS(int LKAYEARTTID)
        {
            return _DataAccess.UpdateSonlukXS(LKAYEARTTID);
        }
    }
}
