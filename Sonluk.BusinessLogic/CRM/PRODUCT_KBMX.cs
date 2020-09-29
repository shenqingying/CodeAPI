using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class PRODUCT_KBMX
    {
        private static readonly IPRODUCT_KBMX _DataAccess = RMSDataAccess.CreatePRODUCT_KBMX();

        public int Create(CRM_PRODUCT_KBMX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_PRODUCT_KBMX model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_PRODUCT_KBMX> ReadByParam(CRM_PRODUCT_KBMX model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public int Delete(int KBMXID)
        {
            return _DataAccess.Delete(KBMXID);
        }
        public int DeleteByKBID(int KBID)
        {
            return _DataAccess.DeleteByKBID(KBID);
        }
    }
}
