using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_WARN
    {
        int Create(CRM_PRODUCT_WARN model);
        int Update(CRM_PRODUCT_WARN model);
        int Delete(int PROWARNID);
        CRM_PRODUCT_WARN ReadByID(int PROWARNID);
        IList<CRM_PRODUCT_WARN> ReadByParam(CRM_PRODUCT_WARN model);
        IList<CRM_PRODUCT_WARN> ReadByKHIDandPRODUCTID(int KHID, int PRODUCTID);
    }
}
