using Sonluk.DAFactory;
using Sonluk.Entities.BC;
using Sonluk.Entities.SD;
using Sonluk.IDataAccess.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.SD
{
    public class CLIENTINFO
    {
        private static readonly ICLIENTINFO detaAccess_ICLIENTINFO = SDDataAccess.CreateICLIENTINFO();
        public ZBCFUN_KHXX_READ_RETURN ZBCFUN_KHXX_READ(ZSL_BCS111 IS_HEADDATA)
        {
            return detaAccess_ICLIENTINFO.ZBCFUN_KHXX_READ(IS_HEADDATA);
        }
    }
}
