using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_HH
    {
        private static readonly IPRODUCT_HH _DataAccess = RMSDataAccess.CreatePRODUCT_HH();

        public int Create(CRM_PRODUCT_HH model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_HH model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_PRODUCT_HH> ReadByParam(CRM_PRODUCT_HH model,int STAFFID)
        {
            return _DataAccess.ReadByParam(model, STAFFID);
        }
        public int Delete(CRM_PRODUCT_HH model)
        {
            return _DataAccess.Delete(model);
        }
    }
}
