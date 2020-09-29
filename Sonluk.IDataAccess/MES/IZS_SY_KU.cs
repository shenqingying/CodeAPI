using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.IDataAccess.MES
{
    public interface IZS_SY_KU
    {
        MES_RETURN INSERT(MES_ZS_SY_KU model);
        MES_RETURN UPDATE(MES_ZS_SY_KU model);
        MES_ZS_SY_KU_SELECT SELECT(MES_ZS_SY_KU model);
    }
}
