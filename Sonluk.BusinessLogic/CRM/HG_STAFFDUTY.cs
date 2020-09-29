using Sonluk.DAFactory;
using Sonluk.IDataAccess.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.CRM
{
    public class HG_STAFFDUTY
    {
        private static readonly IHG_STAFFDUTY _DataAccess = RMSDataAccess.CreateHG_STAFFDUTY();

        public int Create(int STAFFID, int DUTYID)
        {
            return _DataAccess.Create(STAFFID, DUTYID);
        }
        public int Delete(int STAFFID, int DUTYID)
        {
            return _DataAccess.Delete(STAFFID, DUTYID);
        }
        public IList<string[]> ReadBySTAFFID(int STAFFID)
        {
            return _DataAccess.ReadBySTAFFID(STAFFID);
        }
        public int DeleteByStaffid(int STAFFID)
        {
            return _DataAccess.DeleteByStaffid(STAFFID);
        }
    }
}
