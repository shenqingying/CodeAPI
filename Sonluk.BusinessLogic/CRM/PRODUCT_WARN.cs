using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_WARN
    {
        private static readonly IPRODUCT_WARN _DataAccess = RMSDataAccess.CreateIPRODUCT_WARN();

        public int Create(CRM_PRODUCT_WARN model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_WARN model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int PROWARNID)
        {
            return _DataAccess.Delete(PROWARNID);
        }

        public CRM_PRODUCT_WARN ReadByID(int PROWARNID)
        {
            return _DataAccess.ReadByID(PROWARNID);
        }
        public IList<CRM_PRODUCT_WARN> ReadByParam(CRM_PRODUCT_WARN model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public IList<CRM_PRODUCT_WARN> ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID)
        {
            return _DataAccess.ReadByKHIDandPRODUCTID(KHID, PRODUCTID);
        }

    }
}
