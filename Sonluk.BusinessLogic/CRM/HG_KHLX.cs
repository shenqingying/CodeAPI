using Sonluk.DAFactory;
using Sonluk.Entities.CRM;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_KHLX
    {
        private static readonly IHG_KHLX _DataAccess = RMSDataAccess.CreateHG_KHLX();

        public int Create(int STAFFKHLXID, int DICID)
        {
            return _DataAccess.Create(STAFFKHLXID, DICID);
        }
        public IList<CRM_HG_KHLXList> Read(int STAFFKHLXID, int DICID)
        {
            return _DataAccess.Read(STAFFKHLXID, DICID);
        }
        public int Delete(int STAFFKHLXID, int DICID)
        {
            return _DataAccess.Delete(STAFFKHLXID, DICID);
        }

    }
}
