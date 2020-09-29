using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_XSYWJZ
    {
        private static readonly IKH_XSYWJZ _DataAccess = RMSDataAccess.CreateKH_XSYWJZ();
        public int Create(CRM_KH_XSYWJZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_XSYWJZ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int XSYWJZID)
        {
            return _DataAccess.Delete(XSYWJZID);
        }
        public IList<CRM_KH_XSYWJZList> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
        public CRM_KH_XSYWJZ ReadByID(int XSYWJZID)
        {
            return _DataAccess.ReadByID(XSYWJZID);
        }



    }
}
