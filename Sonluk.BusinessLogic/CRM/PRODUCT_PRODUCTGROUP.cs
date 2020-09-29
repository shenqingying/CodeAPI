using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_PRODUCTGROUP
    {
        private static readonly IPRODUCT_PRODUCTGROUP _DataAccess = RMSDataAccess.CreateIPRODUCT_PRODUCTGROUP();

        public int Create(int PRODUCTID, int GROUPID)
        {
            return _DataAccess.Create(PRODUCTID, GROUPID);
        }
        public int Delete(int PRODUCTID, int GROUPID)
        {
            return _DataAccess.Delete(PRODUCTID, GROUPID);
        }
        public IList<CRM_PRODUCT_PRODUCTGROUP> Read(CRM_PRODUCT_PRODUCTGROUP model)
        {
            return _DataAccess.Read(model);
        }

    }
}
