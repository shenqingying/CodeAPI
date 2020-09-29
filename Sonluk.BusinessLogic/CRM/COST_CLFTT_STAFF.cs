using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CLFTT_STAFF
    {
        private static readonly ICOST_CLFTT_STAFF _DataAccess = RMSDataAccess.CreateCOST_CLFTT_STAFF();



        public int Create(CRM_COST_CLFTT_STAFF model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CLFTT_STAFF model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CLFTT_STAFF> ReadByParam(CRM_COST_CLFTT_STAFF model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int ID)
        {
            return _DataAccess.Delete(ID);
        }




    }
}
