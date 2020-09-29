using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_KHZZ
    {
        private static readonly IKH_KHZZ _DataAccess = RMSDataAccess.CreateKH_KHZZ();


        public int Create(CRM_KH_KHZZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_KHZZ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int ZZID)
        {
            return _DataAccess.Delete(ZZID);
        }
        public int DeleteByKHID(int KHID)
        {
            return _DataAccess.DeleteByKHID(KHID);
        }
        public IList<CRM_KH_KHZZList> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
        public IList<CRM_KH_KHZZ> ReadByParam(CRM_KH_KHZZ model)
        {
            return _DataAccess.ReadByParam(model);
        }
        public CRM_KH_KHZZ ReadByID(int ZZID)
        {
            return _DataAccess.ReadByID(ZZID);
        }

    }
}
