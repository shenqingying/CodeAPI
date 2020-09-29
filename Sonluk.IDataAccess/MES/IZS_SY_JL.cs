using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IZS_SY_JL
    {
        MES_RETURN INSERT(MES_ZS_SY_JL model);
        MES_RETURN UPDATE(MES_ZS_SY_JL model);
        MES_RETURN INSERT_MX(MES_ZS_SY_JL_MX model);
        MES_ZS_SY_JL_MX_SELECT SELECT_MX(MES_ZS_SY_JL_MX model);
        MES_RETURN INSERT_QJQXJL(MES_ZS_SY_JL_QJQXJL model);
    }
}
