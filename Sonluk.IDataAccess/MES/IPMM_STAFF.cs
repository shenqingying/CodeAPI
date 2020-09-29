using Sonluk.Entities.API;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_STAFF
    {
        MES_PMM_STAFF_SELECT SELECT(MES_PMM_STAFF model);
        MES_RETURN COVER(MES_PMM_STAFF model);
        MES_RETURN DELETE(MES_PMM_STAFF model);
        ApiReturn Read(MES_PMM_STAFF model);
        ApiReturn Update(MES_PMM_STAFF model);
        ApiReturn Delete(MES_PMM_STAFF model);
    }
}
