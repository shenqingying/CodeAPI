using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_STAFFDUTY
    {
        int Create(int STAFFID, int DUTYID);
        int Delete(int STAFFID, int DUTYID);
        IList<string[]> ReadBySTAFFID(int STAFFID);
        int DeleteByStaffid(int STAFFID);
    }
}
