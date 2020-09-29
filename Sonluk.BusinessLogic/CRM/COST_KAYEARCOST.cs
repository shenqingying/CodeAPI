using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAYEARCOST
    {
        private static readonly ICOST_KAYEARCOST _DataAccess = RMSDataAccess.CreateCOST_KAYEARCOST();

        public int Create(CRM_COST_KAYEARCOST model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAYEARCOST model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateSPJE(int KAYEARTTID)
        {
            return _DataAccess.UpdateSPJE(KAYEARTTID);
        }
        public IList<CRM_COST_KAYEARCOST> ReadByParam(CRM_COST_KAYEARCOST model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_COST_KAYEARCOST> Read_Unconnected(CRM_COST_KAYEARCOST model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public int Delete(int COSTID)
        {
            return _DataAccess.Delete(COSTID);
        }

    }
}
