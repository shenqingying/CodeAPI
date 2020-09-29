using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.BC
{
    public interface IDRF
    {
        ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(ZSL_BCS111 IS_HEADDATA, List<ZSL_BCS112> IT_ITEMDATA);
        MES_RETURN ZBCFUN_DRFDD_CHK(ZSL_BCS111 IS_HEADDATA);
        ZBCFUN_DRFDD_DT_RETURN ZBCFUN_DRFDD_DT(List<ZSL_BCS113> IT_ORDERDATA);
    }
}
