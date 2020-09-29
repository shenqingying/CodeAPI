using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KAYEARTT
    {
        private static readonly ICOST_KAYEARTT _DataAccess = RMSDataAccess.CreateCOST_KAYEARTT();

        public int Create(CRM_COST_KAYEARTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KAYEARTT model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateSubmitCount(int KAYEARTTID)
        {
            return _DataAccess.UpdateSubmitCount(KAYEARTTID);
        }
        public IList<CRM_COST_KAYEARTT> ReadByParam(CRM_COST_KAYEARTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int KAYEARTTID)
        {
            return _DataAccess.Delete(KAYEARTTID);
        }
        public int Verify(CRM_COST_KAYEARTT model)
        {
            return _DataAccess.Verify(model);
        }


    }
}
