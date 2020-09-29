using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_DZ
    {
        private static readonly IKH_DZ _DataAccess = RMSDataAccess.CreateKH_DZ();
        public int Create(CRM_KH_DZ model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_DZ model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int DZID)
        {
            return _DataAccess.Delete(DZID);
        }
        public IList<CRM_KH_DZList> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
    }
}
