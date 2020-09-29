using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_MTC_CAVE
    {
        MES_PMM_MTC_CAVE_SELECT SELECT(MES_PMM_MTC_CAVE model);
        MES_RETURN INSERT(MES_PMM_MTC_CAVE model);
        MES_RETURN DELETE(int MTCID);
    }
}
