using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface ISYS_STAFF
    {
        int Create(MSG_SYS_STAFF model);
        int Update(MSG_SYS_STAFF model);
        IList<MSG_SYS_STAFF> ReadByParam(MSG_SYS_STAFF model);
        int Delete(int ID, int XGR);
        int DeleteBySYSID(int SYSID, int XGR);

    }
}
