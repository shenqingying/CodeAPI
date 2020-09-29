using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_GROUP
    {

        int Create(CRM_PRODUCT_GROUP model);
        int Update(CRM_PRODUCT_GROUP model);
        int Delete(int GROUPID);
        IList<CRM_PRODUCT_GROUP> Read();
        int ReadByIDGroupName(string GROUPNAME);

    }
}
