using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_KHGROUP
    {

        int Create(int KHID, int GROUPID);
        int Delete(int KHID, int GROUPID);
        IList<CRM_PRODUCT_KHGROUP> Read(CRM_PRODUCT_KHGROUP model);


    }
}
