using Sonluk.Entities.BC;
using Sonluk.Entities.SD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.SD
{
    public interface ICLIENTINFO
    {
        ZBCFUN_KHXX_READ_RETURN ZBCFUN_KHXX_READ(ZSL_BCS111 IS_HEADDATA);
    }
}
