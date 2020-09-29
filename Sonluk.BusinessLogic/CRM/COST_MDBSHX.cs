using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_MDBSHX
    {
        private static readonly ICOST_MDBSHX _DataAccess = RMSDataAccess.CreateCOST_MDBSHX();


        public int Create(CRM_COST_MDBSHX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_MDBSHX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_MDBSHX> ReadByParam(CRM_COST_MDBSHX model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(int MDBSHXID)
        {
            return _DataAccess.Delete(MDBSHXID);
        }
        public IList<CRM_COST_MDBSHX> Read_Unconnected(CRM_COST_MDBSHX model)
        {
            return _DataAccess.Read_Unconnected(model);
        }


    }
}
