using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAYEARCOST
    {
        private static readonly ICOST_LKAYEARCOST _DataAccess = RMSDataAccess.CreateCOST_LKAYEARCOST();

        public int Create(CRM_COST_LKAYEARCOST model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAYEARCOST model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateSPJE(CRM_COST_LKAYEARCOST model)
        {
            return _DataAccess.UpdateSPJE(model);
        }
        public IList<CRM_COST_LKAYEARCOST> ReadByParam(CRM_COST_LKAYEARCOST model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int COSTID)
        {
            return _DataAccess.Delete(COSTID);
        }
        public IList<CRM_COST_LKAYEARCOST> ReadCOSTByKHID(int KHID, string YEAR)
        {
            return _DataAccess.ReadCOSTByKHID(KHID, YEAR);
        }
        public CRM_COST_GETCOST GetCost(int LKAID, string HTYEAR)
        {
            return _DataAccess.GetCost(LKAID, HTYEAR);
        }
    }
}
