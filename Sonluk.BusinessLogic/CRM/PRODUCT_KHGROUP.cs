using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_KHGROUP
    {
        private static readonly IPRODUCT_KHGROUP _DataAccess = RMSDataAccess.CreateIPRODUCT_KHGROUP();

        public int Create(int KHID, int GROUPID)
        {
            return _DataAccess.Create(KHID, GROUPID);
        }
        public int Delete(int KHID, int GROUPID)
        {
            return _DataAccess.Delete(KHID, GROUPID);
        }
        public IList<CRM_PRODUCT_KHGROUP> Read(CRM_PRODUCT_KHGROUP model)
        {
            return _DataAccess.Read(model);
        }


    }
}
