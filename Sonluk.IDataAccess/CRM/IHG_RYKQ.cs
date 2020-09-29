using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.CRM
{
    public interface IHG_RYKQ
    {
        int Create(int STAFFID, int KQDZID);
        int Delete(int STAFFID, int KQDZID);
        IList<string[]> ReadBySTAFFID(int STAFFID);
    }
}
