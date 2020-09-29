using Sonluk.Entities.BC;
using Sonluk.Entities.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MM
{
    public interface IMATERIALINFO
    {
        ZBCFUN_MMINFO_READ_RETURN ZBCFUN_MMINFO_READ(ZSL_BCS112 IS_MATDATA);
    }
}
