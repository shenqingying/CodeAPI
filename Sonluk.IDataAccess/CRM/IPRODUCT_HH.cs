using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_HH
    {
       int Create(CRM_PRODUCT_HH model);
       int Update(CRM_PRODUCT_HH model);
       IList<CRM_PRODUCT_HH> ReadByParam(CRM_PRODUCT_HH model,int STAFFID);
       int Delete(CRM_PRODUCT_HH model);

    }
}
