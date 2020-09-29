using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IMES_PLDH
    {
        ZBCFUN_ZJLOT_PRT GET_ZJINFO(ZSL_BCT304_CT model, string IV_FCODE);
        ZBCFUN_GDRKS_READ GET_GDINFO(List<ZSL_BCST024_PO> IT_GDXX);
    }
}
