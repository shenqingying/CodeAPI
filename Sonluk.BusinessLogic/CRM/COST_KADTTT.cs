using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_KADTTT
    {
        private static readonly ICOST_KADTTT _DataAccess = RMSDataAccess.CreateCOST_KADTTT();

        public int Create(CRM_COST_KADTTT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_KADTTT model)
        {
            return _DataAccess.Update(model);
        }
        public int UpdateCost(int KADTTTID)
        {
            return _DataAccess.UpdateCost(KADTTTID);
        }
        public IList<CRM_COST_KADTTT> ReadByParam(CRM_COST_KADTTT model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public IList<CRM_COST_KADTTT> Read_Unconnected(CRM_COST_KADTTT model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public int Delete(int KADTTTID)
        {
            return _DataAccess.Delete(KADTTTID);
        }



    }
}
