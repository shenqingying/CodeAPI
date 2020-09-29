using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IBAT_REPORT
    {
        SELECT_MES_TM_TMINFO_BYTM SELECT_MES_TM_TMINFO(string ERPNO, string XSNOBILL, string XSNOBILLMX);
        MES_DCCYJYBZ SELECT_DCCYJYBZ(MES_DCCYJYBZ model);
        MES_DCCYJYBZ SELECT_DCCYJYBZ_Parms(int SL, string BZMC);
    }
}
