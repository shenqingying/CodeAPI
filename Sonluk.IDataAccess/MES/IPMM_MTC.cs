using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_MTC
    {
        MES_PMM_MTC_SELECT SELECT(MES_PMM_MTC model);
        MES_RETURN INSERT(MES_PMM_MTC model);
        MES_RETURN UPDATE(MES_PMM_MTC model);
        MES_RETURN UPDATE_CFMBACK(MES_PMM_MTC model);
        MES_RETURN DELETE(MES_PMM_MTC model);
    }
}
