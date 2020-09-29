using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_MTC_REP
    {
        MES_PMM_MTC_REP_SELECT SELECT(MES_PMM_MTC_REP model);
        MES_RETURN INSERT(MES_PMM_MTC_REP model);
        MES_RETURN DELETE(int MTCID);
    }
}
