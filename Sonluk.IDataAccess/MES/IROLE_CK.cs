using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IROLE_CK
    {
        MES_RETURN INSERT(List<MES_ROLE_CK> model);
        MES_RETURN DELETE(int ROLEID);
        MES_ROLE_CK_LIST SELECT(int ROLEID);
        int SELECT_COUNT_BY_STAFFID(string GC, string CKDM, int STAFFID);
    }
}
