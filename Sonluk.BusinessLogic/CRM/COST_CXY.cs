using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CXY
    {
        private static readonly ICOST_CXY _DataAccess = RMSDataAccess.CreateCOST_CXY();

        public int Create(CRM_COST_CXY model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CXY model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CXY> ReadByParam(CRM_COST_CXY model,int STAFFID)
        {
            return _DataAccess.ReadByParam(model,STAFFID);
        }
        public IList<CRM_COST_CXY> ReadByGZ(CRM_COST_CXY model)
        {
            return _DataAccess.ReadByGZ(model);
        }

        public int Delete(int CXYID)
        {
            return _DataAccess.Delete(CXYID);
        }
    }
}
