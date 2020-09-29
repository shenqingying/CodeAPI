using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SAP
{
    public interface IZBCFUN
    {
        MES_SY_TPM_SYNC_SELECT ZBCFUN_TPZSJ_READ(string IV_DATEST, string IV_DATEED);
    }
}
