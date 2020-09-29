using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.BC
{
    public class DRF
    {
        private static readonly IDRF detaAccess_DRF = BCDataAccess.CreateIDRF();
        public ZBCFUN_DRFDD_CRT_RETURN ZBCFUN_DRFDD_CRT(ZSL_BCS111 IS_HEADDATA, List<ZSL_BCS112> IT_ITEMDATA)
        {
            return detaAccess_DRF.ZBCFUN_DRFDD_CRT(IS_HEADDATA, IT_ITEMDATA);
        }
        public MES_RETURN ZBCFUN_DRFDD_CHK(ZSL_BCS111 IS_HEADDATA)
        {
            return detaAccess_DRF.ZBCFUN_DRFDD_CHK(IS_HEADDATA);
        }
        public ZBCFUN_DRFDD_DT_RETURN ZBCFUN_DRFDD_DT(List<ZSL_BCS113> IT_ORDERDATA)
        {
            return detaAccess_DRF.ZBCFUN_DRFDD_DT(IT_ORDERDATA);
        }
    }
}
