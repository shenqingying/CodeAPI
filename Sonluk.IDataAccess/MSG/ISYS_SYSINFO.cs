using Sonluk.Entities.MSG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MSG
{
    public interface ISYS_SYSINFO
    {
        int Create(MSG_SYS_SYSINFO model);
        int Update(MSG_SYS_SYSINFO model);
        IList<MSG_SYS_SYSINFO> ReadByParam(MSG_SYS_SYSINFO model);
        int Delete(int SYSID, int XGR);

    }
}
