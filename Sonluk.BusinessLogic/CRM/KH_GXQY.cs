using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_GXQY
    {
        private static readonly IKH_GXQY _DataAccess = RMSDataAccess.CreateKH_GXQY();
        public int Create(CRM_KH_GXQY model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_GXQY model)
        {
            return _DataAccess.Update(model);
        }
        public IList<CRM_KH_GXQYList> Read(int KHID)
        {
            return _DataAccess.Read(KHID);
        }
        public int Delete(int GXQYID)
        {
            return _DataAccess.Delete(GXQYID);
        }
        public int DeleteByKHID(int KHID)
        {
            return _DataAccess.DeleteByKHID(KHID);
        }
    }
}
