using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_KB
    {
        private static readonly IPRODUCT_KB _DataAccess = RMSDataAccess.CreatePRODUCT_KB();

        public int Create(CRM_PRODUCT_KB model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_KB model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_PRODUCT_KB> ReadByParam(CRM_PRODUCT_KB model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int KBID)
        {
            return _DataAccess.Delete(KBID);
        }
    }
}
