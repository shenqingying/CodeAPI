using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class COST_CPLX
    {
        private static readonly ICOST_CPLX _DataAccess = RMSDataAccess.CreateCOST_CPLX();


        public int Create(CRM_COST_CPLX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_COST_CPLX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_COST_CPLX> ReadByParam(CRM_COST_CPLX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int CPLXID)
        {
            return _DataAccess.Delete(CPLXID);
        }






    }
}
