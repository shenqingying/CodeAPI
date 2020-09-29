using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_LKAEachYEAR
    {
        private static readonly ICOST_LKAEachYEAR _DataAccess = RMSDataAccess.CreateCOST_LKAEachYEAR();


        public int Create(CRM_COST_LKAEachYEAR model)
        {
            return _DataAccess.Create(model);
        }
        public int UpdateByTTID(int LKAYEARTTID)
        {
            return _DataAccess.UpdateByTTID(LKAYEARTTID);
        }
        public IList<CRM_COST_LKAEachYEAR> ReadByParam(CRM_COST_LKAEachYEAR model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int DeleteByTTID(int LKAYEARTTID)
        {
            return _DataAccess.DeleteByTTID(LKAYEARTTID);
        }





    }
}
