using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IROLR_GZZX_GW
    {
        MES_RETURN INSERT(List<MES_ROLR_GZZX_GW> model);
        MES_RETURN DELETE(int ROLEID);
        MES_ROLR_GZZX_GW_LIST SELECT(int ROLEID);
    }
}
