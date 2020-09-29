using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IROLE_GZZX
    {
        MES_RETURN INSERT(List<MES_SY_GZZX_LAY> model);
        MES_RETURN DELETE(int ROLEID);
        MES_ROLE_GZZX_SELECT_BYROLEID SELECT_BYROLEID(int ROLEID);
        int SELECT_COUNT_BY_STAFFID(string GC, string GZZXBH, int STAFFID);
    }
}
