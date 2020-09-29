using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class KH_HD
    {
        private static readonly IKH_HD _DataAccess = RMSDataAccess.CreateKH_HD();


        public int Create(CRM_KH_HD model)
        {
            return _DataAccess.Create(model);
        }
        public int Update(CRM_KH_HD model)
        {
            return _DataAccess.Update(model);
        }
        public int Delete(int HDID)
        {
            return _DataAccess.Delete(HDID);
        }
        public IList<CRM_KH_HDList> ReadByKHID(int KHID)
        {
            return _DataAccess.ReadByKHID(KHID);
        }
        public CRM_KH_HD ReadByID(int HDID)
        {
            return _DataAccess.ReadByID(HDID);
        }



    }
}
