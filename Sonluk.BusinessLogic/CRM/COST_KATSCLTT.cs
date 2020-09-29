using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KATSCLTT
    {
        private static readonly ICOST_KATSCLTT _DataAccess = RMSDataAccess.CreateCOST_KATSCLTT();


        public int Create(CRM_COST_KATSCLTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KATSCLTT model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateCost(int KATSCLTTID)
        {
            return _DataAccess.UpdateCost(KATSCLTTID);
        }
        public IList<CRM_COST_KATSCLTT> ReadByParam(CRM_COST_KATSCLTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int KATSCLTTID)
        {
            return _DataAccess.Delete(KATSCLTTID);
        }





    }
}
