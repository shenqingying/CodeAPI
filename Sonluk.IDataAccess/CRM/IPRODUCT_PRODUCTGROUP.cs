using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_PRODUCTGROUP
    {
        int Create(int PRODUCTID, int GROUPID);
        int Delete(int PRODUCTID, int GROUPID);
        IList<CRM_PRODUCT_PRODUCTGROUP> Read(CRM_PRODUCT_PRODUCTGROUP model);

    }
}
