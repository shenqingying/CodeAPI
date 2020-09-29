using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface ISY_TPM_SYNC
    {
        MES_RETURN INSERT(MES_SY_TPM_SYNC model);
        MES_SY_TPM_SYNC_SELECT SELECT(MES_SY_TPM_SYNC model);
        MES_RETURN UPDATE(MES_SY_TPM_SYNC model);
        ZBCFUN_CPBZ_READ GET_CPBZ_READ_NEW1(string TPM);
    }
}
