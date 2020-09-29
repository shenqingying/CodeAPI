using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IPRODUCT_PRODUCT
    {
        int Create(CRM_PRODUCT_PRODUCT model);
        int Update(CRM_PRODUCT_PRODUCT model);
        int Delete(int PRODUCTID);
        IList<CRM_PRODUCT_PRODUCT> ReadByParam(CRM_PRODUCT_PRODUCT model);
        CRM_PRODUCT_PRODUCT ReadByID(int PRODUCTID);
        IList<CRM_PRODUCT_PRODUCT> ReadByRight(int KHID, string SDF, int CPLX, int ORDERTTID, string CPMC);
        IList<CRM_PRODUCT_PRODUCT> ReadCPLXByRight(int KHID);

    }
}
