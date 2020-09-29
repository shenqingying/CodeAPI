using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_KB
    {
        int Create(CRM_PRODUCT_KB model);
        int Update(CRM_PRODUCT_KB model);
        IList<CRM_PRODUCT_KB> ReadByParam(CRM_PRODUCT_KB model);
        int Delete(int KBID);
    }
}
