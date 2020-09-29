using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_PRODUCT
    {
        private static readonly IPRODUCT_PRODUCT _DataAccess = RMSDataAccess.CreateIPRODUCT_PRODUCT();


        public int Create(CRM_PRODUCT_PRODUCT model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_PRODUCT model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int PRODUCTID)
        {
            return _DataAccess.Delete(PRODUCTID);
        }
        public IList<CRM_PRODUCT_PRODUCT> ReadByParam(CRM_PRODUCT_PRODUCT model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public CRM_PRODUCT_PRODUCT ReadByID(int PRODUCTID)
        {
            return _DataAccess.ReadByID(PRODUCTID);
        }
        public IList<CRM_PRODUCT_PRODUCT> ReadByRight(int KHID, string SDF, int CPLX, int ORDERTTID, string CPMC)
        {
            return _DataAccess.ReadByRight(KHID,SDF, CPLX, ORDERTTID, CPMC);
        }
        public IList<CRM_PRODUCT_PRODUCT> ReadCPLXByRight(int KHID)
        {
            return _DataAccess.ReadCPLXByRight(KHID);
        }


    }
}
