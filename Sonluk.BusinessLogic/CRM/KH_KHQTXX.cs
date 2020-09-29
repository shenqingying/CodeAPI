using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_KHQTXX
    {
        private static readonly IKH_KHQTXX _DataAccess = RMSDataAccess.CreateKH_KHQTXX();
        public int Create(CRM_KH_KHQTXX model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_KHQTXX model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int XXID)
        {
            return _DataAccess.Delete(XXID);
        }
        public IList<CRM_KH_KHQTXXList> Read(int KHID, int XXLB)
        {
            return _DataAccess.Read(KHID, XXLB);
        }
        public int DeleteByKHID_XXLB(int KHID, int XXLB)
        {
            return _DataAccess.DeleteByKHID_XXLB(KHID, XXLB);
        }
    }
}
