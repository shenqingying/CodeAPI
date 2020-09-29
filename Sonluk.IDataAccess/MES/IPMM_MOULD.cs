using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IPMM_MOULD
    {
        MES_PMM_MOULD_SELECT SELECT(MES_PMM_MOULD model, int STAFFID);
        MES_RETURN INSERT(MES_PMM_MOULD model, int STAFFID);
        MES_RETURN UPDATE(MES_PMM_MOULD model, int STAFFID);
        MES_RETURN DELETE(string MID, int STAFFID);
    }
}
