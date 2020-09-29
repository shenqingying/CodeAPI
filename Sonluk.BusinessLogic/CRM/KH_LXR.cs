using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_LXR
    {
        private static readonly IKH_LXR _DataAccess = RMSDataAccess.CreateKH_LXR();
        public int Create(CRM_KH_LXR model)
        {
           return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_LXR model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int KHLXRID)
        {
            return _DataAccess.Delete(KHLXRID);
        }
        public IList<CRM_KH_LXRList> Read(int KHID,int LB)
        {
            return _DataAccess.Read(KHID,LB);
        }
        public int DeleteByKHID(int KHID)
        {
            return _DataAccess.DeleteByKHID(KHID);
        }
    }
}
