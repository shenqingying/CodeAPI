using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAFYMXTSCL
    {
        private static readonly ICOST_LKAFYMXTSCL _DataAccess = RMSDataAccess.CreateCOST_LKAFYMXTSCL();

        public int Create(CRM_COST_LKAFYMXTSCL model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_LKAFYMXTSCL model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_LKAFYMXTSCL> ReadByParam(CRM_COST_LKAFYMXTSCL model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int LKATSCLMXID)
        {
            return _DataAccess.Delete(LKATSCLMXID);
        }
        public IList<CRM_COST_LKAFYMXTSCL> Read_Unconnected(CRM_COST_LKAFYMXTSCL model)
        {
            return _DataAccess.Read_Unconnected(model);
        }


    }
}
