using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class OA_OPINION
    {
        private static readonly IOA_OPINION _DataAccess = RMSDataAccess.CreateOA_OPINION();




        public int Create(CRM_OA_OPINION model)
        {
            return _DataAccess.Create(model);
        }
        public IList<CRM_OA_OPINION> ReadByParam(CRM_OA_OPINION model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Update(CRM_OA_OPINION model)
        {
            return _DataAccess.Update(model);
        }



    }
}
