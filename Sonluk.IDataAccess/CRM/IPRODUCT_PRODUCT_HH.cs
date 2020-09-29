using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_PRODUCT_HH
    {
        int Create(CRM_PRODUCT_PRODUCT_HH model);
        int Update(CRM_PRODUCT_PRODUCT_HH model);
        IList<CRM_PRODUCT_PRODUCT_HH> ReadByParam(CRM_PRODUCT_PRODUCT_HH model);
        IList<CRM_PRODUCT_PRODUCT_HH> ReadByProNum(CRM_PRODUCT_PRODUCT_HH model);
        int Delete(int ID);
    }
}
