using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_OTHER
    {
        private static readonly ICOST_OTHER _DataAccess = RMSDataAccess.CreateCOST_OTHER();


        public int Create(CRM_COST_OTHER model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_OTHER model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_OTHER> ReadByParam(CRM_COST_OTHER model, int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public IList<CRM_COST_OTHER> Read_Unconnected(CRM_COST_OTHER model)
        {
            return _DataAccess.Read_Unconnected(model);
        }
        public int Delete(int OTHERID)
        {
            return _DataAccess.Delete(OTHERID);
        }





    }
}
