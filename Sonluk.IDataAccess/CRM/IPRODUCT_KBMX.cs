using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_KBMX
    {
        int Create(CRM_PRODUCT_KBMX model);
        int Update(CRM_PRODUCT_KBMX model);
        IList<CRM_PRODUCT_KBMX> ReadByParam(CRM_PRODUCT_KBMX model);
        int Delete(int KBMXID);
        int DeleteByKBID(int KBID);

    }
}
